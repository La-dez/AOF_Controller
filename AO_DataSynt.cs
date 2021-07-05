using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AO_Lib;
using LDZ_Code;
using System.IO;

namespace AOF_Controller
{
    public partial class AO_DataSynt : Form
    {
        double[] WLs_val_read;
        double[] WLs_magnitudes_read;

        double[] WLs_val_synt;
        double[] WLs_magnitudes_synt;

        double[] Freqs_val;
        double[] Freqs_magnitudes;

        string Curves_path;
        string Curves_filename_to_write;

        Action<string> Throw_FileName;
        public AO_DataSynt(Action<string> GetFileNameOnClosing)
        {
            InitializeComponent();
            Throw_FileName = GetFileNameOnClosing;
        }
        private void AO_DataSynt_Load(object sender, EventArgs e)
        {
            L_RFPower.Text = "";
            L_WLPtsCount.Text = "";
        }
        private void B_BrowseCurve_Click(object sender, EventArgs e)
        {
            var filepath = ServiceFunctions.Files.OpenFile("Select AOCurve file", false, ".csv");

            if (String.IsNullOrEmpty(filepath)) return;
            L_PathToCurve.Text = filepath;
            Curves_path = System.IO.Path.GetDirectoryName(filepath);
            List<double> WLs = CSV_MyHelper.Read_WLFunc_fromCSV(filepath, 1, 0);
            List<double> Magnitudes = CSV_MyHelper.Read_WLFunc_fromCSV(filepath, 1, 1);
            L_WLPtsCount.Text = WLs.Count.ToString();

            WLs_val_read = WLs.ToArray();
            WLs_magnitudes_read = Magnitudes.ToArray();
        }

        private void B_Calculate_Click(object sender, EventArgs e)
        {
            double GammaInDeg = (double)NUD_AO_EnAngle.Value;
            double GammaOutDeg = (double)NUD_AO_OutAngle.Value;
            double CellSizeMM = (double)NUD_AO_SoundSideSize.Value;
            double PiezoLengthMM = (double)NUD_AO_PiezoLength.Value;
            double PiezoOffsetMM = (double)NUD_AO_PiezoOffset.Value;
            double PiezoWidthMM = (double)NUD_AO_PiezoWidth.Value;
            double CutAngleDeg = (double)NUD_AO_CutAngle.Value;

            int Freqs_Count = (int)NUD_FreqsCount.Value;
            double Freqs_Period = (double)NUD_FreqPeriod.Value;
            AO_Cell AO_Cell_current = new AO_Cell(GammaInDeg, GammaOutDeg, CellSizeMM, PiezoLengthMM, PiezoWidthMM, PiezoOffsetMM, CutAngleDeg);

            var FreqMass_synt = AO_Cell_current.CalculateFreqs_via_AP(WLs_val_read, WLs_magnitudes_read, Freqs_Count, Freqs_Period);
            //обновление данных в контролах
            L_RFPower.Text = FreqMass_synt.RFPower.ToString();

            //Вычленение вычисленных данных
            Freqs_val = FreqMass_synt.Freqs;
            Freqs_magnitudes = FreqMass_synt.Magnitudes;
            double[] Freqs_times = FreqMass_synt.Times;
            double Freqs_timestep = FreqMass_synt.Timestep;
            double Freqs_RFPower = FreqMass_synt.RFPower;
            int Freqs_count = FreqMass_synt.Count;

         
            //Записываем данные о массиве частот в файл
            Curves_filename_to_write = System.IO.Path.Combine(Curves_path, "Freqs_synt.csv");
            if (File.Exists(Curves_filename_to_write)) File.Delete(Curves_filename_to_write);

            List<CSV_MyHelper.ThreeFildsClass<string, string, string>> DataToWrite = new List<CSV_MyHelper.ThreeFildsClass<string, string, string>>();
            var Header = new CSV_MyHelper.ThreeFildsClass<string, string, string>();
            Header.Field1 = "t, sec";
            Header.Field2 = "f, MHz";
            Header.Field3 = "A (relative to " + Freqs_RFPower.ToString() + " [W] )";
            DataToWrite.Add(Header);
            
            for (int i=0;i< Freqs_count;i++)
            {
                CSV_MyHelper.ThreeFildsClass<string, string, string> DataHolder = new CSV_MyHelper.ThreeFildsClass<string, string, string>();
                DataHolder.Field1 = Freqs_times[i].ToString();
                DataHolder.Field2 = Freqs_val[i].ToString();
                DataHolder.Field3 = Freqs_magnitudes[i].ToString();
                DataToWrite.Add(DataHolder);
            }
            CSV_MyHelper.Write_FreqData_tofile(Curves_filename_to_write, DataToWrite);

            //Вычисляем данные для новой аппаратной функции
            double WLs_val_synt_WLStep = 0.001;
            int WLs_val_synt_count = (int)Math.Round((WLs_val_read.Max() - WLs_val_read.Min()) / WLs_val_synt_WLStep);
            double WLs_val_synt_WLStart = WLs_val_read.Min();
            //запуск вычисления прямой задачи для сравнения результатов
            var WLMass_synt = AO_Cell_current.CalculateAP_via_Freqs(Freqs_val, Freqs_magnitudes, Freqs_Period, Freqs_RFPower, WLs_val_synt_WLStart, WLs_val_synt_count, WLs_val_synt_WLStep);
            WLs_val_synt = WLMass_synt.WLs;
            WLs_magnitudes_synt = WLMass_synt.Magnitudes;
        }

        private void B_AOCell_loadtest_Click(object sender, EventArgs e)
        {
            NUD_AO_EnAngle.Value = 80.51M;
            NUD_AO_OutAngle.Value = 96.51M;
            NUD_AO_SoundSideSize.Value = 23.3M;
            NUD_AO_PiezoLength.Value = 7;
            NUD_AO_PiezoWidth.Value = 8;
            NUD_AO_PiezoOffset.Value = 2.7M;
            NUD_AO_CutAngle.Value = 7;
        }

        private void AO_DataSynt_FormClosing(object sender, FormClosingEventArgs e)
        {
            Throw_FileName(Curves_filename_to_write);
        }
    }
}
