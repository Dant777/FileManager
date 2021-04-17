using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    /// <summary>
    /// Статический класс записи ошибок в файл
    /// </summary>
    public static class ExceptionWriter
    {
        /// <summary>
        /// Запись ошибок в файл
        /// </summary>
        /// <param name="txtException">Текст ошибки</param>
        public static void Write(string txtException)
        {
            string path = @"errors";
            if (!Directory.Exists(path))
            {
                DirectoryInfo dirInf = new DirectoryInfo(path);
                dirInf.Create();
            }

            string fileName = $"random_name_exception_{DateTime.Now.Date.ToShortDateString()}.txt";
            string fullFileName = path + "\\" + fileName;
            string fullTxtException = $"{DateTime.Now.ToShortTimeString()} - {txtException} \n";
            if (File.Exists(fullFileName))
            {
                File.AppendAllText(fullFileName, fullTxtException);
            }
            else
            {
                File.WriteAllText(fullFileName, fullTxtException);
            }

        }

    }
}
