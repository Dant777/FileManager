using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{


    public static class DrawingClass
    {
        /// <summary>
        /// Рисует в консоли квадратную рамку двойными линиями
        /// </summary>
        /// <param name="startPositionX">Начальная координата по X</param>
        /// <param name="startPositionY">Начальная координата по У</param>
        /// <param name="sizeSquareX">Длина по Х</param>
        /// <param name="sizeSquareY">Длина по У</param>
        static public void PrintSquareDoubelLine(
            int startPositionX, 
            int startPositionY, 
            int sizeSquareX, 
            int sizeSquareY)
        {
            int corectSizeX = startPositionX + sizeSquareX;
            int corectSizeY = startPositionY + sizeSquareY;
            //Левая сторона
            Console.SetCursorPosition(startPositionX, startPositionY);
            Console.Write((char)DoubleLine.TopLeft);
            for (int i = startPositionY + 1; i < corectSizeY - 1; i++)
            {
                Console.SetCursorPosition(startPositionX, i);
                Console.Write((char)DoubleLine.LineVertical);
            }
            Console.SetCursorPosition(startPositionX, corectSizeY - 1);
            Console.Write((char)DoubleLine.BottomLeft);

            //Правая сторона
            Console.SetCursorPosition(corectSizeX - 1, startPositionY);
            Console.Write((char)DoubleLine.TopRight);
            for (int i = startPositionY + 1; i < corectSizeY - 1; i++)
            {
                Console.SetCursorPosition(corectSizeX - 1, i);
                Console.Write((char)DoubleLine.LineVertical);
            }
            Console.SetCursorPosition(corectSizeX - 1, corectSizeY - 1);
            Console.Write((char)DoubleLine.BottomRight);

            //Низ
            for (int i = 1; i < corectSizeX - 1; i++)
            {
                Console.SetCursorPosition(i, corectSizeY - 1);
                Console.Write((char)DoubleLine.LineHorizontal);
            }

            //Верх
            for (int i = 1; i < corectSizeX - 1; i++)
            {
                Console.SetCursorPosition(i, startPositionY);
                Console.Write((char)DoubleLine.LineHorizontal);
            }
        }

        /// <summary>
        /// Рисует в консоли квадратную рамку двойными линиями с названием рамки
        /// </summary>
        /// <param name="startPositionX">Начальная координата по X</param>
        /// <param name="startPositionY">Начальная координата по У</param>
        /// <param name="sizeSquareX">Длина по Х</param>
        /// <param name="sizeSquareY">Длина по У</param>
        /// <param name="title">Название рамки</param>
        static public void PrintSquareDoubelLine(
            int startPositionX,
            int startPositionY,
            int sizeSquareX,
            int sizeSquareY,
            string title)
        {
            int corectSizeX = startPositionX + sizeSquareX;
            int corectSizeY = startPositionY + sizeSquareY;

        
            //Левая сторона
            Console.SetCursorPosition(startPositionX, startPositionY);
            Console.Write((char)DoubleLine.TopLeft);
            for (int i = startPositionY + 1; i < corectSizeY - 1; i++)
            {
                Console.SetCursorPosition(startPositionX, i);
                Console.Write((char)DoubleLine.LineVertical);
            }
            Console.SetCursorPosition(startPositionX, corectSizeY - 1);
            Console.Write((char)DoubleLine.BottomLeft);

            //Правая сторона
            Console.SetCursorPosition(corectSizeX - 1, startPositionY);
            Console.Write((char)DoubleLine.TopRight);
            for (int i = startPositionY + 1; i < corectSizeY - 1; i++)
            {
                Console.SetCursorPosition(corectSizeX - 1, i);
                Console.Write((char)DoubleLine.LineVertical);
            }
            Console.SetCursorPosition(corectSizeX - 1, corectSizeY - 1);
            Console.Write((char)DoubleLine.BottomRight);

            //Низ
            for (int i = 1; i < corectSizeX - 1; i++)
            {
                Console.SetCursorPosition(i, corectSizeY - 1);
                Console.Write((char)DoubleLine.LineHorizontal);
            }

            string squareTitle = $" {title} ";
            int startTitleIndex = (corectSizeX / 2) - (squareTitle.Length / 2);
            int endTitleIndex = (corectSizeX / 2) + (squareTitle.Length / 2);
            //Верх
            for (int i = 1; i < corectSizeX - 1; i++)
            {
                if(i == startTitleIndex && i <= endTitleIndex)
                {
                    Console.SetCursorPosition(i, startPositionY);
                    Console.Write(squareTitle);
                } 
                else if (i > startTitleIndex && i <= endTitleIndex)
                {
                    continue;
                }
                else
                {
                    Console.SetCursorPosition(i, startPositionY);
                    Console.Write((char)DoubleLine.LineHorizontal);
                }
              
            }
        }
    }
}
