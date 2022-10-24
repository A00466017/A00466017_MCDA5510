using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using log4net;

namespace Assignment1
{

    public class Final_Csv_Reader
    {
        int skiprec = 0;
        int valrec = 0;
        List<Customerwrite> records = new List<Customerwrite>();
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public List<Customerwrite> walk(String path)
        {

            string[] list = Directory.GetDirectories(path);

            foreach (string dirpath in list)
            {
                if (Directory.Exists(dirpath))
                {
                    walk(dirpath);
                    Console.WriteLine("Dir:" + dirpath);
                }
            }
            string[] fileList = Directory.GetFiles(path);
            {

                foreach (string filepath in fileList)
                {
                    var array = filepath.Split(@"\");
                    Console.WriteLine("File:" + filepath);
                    string date = array[4] + "/" + array[5] + "/" + array[6];
                    using var streamReader = new StreamReader(filepath);



                    var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HasHeaderRecord = false,
                        MissingFieldFound = null
                    };
                    using (var csvreader = new CsvReader(streamReader, config))
                    {
                        var oprecords = csvreader.GetRecords<Customerread>().Skip(1);


                        foreach (var i in oprecords)
                        {
                            if (i.fName != "" && i.lName != "" && i.streetnum != "" && i.street != "" && i.city != "" && i.province != "" && i.postalcode != "" && i.country != "" && i.phonenum != "" && i.email != "")
                            {
                                Customerwrite checkempty = new Customerwrite();
                                checkempty.fName = i.fName;
                                checkempty.lName = i.lName;
                                checkempty.streetnum = i.streetnum;
                                checkempty.street = i.street;
                                checkempty.city = i.city;
                                checkempty.province = i.province;
                                checkempty.postalcode = i.postalcode;
                                checkempty.country = i.country;
                                checkempty.phonenum = i.phonenum;
                                checkempty.email = i.email;
                                checkempty.Date = date;
                                records.Add(checkempty);
                                valrec = valrec + 1;
                            }
                            else { skiprec = skiprec + 1; }
                        }



                    }
                }
            }
            return records;
        }

        public void writeInCsv(List<Customerwrite> records)
        {
            using var streamWriter = new StreamWriter(@"..\..\..\ProgAssign1\Output\finalFile.csv", true);
            var csvwriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);
            csvwriter.WriteRecords(records);
        }


        public static void Main(string[] args)
        {
            var datnow = DateTime.Now.ToLongTimeString();
            log4net.Config.XmlConfigurator.Configure();
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            Final_Csv_Reader fw = new Final_Csv_Reader();


            {
                try
                {
                    var newRecords = fw.walk(@"..\..\..\Sample Data\");
                    fw.writeInCsv(newRecords);
                    var endnow = DateTime.Now.ToLongTimeString();
                    log.Info("--------LOG ENTRY---------");
                    log.Info("Code started execution at : " + datnow);
                    log.Info("Code execution time" + " - " + watch.ElapsedMilliseconds + "ms");
                    log.Info("Valid Rows - " + fw.valrec);
                    log.Info("Skipped Rows - " + fw.skiprec);
                    log.Info("Code stopped execution at : " + endnow);
                    log.Info("------------------------------");
                    //writer.Flush();
                }
                catch (DirectoryNotFoundException)
                {
                    log.Error("Directory Not Found");
                }
            }

            watch.Stop();



        }

    }
    public class Customerread
    {
        [Name("First Name")]
        [Index(0)]
        public string fName { get; set; }
        [Name("Last Name")]
        public string lName { get; set; }
        [Name("Street Number")]
        public string streetnum { get; set; }
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
    public class Customerwrite
    {
        [Name("First Name")]
        public string fName { get; set; }
        [Name("Last Name")]
        public string lName { get; set; }
        [Name("Street Number")]
        public string streetnum { get; set; }
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
        [Name("Date")]
        public string Date { get; set; }
    }
}
