﻿using System;
using System.IO;
using CsvHelper;

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
            foreach (string filepath in fileList)
            {

                Console.WriteLine("File:" + filepath);
            }
        }

        public static void Main(string[] args)
        {
            DirWalker fw = new DirWalker();
            //fw.walk(@"Users/abhiv/Desktop/Abhi/MCDA5510_Assignments/Assignment1/Assignment1/Sample Data");
            fw.walk(@"../../../Sample Data");


        }
    }
}
