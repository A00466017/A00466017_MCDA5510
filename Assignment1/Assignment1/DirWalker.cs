using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;

namespace Assignment1
{

    public class DirWalker
    {
        int skiprec = 0;
        int valrec = 0;
        List<Customerwrite> records = new List<Customerwrite>();

        public List<Customerwrite> walk(String path)
        {

            string[] list = Directory.GetDirectories(path);


            if (list == null) return null;

            foreach (string dirpath in list)
            {
                if (Directory.Exists(dirpath))
                {
                    walk(dirpath);
                    Console.WriteLine("Dir:" + dirpath);
                }
            }
            string[] fileList = Directory.GetFiles(path);
            if (fileList != null)
            {

                /*List<Customerwrite> records = new List<Customerwrite>();*/

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
        //Console.WriteLine("Skipped Rows - " + skiprec);

        public void writeInCsv(List<Customerwrite> records)
        {
            using var streamWriter = new StreamWriter("../../../finalFile.csv", true);
            var csvwriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);
            csvwriter.WriteRecords(records);
        }

        public static void Log(string logMessage, int value, TextWriter w)
        {
            w.Write("\r\nLog Entry : ");
            w.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
            w.WriteLine("  :");
            w.WriteLine($"  :{logMessage}");
            w.WriteLine("-------------------------------");
        }

        public static void DumpLog(StreamReader r)
        {
            string line;
            while ((line = r.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
        public static void Main(string[] args)
        {
            var datnow = DateTime.Now.ToLongTimeString();
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            DirWalker fw = new DirWalker();
            var newRecords = fw.walk(@"..\..\..\Sample Data\");
            fw.writeInCsv(newRecords);
            watch.Stop();

            using (StreamWriter writer = new StreamWriter(@"../../../Log.txt", true))
            {
                var endnow = DateTime.Now.ToLongTimeString();
                writer.WriteLine("--------LOG ENTRY---------");
                writer.WriteLine("Code started execution at : " + datnow);
                writer.WriteLine("Code execution time" + " - " + watch.ElapsedMilliseconds + "ms");
                writer.WriteLine("Valid Rows - " + fw.valrec);
                writer.WriteLine("Skipped Rows - " + fw.skiprec);
                writer.WriteLine("Code stopped execution at : " + endnow);
                writer.WriteLine("------------------------------");
                writer.Flush();
            }

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
