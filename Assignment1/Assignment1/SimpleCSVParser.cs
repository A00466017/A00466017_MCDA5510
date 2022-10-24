using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;
using CsvHelper;
using CsvHelper.Configuration.Attributes;
using Microsoft.VisualBasic.FileIO;

using static System.Net.WebRequestMethods;
//using Dirwalker;

namespace Assignment1
{
    public class SimpleCSVParser
    {


        //public static void Main(String[] args)
        //{
        //    //SimpleCSVParser parser = new SimpleCSVParser();
        //    //parser.parse(@"/Users/abhiv/Desktop/Abhi/A00466017_MCDA5510/Assignment1/Assignment1/CustomerData1.csv");
        //    //DirWalker fw = new DirWalker();

        //    using var streamReader = new StreamReader("../../../CustomerData1.csv");
        //    {
        //        using var streamWriter = new StreamWriter("../../../finalFile.csv");
        //        {
        //            var csvreader = new CsvReader(streamReader, CultureInfo.InvariantCulture);
        //            var csvwriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);
        //            var oprecords = csvreader.GetRecords<Customer>();
        //            csvwriter.WriteRecords(oprecords);
        //        }

        //    }

        //}

        public void parse(String fileName)
        {
            try
            {
                using (TextFieldParser parser = new TextFieldParser(fileName))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(", ");
                    while (!parser.EndOfData)
                    {
                        //Process row
                        string[] fields = parser.ReadFields();
                        foreach (string field in fields)
                        {
                            Console.WriteLine(field);
                        }
                    }
                }

            }
            catch (IOException ioe)
            {
                Console.WriteLine(ioe.StackTrace);
            }

        }
    }
    public class Customer
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
