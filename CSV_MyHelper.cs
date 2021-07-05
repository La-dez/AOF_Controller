using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using LDZ_Code;
using static LDZ_Code.ServiceFunctions;
using System.IO;

namespace AOF_Controller
{
    public class CSV_MyHelper
    {
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
        public static List<float> Read_Frequencies_fromCSV(string path, int start_row, int start_column)
        {
            var PrimaryList = ReadFile<ThreeFildsClass<string, string, string>>(path);


            List<float> result_float = new List<float>();
            // List<string> result_string = new List<string>();
            // result_string = TryParseList<ThreeFildsClass<string,string,string>, string>(PrimaryList, start_column);

            try
            {
                // result_float = TryParseList<ThreeFildsClass<string, string, string>, float>(PrimaryList, start_column);
                /*  if (result_float == null) */
                throw new Exception();
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
        public static List<double> Read_WLFunc_fromCSV(string path, int start_row, int start_column)
        {
            var PrimaryList = ReadFile<TwoFildsClass<string, string>>(path);


            List<double> result_float = new List<double>();

            try
            {
                throw new Exception();
            }
            catch
            {
                try
                {
                    int start_el = start_row;
                    var datalist = PrimaryList.GetRange(start_el, PrimaryList.Count - start_el);
                    result_float = TryParseList<TwoFildsClass<string, string>, double>(datalist, start_column);
                }
                catch
                {

                }
            }
            return result_float;
        }
        public static List<T> ReadFile<T>(string FullPath) where T : FieldsClass
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
        public static void WriteFile<T>(string FullPath,List<T> object_towrite) where T : FieldsClass
        {         
            using (var writer = new StreamWriter(FullPath))
            using (var csvWriter = new CsvWriter(writer, System.Globalization.CultureInfo.InvariantCulture))
            {
                csvWriter.Configuration.HasHeaderRecord = false;
                // указываем используемый разделитель
                csvWriter.Configuration.Delimiter = ";";
                csvWriter.WriteRecords(object_towrite);
            }
        }

        public static void Write_FreqData_tofile(string FullPath, List<ThreeFildsClass<string, string, string>> object_towrite)
        {
            WriteFile(FullPath, object_towrite);
        }
        public static List<FinalType> TryParseList<InnerType, FinalType>(List<InnerType> List2Parse, int colomn2parse = 0) where InnerType : FieldsClass
        {
            List<FinalType> result = new List<FinalType>();
            try
            {
                if (typeof(FinalType).Equals(typeof(String)))
                {
                    foreach (dynamic el in List2Parse) //подумать над еще большей универсальностью
                    {
                        if (colomn2parse == 0) result.Add((FinalType)el.Field1);
                        else if (colomn2parse == 1) result.Add((FinalType)el.Field2);
                        else if (colomn2parse == 2) result.Add((FinalType)el.Field3);
                    }
                }
                else if (typeof(FinalType).Equals(typeof(float)) || typeof(FinalType).Equals(typeof(double)))
                {
                    foreach (dynamic el in List2Parse) //подумать над еще большей универсальностью
                    {
                        double alk = 0;
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
            catch (Exception exc)
            {
                return (result = null);
            }
            return result;
        }
    }
}
