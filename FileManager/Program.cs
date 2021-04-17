
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
            //DrawingClass.PrintSquareLine(0, 0, 10, 5);
            Console.ReadKey();
        }
        
        
    }
}


