using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;

namespace Assignment1
{


    public class DirWalker
    {

        public void walk(String path)
        {

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
            int skiprec = 0;
            List<Customerwrite> records = new List<Customerwrite>();
            foreach (string filepath in fileList)
            { 
                var array = filepath.Split(@"\");
                Console.WriteLine("File:" + filepath);
                var date =  array[6]+"/"+array[5]+"/"+array[4];
                using var streamReader = new StreamReader(filepath);
               
                {
                   // using var streamWriter = new StreamWriter("../../../finalFile.csv",true);
                    
                    {
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
                                if (i.fName!="" && i.lName != "" && i.streetnum != "" && i.street != "" && i.city != "" && i.province != "" && i.postalcode != "" && i.country != "" && i.phonenum != "" && i.email != "")
                                {
                                    Customerwrite checkempty=new Customerwrite();
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
                                }
                                else { skiprec++; }
                            }

                            
                        }

                        

                    }
                }
            }
            using var streamWriter = new StreamWriter("../../../finalFile.csv",true);
            var csvwriter = new CsvWriter(streamWriter,CultureInfo.InvariantCulture);
            csvwriter.WriteRecords(records);
        }


        public static void Main(string[] args)
        {
            DirWalker fw = new DirWalker();
            //fw.walk(@"Users/abhiv/Desktop/Abhi/MCDA5510_Assignments/Assignment1/Assignment1/Sample Data");
            fw.walk(@"..\..\..\Sample Data\");

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
