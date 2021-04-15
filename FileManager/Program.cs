using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileManager
{
    class Program
    {
        static void Main(string[] args)
        {

            WindowClass window = new WindowClass();

            window.StartFMWindows();

            //string root = @"C:\Users\Dant\Downloads";


            //var files = Directory.GetFiles(root, ".");
            //Console.WriteLine(files.Length);
            //foreach (var item in files)
            //{
            //    Console.WriteLine("\n" + Path.GetFileName(item));
            //}

            //Console.ReadKey();
        }
    }
}


