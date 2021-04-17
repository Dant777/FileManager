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
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            else if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }
            
        }

        /// <summary>
        /// Перемещение файлов/папки 
        /// </summary>
        /// <param name="sourceFolder">Перемещаемая папка/файл</param>
        /// <param name="destFolder">Путь куда перемещается папка/файл</param>
        public static void MoveFileOrDirectory(string sourceFolder, string destFolder)
        {
            if (File.Exists(sourceFolder))
            {
                CopyFile(sourceFolder, destFolder);
                DeleteFileOrDirectory(sourceFolder);
            }
            else if (Directory.Exists(sourceFolder))
            {
                CopyFolder(sourceFolder, destFolder);
                DeleteFileOrDirectory(sourceFolder);
            }
        }

        /// <summary>
        /// Копирование файлов/папки 
        /// </summary>
        /// <param name="sourceFolder">Копирование папка/файл</param>
        /// <param name="destFolder">Путь куда копированть папка/файл</param>
        public static void CopyFileOrDirectory(string sourceFolder, string destFolder)
        {
            if (File.Exists(sourceFolder))
            {
                CopyFile(sourceFolder, destFolder);
                
            }
            else if (Directory.Exists(sourceFolder))
            {
                CopyFolder(sourceFolder, destFolder);
               
            }
        }

        /// <summary>
        /// Информация о папке/файле
        /// </summary>
        /// <param name="path">Полный путь к папке/файлу</param>
        /// <returns>Список с информацией о папке/файле</returns>
        public static List<string> InfoFileOrDirectory(string path)
        {
            List<string> infoList = new List<string>();
            if (File.Exists(path))
            {
                FileInfo fileInfo = new FileInfo(path);
                infoList.Add($"Имя файла: {fileInfo.Name}");
                infoList.Add($"Размер файла: {fileInfo.Length * 0.001}kB");
                infoList.Add($"Дата создания: {fileInfo.CreationTime}");
                infoList.Add($"Дата изменения: {fileInfo.LastWriteTime}");
                

            }
            else if (Directory.Exists(path))
            {
                DirectoryInfo dirInfo = new DirectoryInfo(path);
                infoList.Add($"Имя папки: {dirInfo.Name}");
                infoList.Add($"Размер: {GetDirectorySize(dirInfo) * 0.001}kB");
                infoList.Add($"Дата создания: {dirInfo.CreationTime}");
            }

            return infoList;

        }
        /// <summary>
        /// Копирование папки
        /// </summary>
        /// <param name="sourceFolder">Перемещаемая папка/файл</param>
        /// <param name="destFolder">Путь куда перемещается папка/файл</param>
        static private void CopyFolder(string sourceFolder, string destFolder)
        {
   
            if (!Directory.Exists(destFolder))
                Directory.CreateDirectory(destFolder);
            string[] files = Directory.GetFiles(sourceFolder);
            foreach (string file in files)
            {
                string name = Path.GetFileName(file);
                string dest = Path.Combine(destFolder, name);
                File.Copy(file, dest);
            }
            string[] folders = Directory.GetDirectories(sourceFolder);
            foreach (string folder in folders)
            {
                string name = Path.GetFileName(folder);
                string dest = Path.Combine(destFolder, name);
                CopyFolder(folder, dest);
            }

        }
        /// <summary>
        /// Копирование файла
        /// </summary>
        /// <param name="sourceFolder">Перемещаемая папка/файл</param>
        /// <param name="destFolder">Путь куда перемещается папка/файл</param>
        static private void CopyFile(string sourceFolder, string destFolder)
        {
            string fileName = Path.GetFileName(sourceFolder);
            string copyFullFileName = destFolder + fileName;

            if (File.Exists(copyFullFileName))
            {
                copyFullFileName += " - копия";
            }

            File.Copy(sourceFolder, copyFullFileName);
        }

        /// <summary>
        /// Получение размера каталога
        /// </summary>
        /// <param name="dirInfo">информация о каталоге</param>
        /// <returns>Размер каталога в Byte</returns>
        private static long GetDirectorySize(DirectoryInfo dirInfo)
        {
            long size = 0;
            // Add file sizes.
            FileInfo[] files = dirInfo.GetFiles();
            foreach (FileInfo file in files)
            {
                size += file.Length;

            }
            // Add subdirectory sizes.
            DirectoryInfo[] directories = dirInfo.GetDirectories();
            foreach (DirectoryInfo dir in directories)
            {
                size += GetDirectorySize(dir);

            }
            return size;
        }
    }
}
