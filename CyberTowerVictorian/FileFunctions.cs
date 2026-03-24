using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;

namespace CyberTowerVictorian
{
    public static class FileFunctions
    {
        private static readonly JsonSerializerOptions jsonOptions = new JsonSerializerOptions { WriteIndented = true };

        public static void LoadData()
        {
            string dataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
            Directory.CreateDirectory(dataPath);

            string enemiesFile = Path.Combine(dataPath, "enemies.json");
            string itemsFile = Path.Combine(dataPath, "items.json");
            string playerFile = Path.Combine(dataPath, "player.json");

            if (File.Exists(enemiesFile) && File.Exists(itemsFile) && File.Exists(playerFile))
            {
                MessageBox.Show("JSON-файлы уже существуют. Загружаем существующие.");
                return;
            }

            // Создаём enemies.json из Monsters.GetAllMonsters()
            if (!File.Exists(enemiesFile))
            {
                var allMonsters = Monsters.GetAllMonsters(); // твой метод, возвращает List<Unit>
                var categories = allMonsters
                    .GroupBy(m => m.Category)
                    .Select(g => new EnemyCategory
                    {
                        CategoryName = g.Key,
                        Enemies = g.ToList() // используем твой Unit напрямую
                    })
                    .ToList();

                var enemiesData = new EnemiesData { Categories = categories };
                File.WriteAllText(enemiesFile, JsonSerializer.Serialize(enemiesData, jsonOptions));
            }

            // Создаём items.json из Items.GetArmor() и Items.Weapon()
            if (!File.Exists(itemsFile))
            {
                var armor = Items.GetArmor();   // твой метод, возвращает List<Item>
                var weapons = Items.Weapon();   // твой метод, возвращает List<Item>

                var categories = new List<EquipmentCategory>();

                // Категория "Оружие" (IsWeapon = true)
                var weaponCategory = new EquipmentCategory
                {
                    CategoryName = "Оружие",
                    IsWeapon = true,
                    Items = weapons // используем твой Item
                };
                categories.Add(weaponCategory);

                // Для брони создаём отдельные категории по ItemType (Шлем, Грудь, Перчатки, Штаны, Ботинки)
                var armorByType = armor.GroupBy(a => a.ItemType);
                foreach (var group in armorByType)
                {
                    var cat = new EquipmentCategory
                    {
                        CategoryName = group.Key,
                        IsWeapon = false,
                        Items = group.ToList()
                    };
                    categories.Add(cat);
                }

                var itemsData = new ItemsData { Categories = categories };
                File.WriteAllText(itemsFile, JsonSerializer.Serialize(itemsData, jsonOptions));
            }

            // Создаём пустой player.json, если его нет
            if (!File.Exists(playerFile))
            {
                var defaultPlayer = new PlayerData
                {
                    CurrentHP = 25,
                    CurrentArmor = 0,
                    CurrentFloor = 1,
                    WeaponName = "",
                    HelmetName = "",
                    ChestName = "",
                    GlovesName = "",
                    PantsName = "",
                    BootsName = ""
                };
                File.WriteAllText(playerFile, JsonSerializer.Serialize(defaultPlayer, jsonOptions));
            }

            MessageBox.Show("Дефолтные JSON-файлы созданы/проверены!\nПапка: " + dataPath);
        }

        public static EnemiesData LoadEnemies()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "enemies.json");
            if (!File.Exists(path)) throw new FileNotFoundException("enemies.json не найден");
            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<EnemiesData>(json);
        }

        public static ItemsData LoadItems()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "items.json");
            if (!File.Exists(path)) throw new FileNotFoundException("items.json не найден");
            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<ItemsData>(json);
        }

        public static PlayerData LoadPlayerData()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "player.json");
            if (!File.Exists(path)) throw new FileNotFoundException("player.json не найден");
            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<PlayerData>(json);
        }

        public static void SavePlayerData(PlayerData data)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "player.json");
            string json = JsonSerializer.Serialize(data, jsonOptions);
            File.WriteAllText(path, json);
        }

        public static void ResetPlayerJson()
        {
            var defaultPlayer = new PlayerData
            {
                CurrentHP = 25,
                CurrentArmor = 0,
                CurrentFloor = 1,
                WeaponName = "",
                HelmetName = "",
                ChestName = "",
                GlovesName = "",
                PantsName = "",
                BootsName = ""
            };
            SavePlayerData(defaultPlayer);
        }
    }
}