using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using LDZ_Code;
using CsvHelper;
using System.Collections;
using System.IO;
using System.Linq;
using System.Threading;
using static LDZ_Code.ServiceFunctions;

namespace AOF_Controller
{
    public partial class Form1
    {
        private void tests()
        {
            ///Тесты считывания настроек из файла
            try
            {
                double a = Convert.ToDouble("600.000");
                Log.Message("Точка конвертируется корректно");
            }
            catch (Exception e)
            {
                Log.Error("Точка конвертируется некорректно");
            }

            try
            {
                double a = Convert.ToDouble("600,000");
                Log.Message("Запятая конвертируется корректно");
            }
            catch (Exception e)
            {
                Log.Error("Запятая конвертируется некорректно");
            }
            ///Read_dev_file в развернутов виде
            int level = 1;
            try
            {
                level = 1;

                var Data_from_dev = ServiceFunctions.Files.Read_txt("ampl_avm1-011-5.dev");
                var FilterCfgPath = "ampl_avm1-011-5.dev";
                var FilterCfgName = "ampl_avm1-011-5.dev";
                float[] pWLs, pHZs, pCoefs;

                level = 2;

                ServiceFunctions.Files.Get_WLData_byKnownCountofNumbers(3, Data_from_dev.ToArray(), out pWLs, out pHZs, out pCoefs);
                
                level = 3;

                float[] WLs, HZs, Intensity;
                float[] pData = new float[pWLs.Length];
                pWLs.CopyTo(pData, 0);
                int RealLength = pWLs.Length - 1;

                level = 4;

                if (pWLs[0] - pWLs[RealLength] > 0)
                {
                    WLs = new float[pWLs.Length];
                    HZs = new float[pWLs.Length]; ;
                    Intensity = new float[pWLs.Length];
                    for (int i = 0; i < pWLs.Length; i++)
                    {
                        WLs[i] = pWLs[RealLength - i];
                        HZs[i] = pHZs[RealLength - i];
                        Intensity[i] = pCoefs[RealLength - i];
                    }
                }
                else
                {
                    WLs = pWLs;
                    HZs = pHZs;
                    Intensity = pCoefs;
                }
                level = 5;

                pWLs = WLs;
                pHZs = HZs;
                pCoefs = Intensity;
                ServiceFunctions.Math.Interpolate_curv(ref pWLs, ref pHZs);
                ServiceFunctions.Math.Interpolate_curv(ref pData, ref pCoefs);
                level = 6;

                WLs = pWLs;
                HZs = pHZs;
                Intensity = pCoefs;

                level = 0; throw new Exception();

            }
            catch(Exception e)
            {
                Log.Message("Уровень ошибки :" + level.ToString());
                Log.Error(e.Message);
            }

            /*   Filter.Read_dev_file("ampl_avm1-011-3.dev");
               Filter.PowerOn();
               Filter.Set_Wl(Filter.WL_Max);
               Filter.Set_Wl((Filter.WL_Max + Filter.WL_Min) / 2);
               Filter.Set_Wl(Filter.WL_Min);
               Filter.Set_Hz((Filter.HZ_Min + Filter.HZ_Max) / 2);
               float delta = 5;
               Filter.Set_Sweep_on((Filter.HZ_Max + Filter.HZ_Min) / 2 - delta, 2 * delta, 1, true);
               System.Threading.Thread.Sleep(2000);
               Filter.Set_Sweep_off();*/
            //  Filter.PowerOff();
        }
        private void InitializeComponents_byVariables()
        {
            Value_in_setting = true;
            try
            {
                ChB_Power.Checked = false;

                ChB_AutoSetWL.Checked = AO_WL_Controlled_byslider;

                L_RequiredDevName.Text = Filter.Ask_required_dev_file();
                L_RealDevName.Text = Filter.Ask_loaded_dev_file();
                float data_CurWL = (Filter.WL_Max + Filter.WL_Min) / 2;
                Filter.Set_Wl(data_CurWL);


                NUD_CurWL.Minimum = (decimal)Filter.WL_Min;
                TrB_CurrentWL.Minimum = (int)(Filter.WL_Min * AO_WL_precision);
                NUD_CurWL.Maximum = (decimal)Filter.WL_Max;
                TrB_CurrentWL.Maximum = (int)(Filter.WL_Max * AO_WL_precision);
                NUD_CurWL.Value = (decimal)data_CurWL;
                TrB_CurrentWL.Value = (int)(data_CurWL * AO_WL_precision);


                ChB_SweepEnabled.Checked = Filter.is_inSweepMode;
                Pan_SweepControls.Enabled = Filter.is_inSweepMode;
                var AOFWind_FreqDeviation_bkp = AO_FreqDeviation; 
                NUD_FreqDeviation.Maximum = (decimal)(Filter.AO_FreqDeviation_Max);
                NUD_FreqDeviation.Minimum = (decimal)(Filter.AO_FreqDeviation_Min);


                var AOFWind_TimeDeviation_bkp = AO_TimeDeviation; // ибо AOFWind_TimeDeviation изменяется, если изменяются максимумы
              /*  NUD_TimeFdev.Minimum = (decimal)Filter.AO_TimeDeviation_Min;
                NUD_TimeFdev.Maximum = (decimal)Filter.AO_TimeDeviation_Max;

                NUD_TimeFdev.Value = (decimal)AOFWind_TimeDeviation_bkp;*/
                NUD_FreqDeviation.Value = (decimal)AOFWind_FreqDeviation_bkp > NUD_FreqDeviation.Maximum ? NUD_FreqDeviation.Maximum : (decimal)AO_FreqDeviation;

                ChB_Power.Enabled = true;
                TSMI_CreateCurve.Enabled = true;
 
                TRB_SoundFreq.Minimum = (int)(Filter.HZ_Min*1000);
                NUD_CurMHz.Minimum = (decimal)Filter.HZ_Min;
                TRB_SoundFreq.Maximum = (int)(Filter.HZ_Max*1000);
                NUD_CurMHz.Maximum = (decimal)Filter.HZ_Max;
                TRB_SoundFreq.Value = (int)(Filter.Get_HZ_via_WL((Filter.WL_Max + Filter.WL_Min) / 2) * AO_HZ_precision);
                NUD_CurMHz.Value = (decimal)Filter.Get_HZ_via_WL((Filter.WL_Max + Filter.WL_Min) / 2);

                NUD_AO_Timeout_Value.Minimum = Filter.MS_delay_min;
                NUD_AO_Timeout_Value.Maximum = Filter.MS_delay_max;
                NUD_AO_Timeout_Value.Value = Filter.MS_delay_default;
                ChB_TimeOut.Checked = true; //by default it is not checked, so the check event would be rised
                ChB_AutoSetWL.Checked = true;
                Log.Message("Инициализация элементов управления прошла успешно!");
            }
            catch(Exception exc)
            {
                Log.Error("Инициализация элементов управления завершилась с ошибкой.");
            }
            finally
            {
                Value_in_setting = false;
            }
        }

