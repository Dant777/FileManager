using System;
using System.Text.Json;
using System.IO;

namespace FileManager
{
    /// <summary>
    /// Класс предназначенный для работы с параметрами приложения
    /// </summary>
    public class SettingWorkerJson
    {
        AppSettingClass _appSettingClass;
        public SettingWorkerJson()
        {
            _appSettingClass = new AppSettingClass() { LastPath = "" };
        }
        public AppSettingClass GetSettingClass { get => _appSettingClass; }
        /// <summary>
        /// Запись класса настроек в файл json
        /// </summary>
        /// <param name="appSetting">Класс настроек</param>
        public void WriteSettingInFile(AppSettingClass appSetting)
        {
            string jsonString = JsonSerializer.Serialize(appSetting);
            if (string.IsNullOrEmpty(jsonString))
            {
                throw new ArgumentNullException("JSON файл не создан");
            }

            File.WriteAllText("appsettings.json", jsonString);
            _appSettingClass = appSetting;
        }
        /// <summary>
        /// Считывает класс настроек с json
        /// </summary>
        /// <returns> Класс настроек</returns>
        public AppSettingClass ReadJsonSetting()
        {
            if (!File.Exists("appsettings.json"))
            {
                return _appSettingClass;
            }
            string jsonString = File.ReadAllText("appsettings.json");
            _appSettingClass =  JsonSerializer.Deserialize<AppSettingClass>(jsonString);

            return _appSettingClass;
        }

    }

  
}
