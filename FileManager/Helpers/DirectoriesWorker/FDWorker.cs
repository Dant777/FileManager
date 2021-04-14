using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    /// <summary>
    /// Класс работающий с дерикториями и файлами
    /// </summary>
    public static class FDWorker
    {
        
        /// <summary>
        /// Заполнение массива с полным путем дочерних папок и файлов
        /// </summary>
        /// <param name="root">полный путь родительской папки</param>
        /// <returns>Список полного пути дочерних папок</returns>
        public static List<string> GetDirectory(string root)
        {
            List<string> derictories = new List<string>();
            if (root == "" || root == string.Empty || root == null || root == "Disck")
            {
                derictories = Environment.GetLogicalDrives().ToList<string>();
            }   
            else
            {
                string parentRoot = "";
                if (Directory.GetParent(root) != null)
                {
                    parentRoot = Directory.GetParent(root).FullName;

                }
        
                derictories.Add(parentRoot);
                derictories.AddRange(Directory.GetDirectories(root).ToList<string>());

                var files = Directory.GetFiles(root, ".");
                if (files.Length != 0 && files != null)
                {
                    foreach (var item in files)
                    {
                        derictories.Add(Path.GetFullPath(item));
                    }
                }
            }

            return derictories;

        }

        /// <summary>
        /// Заполнение массива с именами дочерних папок и файлов
        /// </summary>
        /// <param name="root">полный путь родительской папки</param>
        /// <returns>Список имен дочерних папок</returns>
        public static List<string> GetDirectoryNames(string root)
        {
            
            List<string> derictoriesNames = new List<string>();
            if (root == "" || root == string.Empty || root == null)
            {
             
                derictoriesNames = Directory.GetLogicalDrives().ToList<string>();
            }

            else
            {
                derictoriesNames.Add("..");
                DirectoryInfo dir = new DirectoryInfo(root);
                foreach (var item in dir.GetDirectories())
                {
                    derictoriesNames.Add(item.Name);
                }

                var files = Directory.GetFiles(root, ".");
                if (files.Length != 0 && files != null)
                {
                    foreach (var item in files)
                    {
                        derictoriesNames.Add(Path.GetFileName(item));
                    }
                }
               
            }

            return derictoriesNames;
        }
    
        /// <summary>
        /// Удаление файла или папки
        /// </summary>
        /// <param name="path">Полный путь к файлу/папке</param>
        public static void DeleteFileOrDirectory(string path)
        {
            Directory.Delete(path, true);
        }
    }
}