        private void SetWL_everywhere(int pwl)
        {
            NUD_CurWL.Value = pwl;
            TrB_CurrentWL.Value = pwl;
        }
        private void Set_HZorWL_everywhere(float pMHz_or_WL,bool isHZ,double WLPrecision,double HZPrecision,bool is_need_to_set_in_Filter,bool TimerRestartNeeded=true)
        {
            Value_in_setting = true;
            try
            {
                float this_HZ = 0;
                float this_WL = 0;
                if (isHZ)
                {
                    this_HZ = pMHz_or_WL;
                    this_WL = (float)System.Math.Round(Filter.Get_WL_via_HZ(pMHz_or_WL), (int)System.Math.Log10(WLPrecision));
                }
                else
                {
                    this_HZ = (float)System.Math.Round(Filter.Get_HZ_via_WL(pMHz_or_WL), (int)System.Math.Log10(HZPrecision)); ;
                    this_WL = pMHz_or_WL;
                }
                NUD_CurWL.Value = (decimal)this_WL;
                NUD_CurMHz.Value = (decimal)this_HZ;
                TrB_CurrentWL.Value = (int)(this_WL * WLPrecision);
                TRB_SoundFreq.Value = (int)(this_HZ * HZPrecision);
                if (is_need_to_set_in_Filter)
                {
                    if (AO_Sweep_Needed)
                    {
                        if (!timer_for_sweep.IsRunning || timer_for_sweep.ElapsedMilliseconds > 500)
                        {
                            if(TimerRestartNeeded) timer_for_sweep.Restart();
                            ReSweep(this_WL);
                        }
                    }
                    else
                    {
                        try
                        {
                            var state = Filter.Set_Hz(this_HZ);
                            if (state != 0) throw new Exception(Filter.Implement_Error(state));
                           // Log.Message(String.Format("Установленная длина волны: {0}. Частота синтезатора: {1}", this_WL, this_HZ));
                        }
                        catch (Exception exc)
                        {
                            Log.Error(exc.Message);
                        }
                    }
                }
            }
            catch
            {

            }
            finally
            {
                Value_in_setting = false;
            }
            Value_in_setting = false;
        }
        private void ReSweep(float p_data_CurrentWL)
        {
            Filter.Set_Sweep_off();
            
            float HZ_toset = Filter.Get_HZ_via_WL(p_data_CurrentWL);
            System.Drawing.PointF data_for_sweep = Filter.Sweep_Recalculate_borders(HZ_toset, (float)AO_FreqDeviation);

            Log.Message(String.Format("ЛЧМ Параметры: ДВ:{0} / Частота:{1} / Девиация частоты:{2}", p_data_CurrentWL, HZ_toset, AO_FreqDeviation));
            Log.Message(String.Format("Доступные для установки ЛЧМ параметры:  ДВ: {0} / Частота:{1} / Девиация частоты: {2} ",
                p_data_CurrentWL, HZ_toset, data_for_sweep.Y / 2));
            Log.Message(String.Format("Пересчет:  {0}+{1}", data_for_sweep.X, data_for_sweep.Y));

            

            var state = Filter.Set_Sweep_on(data_for_sweep.X, data_for_sweep.Y, AO_TimeDeviation, true);
            if (state != 0) throw new Exception(Filter.Implement_Error(state));
            Log.Message("Режим ЛЧМ около длины волны " + p_data_CurrentWL.ToString() + " нм запущен!");
        }
        private DialogResult OpenDevSearcher(ref string CfgToLoad, ref string CfgToLoad_fullPath)
        {

            OpenFileDialog OPF = new OpenFileDialog();
            OPF.InitialDirectory = Application.StartupPath;
            OPF.Filter = "DEV config files (*.dev)|*.dev|All files (*.*)|*.*";
            OPF.FilterIndex = 0;
            OPF.RestoreDirectory = true;

            if (OPF.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    int k = 1 + OPF.FileName.LastIndexOf('\\');
                    CfgToLoad_fullPath = OPF.FileName;
                    CfgToLoad = OPF.FileName.Substring(k, OPF.FileName.Length - k);
                }
                catch (Exception ex)
                {
                    Log.Error("Не удалось считать файл с диска. Оригинал ошибки: " + ex.Message);
                }
                return DialogResult.OK;
            }
            else return DialogResult.Cancel;
        }

