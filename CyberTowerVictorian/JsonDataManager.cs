using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CyberTowerVictorian
{
    public static class JsonDataManager
    {
        private static string dataFolder = "Data";

        // Сохранение монстров в JSON
        public static void SaveMonstersToJson(List<Unit> monsters, string fileName = "monsters.json")
        {
            string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, dataFolder);

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string filePath = Path.Combine(folderPath, fileName);
            string json = JsonConvert.SerializeObject(monsters, Formatting.Indented);
            File.WriteAllText(filePath, json);

            Console.WriteLine("Монстры сохранены в " + filePath);
        }

        // Загрузка монстров из JSON
        public static List<Unit> LoadMonstersFromJson(string fileName = "monsters.json")
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, dataFolder, fileName);

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Файл не найден: " + filePath);
                return new List<Unit>();
            }

            string json = File.ReadAllText(filePath);
            List<Unit> monsters = JsonConvert.DeserializeObject<List<Unit>>(json);

            Console.WriteLine("Загружено монстров: " + monsters.Count);
            return monsters;
        }

        // Сохранение предметов в JSON
        public static void SaveItemsToJson(List<Item> items, string fileName = "items.json")
        {
            string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, dataFolder);

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string filePath = Path.Combine(folderPath, fileName);
            string json = JsonConvert.SerializeObject(items, Formatting.Indented);
            File.WriteAllText(filePath, json);

            Console.WriteLine("Предметы сохранены в " + filePath);
        }

        // Загрузка предметов из JSON
        public static List<Item> LoadItemsFromJson(string fileName = "items.json")
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, dataFolder, fileName);

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Файл не найден: " + filePath);
                return new List<Item>();
            }

            string json = File.ReadAllText(filePath);
            List<Item> items = JsonConvert.DeserializeObject<List<Item>>(json);

            Console.WriteLine("Загружено предметов: " + items.Count);
            return items;
        }
    }
}