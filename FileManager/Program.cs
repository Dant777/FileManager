
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

            //WindowClass window = new WindowClass();

            //window.StartFMWindows();

            SettingWorkerJson settingWorker = new SettingWorkerJson();
            settingWorker.ReadJsonSetting();
            AppSettingClass appSetting = settingWorker.GetSettingClass;
            Console.WriteLine(appSetting.LastPath);

            appSetting.LastPath = @"C:\asda\sdadq\111";
            settingWorker.WriteSettingInFile();
            Console.WriteLine(appSetting.LastPath);

            Console.ReadKey();
        }
        
        
    }
}


