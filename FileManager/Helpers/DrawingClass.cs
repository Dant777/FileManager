﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{


    public static class DrawingClass
    {
        /// <summary>
        /// Рисует в консоли квадратную рамку линиями
        /// </summary>
        /// <param name="startPositionX">Начальная координата по X</param>
        /// <param name="startPositionY">Начальная координата по У</param>
        /// <param name="sizeSquareX">Длина по Х</param>
        /// <param name="sizeSquareY">Длина по У</param>
        static public void PrintSquareLine(
            int startPositionX,
            int startPositionY,
            int sizeSquareX,
            int sizeSquareY)
        {
            int corectSizeX = startPositionX + sizeSquareX;
            int corectSizeY = startPositionY + sizeSquareY;
            //Левая сторона
            Console.SetCursorPosition(startPositionX, startPositionY);
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write((char)Line.TopLeft);
            for (int i = startPositionY + 1; i < corectSizeY - 1; i++)
            {
                Console.SetCursorPosition(startPositionX, i);
                Console.Write((char)Line.LineVertical);
            }
            Console.SetCursorPosition(startPositionX, corectSizeY - 1);
            Console.Write((char)Line.BottomLeft);

            //Правая сторона
            Console.SetCursorPosition(corectSizeX - 1, startPositionY);
            Console.Write((char)Line.TopRight);
            for (int i = startPositionY + 1; i < corectSizeY - 1; i++)
            {
                Console.SetCursorPosition(corectSizeX - 1, i);
                Console.Write((char)Line.LineVertical);
            }
            Console.SetCursorPosition(corectSizeX - 1, corectSizeY - 1);
            Console.Write((char)Line.BottomRight);

            //Низ
            for (int i = startPositionX + 1; i < corectSizeX - 1; i++)
            {
                Console.SetCursorPosition(i, corectSizeY - 1);
                Console.Write((char)Line.LineHorizontal);
            }

            //Верх
            for (int i = startPositionX + 1; i < corectSizeX - 1; i++)
            {
                Console.SetCursorPosition(i, startPositionY);
                Console.Write((char)Line.LineHorizontal);
            }
        }
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
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
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
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
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

        /// <summary>
        /// Печать текста в консоле в заданной позиции
        /// </summary>
        /// <param name="txt">Текст</param>
        /// <param name="startPositionX">Начальная координата по X</param>
        /// <param name="startPositionY">Начальная координата по У</param>
        static public void PrintString(string txt, int startPositionX, int startPositionY)
        {
            Console.SetCursorPosition(startPositionX, startPositionY);
            Console.Write(txt);
        }

        /// <summary>
        /// Печать списка
        /// </summary>
        /// <param name="x">начальная координата по Х</param>
        /// <param name="y">начальная координата по У</param>
        /// <param name="selectedDir">Список для пичати</param>
        /// <param name="itemIndex">Индекс для выделения выбора</param>
        static public void PrintFileOrDir(int x, int y, List<string> selectedDir, int itemIndex)
        {
 

            for (int i = 0; i < selectedDir.Count; i++)
            {
                if (i == itemIndex)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                PrintString(selectedDir[i], x, y + i);
            }

        }
        /// <summary>
        /// Печать списка
        /// </summary>
        /// <param name="x">начальная координата по Х</param>
        /// <param name="y">начальная координата по У</param>
        /// <param name="selectedDir">Список для пичати</param>
        /// <param name="itemIndex">Индекс для выделения выбора</param>
        /// <param name="countController">Огранечитель вывода списка</param>
        static public void PrintFileOrDir(int x, int y, List<string> selectedDir, int itemIndex, CountControllerInWin countController)
        {

            int countY = 0;
            for (int i = countController.StartIndex; i < selectedDir.Count; i++)
            {
                if(i > countController.EndIndex)
                {
                    break;
                }

                if (i == itemIndex)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                PrintString(selectedDir[i], x, y + countY);
                countY++;
            }

        }

        /// <summary>
        /// Печать в консоли списка по координатам
        /// </summary>
        /// <param name="x">начальная координата по Х</param>
        /// <param name="y">начальная координата по У</param>
        /// <param name="infoList">Список для печати</param>
        static public void PrintList(int x, int y, List<string> infoList)
        {

            for (int i = 0; i < infoList.Count; i++)
            {
           
                PrintString(infoList[i], x, y + i);
            }

        }

        /// <summary>
        /// Печатает кнопки и располагает по длине окна
        /// </summary>
        /// <param name="x">Стартовое положение по Х</param>
        /// <param name="y">Стартовое положение по У</param>
        static public void PrintButtons(int x, int y)
        {

            string[] buttonsText = new string[] 
            { 
                "F1 - Info", 
                "F2 - Move", 
                "F3 - Copy", 
                "F4 - Del", 
                "F5 - Exit",
                "F8 - Error",
                "Esc - Cansel"
            };

            int buttonSizeX = 15;
            int spaceSize = (Console.WindowWidth - (buttonSizeX * buttonsText.Length)) / (buttonsText.Length + 1);

            for (int i = 1; i <= buttonsText.Length; i++)
            {
                int startPosX = x + (buttonSizeX * (i - 1)) + (spaceSize * i);
                PrintButton(buttonsText[i-1], startPosX, y, buttonSizeX);
            }

        }

        /// <summary>
        /// Печать кнопку с текстом
        /// </summary>
        /// <param name="txt">Текст в кнопки</param>
        /// <param name="x">Стартовое положение по Х</param>
        /// <param name="y">Стартовое положение по У</param>
        /// <param name="buttonSizeX">Размер кнопки по Х</param>
        /// <param name="buttonSizeY">Размер кнопки по У</param>
        static public void PrintButton(string txt, int x, int y, int buttonSizeX = 12, int buttonSizeY = 3 )
        {
           
            int spaceSize = (Console.WindowWidth - (buttonSizeX * 5)) / 6;

            PrintSquareLine(x, y, buttonSizeX, buttonSizeY);

            int txtOffset = (buttonSizeX - txt.Length) / 2;
            PrintString(txt,  x + 1 + txtOffset, y + buttonSizeY / 2);
        }
    }
}
