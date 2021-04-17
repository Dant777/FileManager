using System;
using System.Text.Json;
using System.IO;

namespace FileManager
{
    public class SettingWorkerJson
    {
        AppSettingClass _appSettingClass;
        public SettingWorkerJson()
        {
            _appSettingClass = new AppSettingClass() { LastPath = "" };
        }
        public AppSettingClass GetSettingClass { get => _appSettingClass; }
        public void WriteSettingInFile()
        {
            string jsonString = JsonSerializer.Serialize(_appSettingClass);
            if (string.IsNullOrEmpty(jsonString))
            {
                throw new ArgumentNullException("JSON файл не создан");
            }

            File.WriteAllText("appsettings.json", jsonString);
        }

        public void ReadJsonSetting()
        {
            if (!File.Exists("appsettings.json"))
            {
                return;
            }
            string jsonString = File.ReadAllText("appsettings.json");
            _appSettingClass =  JsonSerializer.Deserialize<AppSettingClass>(jsonString);
        }

    }

  
}