        public class FieldsClass { }
        public class OneFildsClass<alpha> : FieldsClass
        {
            public alpha Field1 { get; set; }
        }
        public class TwoFildsClass<alpha, beta> : FieldsClass
        {
            public alpha Field1 { get; set; }
            public beta Field2 { get; set; }
        }
        public class ThreeFildsClass<alpha, beta, gamma> : FieldsClass
        {
            public alpha Field1 { get; set; }
            public beta Field2 { get; set; }
            public gamma Field3 { get; set; }
        }
        private List<float> Read_Frequencies_fromCSV(string path,int start_row, int start_column)
        {
            var PrimaryList = ReadFile<ThreeFildsClass<string, string, string>>(path);


            List<float> result_float = new List<float>();
           // List<string> result_string = new List<string>();
           // result_string = TryParseList<ThreeFildsClass<string,string,string>, string>(PrimaryList, start_column);

            try
            {
               // result_float = TryParseList<ThreeFildsClass<string, string, string>, float>(PrimaryList, start_column);
              /*  if (result_float == null) */throw new Exception();
            }
            catch
            {
                try
                {
                    int start_el = start_row;
                    var datalist = PrimaryList.GetRange(start_el, PrimaryList.Count - start_el);
                    result_float = TryParseList<ThreeFildsClass<string, string, string>, float>(datalist, start_column);
                }
                catch
                {

                }
            }
            return result_float;

        }
        public static List<T> ReadFile<T>(string FullPath) where T: FieldsClass
        {
            var returnlist = new List<T>();
            try
            {
                string encoding = string.Empty;
                Encoding spec_en;
                Stream fs = new FileStream(FullPath, FileMode.Open);
                using (StreamReader sr = new StreamReader(fs, true))
                {
                    spec_en = sr.CurrentEncoding;
                    encoding = sr.CurrentEncoding.ToString();
                }


                using (var Str_reader = new StreamReader(FullPath, Encoding.Default))
                {
                    using (CsvReader csvReader = new CsvReader(Str_reader, System.Globalization.CultureInfo.InvariantCulture))
                    {
                        //у большинства подобных файлов отсутствует заголовок. Укажем это
                        csvReader.Configuration.HasHeaderRecord = false;
                        // указываем используемый разделитель
                        csvReader.Configuration.Delimiter = ";";
                        // получаем строки
                       // bool a = csvReader.Read();
                      
                        var data = csvReader.GetRecords<T>();
                        returnlist = csvReader.GetRecords<T>().ToList();

                    }
                }
            }
            catch (Exception e)
            {
                var a = e.Message;
            }
            return returnlist;
        }
        public static List<FinalType> TryParseList<InnerType,FinalType>(List<InnerType> List2Parse,int colomn2parse = 0) where InnerType: FieldsClass
        {
            List<FinalType> result = new List<FinalType>();
            try
            {
                if (typeof(FinalType).Equals(typeof(String)))
                {
                    foreach (dynamic el in List2Parse) //подумать над еще большей универсальностью
                    {
                        if(colomn2parse==0) result.Add((FinalType)el.Field1);
                        else if (colomn2parse ==1) result.Add((FinalType)el.Field2);
                        else if (colomn2parse == 2) result.Add((FinalType)el.Field3);
                    }
                }
                else if (typeof(FinalType).Equals(typeof(float)))
                {
                    foreach (dynamic el in List2Parse) //подумать над еще большей универсальностью
                    {
                        double alk = 0;

                        //приду через 30 минут
                        

                        if (colomn2parse == 0)
                        {
                            double.TryParse((el.Field1.Replace(',', '.')), System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.InvariantCulture, out alk);
                        }
                        else if (colomn2parse == 1)
                        {
                            double.TryParse((el.Field2.Replace(',', '.')), System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.InvariantCulture, out alk);
                        }
                        else if (colomn2parse == 2)
                        {
                            double.TryParse((el.Field3.Replace(',', '.')), System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.InvariantCulture, out alk);
                        }
                        dynamic data = alk;
                        result.Add((FinalType)data);
                    }
                }
                
            }
            catch(Exception exc)
            {
                return (result = null);
            }
            return result;
        }
    }
}
