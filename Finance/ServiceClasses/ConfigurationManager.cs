using System.IO;
using System.Text.Json;
namespace Finance.ServiceClasses
{
    /// <summary>
    /// Данные файла конфигурации
    /// </summary>
    public class Config
    {
        /// <summary>
        /// Путь к базе данных
        /// </summary>
        public string PathDatabase { get; set; }

        /// <summary>
        /// Язык приложения
        /// </summary>
        public string Language { get; set; }
    }

    /// <summary>
    /// Класс для работы с файлом конфигурации
    /// </summary>
    public static class ConfigManager
    {
        /// <summary>
        /// Данные файла конфигурации
        /// </summary>
        public static Config Config { get; set; }

        /// <summary>
        /// Чтение значений файла конфигурации
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static void Read(string path = "config.json")
        {
            //Проверка наличия файла конфигурации.
            //Если файла нет, то создаётся с настройками по-умолчанию
            if(!File.Exists(path)) ResetConfig();

            Config = JsonSerializer.Deserialize<Config>(File.ReadAllText(path));
        }

        /// <summary>
        /// Сохранение данных файла конфигурации
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static void Save(string path = "config.json")
        {
            using var fs = new FileStream(path, FileMode.OpenOrCreate);
            JsonSerializer.SerializeAsync(fs, Config);
        }

        /// <summary>
        /// Сброс файла конфигурации
        /// </summary>
        public static void ResetConfig()
        {
            Config = new Config {PathDatabase = string.Empty, Language = "ru-RU"};

            Save();
        }
    }
}