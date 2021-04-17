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

            //string root = @"C:\SCAD Soft";


            //var files = Directory.GetFiles(root, ".");
            //Console.WriteLine(files.Length);
            //foreach (var item in files)
            //{
            //    Console.WriteLine("\n" + Path.GetFileName(item));
            //}

            Console.ReadKey();
        }
        public static long DirSize(DirectoryInfo d)
        {
            long Size = 0;
            // Add file sizes.
            FileInfo[] fis = d.GetFiles();
            foreach (FileInfo fi in fis)
            {
                Size += fi.Length;
                
            }
            // Add subdirectory sizes.
            DirectoryInfo[] dis = d.GetDirectories();
            foreach (DirectoryInfo di in dis)
            {
                Size += DirSize(di);
                
            }
            return Size;
        }
    }
}


