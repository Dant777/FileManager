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
            Console.WindowHeight = 40;

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            DrawingClass.PrintSquareDoubelLine(0, 0, Console.WindowWidth, Console.WindowHeight/2, "Title");
            DrawingClass.PrintSquareDoubelLine(0, (Console.WindowHeight / 2), Console.WindowWidth, Console.WindowHeight / 2);
            Console.ReadKey();
        }
    }
}
