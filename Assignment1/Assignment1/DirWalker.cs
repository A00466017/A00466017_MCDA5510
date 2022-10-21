using System;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;

namespace Assignment1
{


    public class DirWalker
    {

        public void walk(String path)
        {
            //var config = new CsvConfiguration(System.Globalization.CultureInfo.InvariantCulture);
            //{
            //    HasHeaderRecord = true;
            //    HeaderValidated = null;
            //    MissingFieldFound = null;
            //    IgnoreBlankLines = true;

            //};
            string[] list = Directory.GetDirectories(path);


            if (list == null) return;

            foreach (string dirpath in list)
            {
                if (Directory.Exists(dirpath))
                {
                    walk(dirpath);
                    Console.WriteLine("Dir:" + dirpath);
                }
            }
            string[] fileList = Directory.GetFiles(path);
            foreach (string filepath in fileList)
            { 
                //var array = filepath.Split(@"\");
                Console.WriteLine("File:" + filepath);
                //Console.WriteLine("Date :" + array[4] +'-'+ array[5] +'-'+ array[6]);
                //var oprecords;
                using var streamReader = new StreamReader(filepath);

                {
                    using var streamWriter = new StreamWriter("../../../finalFile.csv",true);
                    {
                        var config = new CsvConfiguration(System.Globalization.CultureInfo.InvariantCulture);
                        var csvreader = new CsvReader(streamReader, config);
                        
                        var csvwriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);
                        config.HasHeaderRecord = false;
                        config.MissingFieldFound = null;
                        var oprecords = csvreader.GetRecords<dynamic>();

                        csvwriter.WriteRecords(oprecords);
                        //foreach (var record in oprecords)
                        //{
                        //    record.NewColumn = "New Item";
                        //}
                        //using (var csvWriter = new CsvWriter(Console.Out, CultureInfo.InvariantCulture))
                        //{
                        //    csvWriter.WriteRecords(oprecords);
                        //}
                    }
                }
            }
        }


        public static void Main(string[] args)
        {
            DirWalker fw = new DirWalker();
            //fw.walk(@"Users/abhiv/Desktop/Abhi/MCDA5510_Assignments/Assignment1/Assignment1/Sample Data");
            fw.walk(@"..\..\..\Sample Data\");

        }
    }
    public class Customer1
    {
        [Name("First Name")]
        public string fName { get; set; }
        [Name("Last Name")]
        public string lName { get; set; }
        [Name("Street Number")]
        public int streetnum { get; set; }
        [Name("Street")]
        public string street { get; set; }
        [Name("City")]
        public string city { get; set; }
        [Name("Province")]
        public string province { get; set; }
        [Name("Postal Code")]
        public string postalcode { get; set; }
        [Name("Country")]
        public string country { get; set; }
        [Name("Phone Number")]
        public string phonenum { get; set; }
        [Name("email Address")]
        public string email { get; set; }
    }
}
