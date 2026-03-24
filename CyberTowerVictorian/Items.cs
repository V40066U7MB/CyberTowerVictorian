using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberTowerVictorian
{
    public static class Items
    {
        private static List<Item> _allItems;
        private static Random _random = new Random();
        public static List<Item> GetAllItems()
        {
            if (_allItems == null)
            {
                _allItems = JsonDataManager.LoadItemsFromJson();

                if (_allItems.Count == 0)
                {
                    _allItems = CreateDefaultItems();
                    JsonDataManager.SaveItemsToJson(_allItems);
                }
            }

            return _allItems;
        }
        public static List<Item> CreateDefaultItems()
        {
            List<Item> allItems = new List<Item>();
            //ШЛЕМА
            //Простые шлема
            allItems.Add(new Item
            {
                Name = "Легкий визор",
                ItemType = "Шлем",
                Category = "Броня",
                Rarity = "Простой",
                Armor = 1,
                HP = 4,
                Evasion = 0
            });
            allItems.Add(new Item
            {
                Name = "Тактический шлем",
                ItemType = "Шлем",
                Category = "Броня",
                Rarity = "Простой",
                Armor = 2,     
                HP = 6,
                Evasion = 0
            });
            allItems.Add(new Item
            {
                Name = "Бандана с коммом",
                ItemType = "Шлем",
                Category = "Броня",
                Rarity = "Простой",
                Armor = 1,
                HP = 5,
                Evasion = 1
            });
            allItems.Add(new Item
            {
                Name = "Медный шлем",
                ItemType = "Шлем",
                Category = "Броня",
                Rarity = "Простой",
                Armor = 2,
                HP = 5,
                Evasion = 0
            });
            allItems.Add(new Item
            {
                Name = "Боевой ЭкзоШлем",
                ItemType = "Шлем",
                Category = "Броня",
                Rarity = "Простой",
                Armor = 3,
                HP = 7,
                Evasion = 0
            });

            //Уникальные шлема
            allItems.Add(new Item
            {
                Name = "Шлем Стража",
                ItemType = "Шлем",
                Category = "Броня",
                Rarity = "Уникальный",
                Armor = 5,
                HP = 12,
                Evasion = 1
            });
            allItems.Add(new Item
            {
                Name = "Рогатый шлем",
                ItemType = "Шлем",
                Category = "Броня",
                Rarity = "Уникальный",
                Armor = 6,
                HP = 10,
                Evasion = 2
            });
            allItems.Add(new Item
            {
                Name = "Командирский шлем",
                ItemType = "Шлем",
                Category = "Броня",
                Rarity = "Уникальный",
                Armor = 7,
                HP = 14,
                Evasion = 1,
                CritChance = 2
            });
            allItems.Add(new Item
            {
                Name = "НейроВенец",
                ItemType = "Шлем",
                Category = "Броня",
                Rarity = "Уникальный",
                Armor = 3,
                HP = 18,
                Evasion = 3
            });
            allItems.Add(new Item
            {
                Name = "Шлем завоевателя",
                ItemType = "Шлем",
                Category = "Броня",
                Rarity = "Уникальный",
                Armor = 8,
                HP = 16,
                Evasion = 2
            });
            //Редкие шлема
            allItems.Add(new Item
            {
                Name = "ТитанШлем",
                ItemType = "Шлем",
                Category = "Броня",
                Rarity = "Редкий",
                Armor = 12,
                HP = 25,
                Evasion = 2
            });
            allItems.Add(new Item
            {
                Name = "Венец мудрости",
                ItemType = "Шлем",
                Category = "Броня",
                Rarity = "Редкий",
                Armor = 8,
                HP = 30,
                Evasion = 4,
                CritChance = 4
            });
            allItems.Add(new Item
            {
                Name = "Шлем невидимка",
                ItemType = "Шлем",
                Category = "Броня",
                Rarity = "Редкий",
                Armor = 6,
                HP = 20,
                Evasion = 8
            });
            allItems.Add(new Item
            {
                Name = "Драконий шлем",
                ItemType = "Шлем",
                Category = "Броня",
                Rarity = "Редкий",
                Armor = 14,
                HP = 28,
                Evasion = 3,
                CritMultiplier = 0.1
            });
            allItems.Add(new Item
            {
                Name = "Корона нексуса",
                ItemType = "Шлем",
                Category = "Броня",
                Rarity = "Редкий",
                Armor = 18,
                HP = 25,
                Evasion = 5
            });

            //ГРУДЬ
            //Простая грудь
            allItems.Add(new Item
            {
                Name = "Тканевый бронежилет",
                ItemType = "Грудь",
                Category = "Броня",
                Rarity = "Простой",
                Armor = 2,
                HP = 6,
                Evasion = 0
            });
            allItems.Add(new Item
            {
                Name = "Кевраловая куртка",
                ItemType = "Грудь",
                Category = "Броня",
                Rarity = "Простой",
                Armor = 3,
                HP = 8,
                Evasion = 0
            });
            allItems.Add(new Item
            {
                Name = "Кольчуга будущего",
                ItemType = "Грудь",
                Category = "Броня",
                Rarity = "Простой",
                Armor = 4,
                HP = 7,
                Evasion = 0
            });
            allItems.Add(new Item
            {
                Name = "Стеганый экзо",
                ItemType = "Грудь",
                Category = "Броня",
                Rarity = "Простой",
                Armor = 3,
                HP = 9,
                Evasion = 1
            });
            allItems.Add(new Item
            {
                Name = "Ламелляр из пластика",
                ItemType = "Грудь",
                Category = "Броня",
                Rarity = "Простой",
                Armor = 5,
                HP = 8,
                Evasion = 0
            });
            //Уникальная грудь
            allItems.Add(new Item
            {
                Name = "Кираса",
                ItemType = "Грудь",
                Category = "Броня",
                Rarity = "Уникальный",
                Armor = 8,
                HP = 15,
                Evasion = 1
            });
            allItems.Add(new Item
            {
                Name = "Бригантина",
                ItemType = "Грудь",
                Category = "Броня",
                Rarity = "Уникальный",
                Armor = 9,
                HP = 14,
                Evasion = 1
            });
            allItems.Add(new Item
            {
                Name = "Зерцало с дисплеем",
                ItemType = "Грудь",
                Category = "Броня",
                Rarity = "Уникальный",
                Armor = 10,
                HP = 16,
                Evasion = 2,
                CritChance = 1
            });
            allItems.Add(new Item
            {
                Name = "Доспех рыцаря Ордена",
                ItemType = "Грудь",
                Category = "Броня",
                Rarity = "Уникальный",
                Armor = 11,
                HP = 18,
                Evasion = 1
            });
            allItems.Add(new Item
            {
                Name = "Панцирь боевой",
                ItemType = "Грудь",
                Category = "Броня",
                Rarity = "Уникальный",
                Armor = 12,
                HP = 20,
                Evasion = 2
            });
            //Редкая грудь
            allItems.Add(new Item
            {
                Name = "Латы титана",
                ItemType = "Грудь",
                Category = "Броня",
                Rarity = "Редкий",
                Armor = 20,
                HP = 35,
                Evasion = 2
            });
            allItems.Add(new Item
            {
                Name = "Драконья чешуя",
                ItemType = "Грудь",
                Category = "Броня",
                Rarity = "Редкий",
                Armor = 22,
                HP = 30,
                Evasion = 4
            });
            allItems.Add(new Item
            {
                Name = "Мифриловый экзо",
                ItemType = "Грудь",
                Category = "Броня",
                Rarity = "Редкий",
                Armor = 18,
                HP = 40,
                Evasion = 5
            });
            allItems.Add(new Item
            {
                Name = "Кираса полководца",
                ItemType = "Грудь",
                Category = "Броня",
                Rarity = "Редкий",
                Armor = 24,
                HP = 38,
                Evasion = 3,
                Damage = 2
            });
            allItems.Add(new Item
            {
                Name = "Небесная броня",
                ItemType = "Грудь",
                Category = "Броня",
                Rarity = "Редкий",
                Armor = 25,
                HP = 45,
                Evasion = 8
            });
            // ПЕРЧАТКИ
            //Простые перчатки
            allItems.Add(new Item
            {
                Name = "Тканевые перчатки",
                ItemType = "Перчатки",
                Category = "Броня",
                Rarity = "Простой",
                Armor = 0,
                HP = 2,
                Evasion = 0.5,
                AttackSpeed = 0,
                CritChance = 0
            });
            allItems.Add(new Item
            {
                Name = "Кожаные перчатки",
                ItemType = "Перчатки",
                Category = "Броня",
                Rarity = "Простой",
                Armor = 1,
                HP = 3,
                Evasion = 0.5,
                AttackSpeed = 0,
                CritChance = 0
            });
            allItems.Add(new Item
            {
                Name = "Рукавицы силовые",
                ItemType = "Перчатки",
                Category = "Броня",
                Rarity = "Простой",
                Armor = 1,
                HP = 2,
                Evasion = 0,
                AttackSpeed = -10,
                CritChance = 0
            });
            allItems.Add(new Item
            {
                Name = "Латные перчатки",
                ItemType = "Перчатки",
                Category = "Броня",
                Rarity = "Простой",
                Armor = 2,
                HP = 3,
                Evasion = 0,
                AttackSpeed = -20,
                CritChance = 0
            });
            allItems.Add(new Item
            {
                Name = "Перчатки лучника",
                ItemType = "Перчатки",
                Category = "Броня",
                Rarity = "Простой",
                Armor = 0,
                HP = 2,
                Evasion = 1,
                AttackSpeed = -15,
                CritChance = 1
            });
            //Уникальные перчатки
            allItems.Add(new Item
            {
                Name = "Усиленные ЭкзоПерчатки",
                ItemType = "Перчатки",
                Category = "Броня",
                Rarity = "Уникальный",
                Armor = 3,
                HP = 6,
                Evasion = 1,
                AttackSpeed = -20,
                CritChance = 2
            });
            allItems.Add(new Item
            {
                Name = "Перчатки ловкача",
                ItemType = "Перчатки",
                Category = "Броня",
                Rarity = "Уникальный",
                Armor = 2,
                HP = 5,
                Evasion = 2,
                AttackSpeed = -30,
                CritChance = 3
            });
            allItems.Add(new Item
            {
                Name = "Когти Зверя",
                ItemType = "Перчатки",
                Category = "Броня",
                Rarity = "Уникальный",
                Armor = 2,
                HP = 4,
                Evasion = 1,
                AttackSpeed = -40,
                CritChance = 4
            });
            allItems.Add(new Item
            {
                Name = "Перчатки техномага",
                ItemType = "Перчатки",
                Category = "Броня",
                Rarity = "Уникальный",
                Armor = 1,
                HP = 8,
                Evasion = 2,
                AttackSpeed = -10,
                CritChance = 5
            });
            allItems.Add(new Item
            {
                Name = "Рукавицы стража",
                ItemType = "Перчатки",
                Category = "Броня",
                Rarity = "Уникальный",
                Armor = 4,
                HP = 7,
                Evasion = 1,
                AttackSpeed = -25,
                CritChance = 2
            });
            //Редкие перчатки
            allItems.Add(new Item
            {
                Name = "Перчатки титана",
                ItemType = "Перчатки",
                Category = "Броня",
                Rarity = "Редкий",
                Armor = 6,
                HP = 12,
                Evasion = 2,
                AttackSpeed = -30,
                CritChance = 5
            });
            allItems.Add(new Item
            {
                Name = "Перчатки убийцы",
                ItemType = "Перчатки",
                Category = "Броня",
                Rarity = "Редкий",
                Armor = 4,
                HP = 10,
                Evasion = 4,
                AttackSpeed = -50,
                CritChance = 8
            });
            allItems.Add(new Item
            {
                Name = "Рукавицы дракона",
                ItemType = "Перчатки",
                Category = "Броня",
                Rarity = "Редкий",
                Armor = 7,
                HP = 14,
                Evasion = 2,
                AttackSpeed = -40,
                CritChance = 6
            });
            allItems.Add(new Item
            {
                Name = "Перчатки привидения",
                ItemType = "Перчатки",
                Category = "Броня",
                Rarity = "Редкий",
                Armor = 5,
                HP = 15,
                Evasion = 5,
                AttackSpeed = -30,
                CritChance = 7
            });
            allItems.Add(new Item
            {
                Name = "Легендарные манипуляторы",
                ItemType = "Перчатки",
                Category = "Броня",
                Rarity = "Редкий",
                Armor = 8,
                HP = 18,
                Evasion = 3,
                AttackSpeed = -60,
                CritChance = 10
            });

            //ШТАНЫ
            //Простые штаны
            allItems.Add(new Item
            {
                Name = "Тканевые штаны",
                ItemType = "Штаны",
                Category = "Броня",
                Rarity = "Простой",
                Armor = 1,
                HP = 4,
                Evasion = 0.5
            });
            allItems.Add(new Item
            {
                Name = "Кожаные штаны",
                ItemType = "Штаны",
                Category = "Броня",
                Rarity = "Простой",
                Armor = 2,
                HP = 5,
                Evasion = 0.5
            });
            allItems.Add(new Item
            {
                Name = "Шерстяные с подогревом",
                ItemType = "Штаны",
                Category = "Броня",
                Rarity = "Простой",
                Armor = 1,
                HP = 6,
                Evasion = 1
            });
            allItems.Add(new Item
            {
                Name = "Кольчужные штаны",
                ItemType = "Штаны",
                Category = "Броня",
                Rarity = "Простой",
                Armor = 3,
                HP = 5,
                Evasion = 0
            });
            allItems.Add(new Item
            {
                Name = "Поножи тактические",
                ItemType = "Штаны",
                Category = "Броня",
                Rarity = "Простой",
                Armor = 2,
                HP = 7,
                Evasion = 0
            });
            //Уникальные штаны
            allItems.Add(new Item
            {
                Name = "Кожаные поножи усиленные",
                ItemType = "Штаны",
                Category = "Броня",
                Rarity = "Уникальный",
                Armor = 4,
                HP = 10,
                Evasion = 1
            });
            allItems.Add(new Item
            {
                Name = "Боевые штаны с броней",
                ItemType = "Штаны",
                Category = "Броня",
                Rarity = "Уникальный",
                Armor = 5,
                HP = 11,
                Evasion = 1
            });
            allItems.Add(new Item
            {
                Name = "Латные набедренники",
                ItemType = "Штаны",
                Category = "Броня",
                Rarity = "Уникальный",
                Armor = 6,
                HP = 12,
                Evasion = 0,
                AttackSpeed = -10
            });
            allItems.Add(new Item
            {
                Name = "Штаны легионера",
                ItemType = "Штаны",
                Category = "Броня",
                Rarity = "Уникальный",
                Armor = 5,
                HP = 13,
                Evasion = 1,
                CritChance = 1
            });
            allItems.Add(new Item
            {
                Name = "Поножи стража",
                ItemType = "Штаны",
                Category = "Броня",
                Rarity = "Уникальный",
                Armor = 7,
                HP = 14,
                Evasion = 1
            });
            //Редкие штаны
            allItems.Add(new Item
            {
                Name = "Панцирные штаны",
                ItemType = "Штаны",
                Category = "Броня",
                Rarity = "Редкий",
                Armor = 12,
                HP = 22,
                Evasion = 2
            });
            allItems.Add(new Item
            {
                Name = "Штаны дракона",
                ItemType = "Штаны",
                Category = "Броня",
                Rarity = "Редкий",
                Armor = 14,
                HP = 25,
                Evasion = 3
            });
            allItems.Add(new Item
            {
                Name = "Поножи неуязвимости",
                ItemType = "Штаны",
                Category = "Броня",
                Rarity = "Редкий",
                Armor = 16,
                HP = 28,
                Evasion = 4
            });
            allItems.Add(new Item
            {
                Name = "Штаны героя",
                ItemType = "Штаны",
                Category = "Броня",
                Rarity = "Редкий",
                Armor = 15,
                HP = 30,
                Evasion = 2,
                Damage = 3
            });
            allItems.Add(new Item
            {
                Name = "Легендарные поножи",
                ItemType = "Штаны",
                Category = "Броня",
                Rarity = "Редкий",
                Armor = 18,
                HP = 35,
                Evasion = 8
            });

            //Ботинки
            //Простые ботинки
            allItems.Add(new Item
            {
                Name = "Простые сапоги",
                ItemType = "Ботинки",
                Category = "Броня",
                Rarity = "Простой",
                Armor = 0,
                HP = 2,
                Evasion = 1,
                AttackSpeed = 0
            });
            allItems.Add(new Item
            {
                Name = "Кожаные ботинки",
                ItemType = "Ботинки",
                Category = "Броня",
                Rarity = "Простой",
                Armor = 1,
                HP = 3,
                Evasion = 1,
                AttackSpeed = 0
            });
            allItems.Add(new Item
            {
                Name = "Ботинки с пряжкой",
                ItemType = "Ботинки",
                Category = "Броня",
                Rarity = "Простой",
                Armor = 1,
                HP = 3,
                Evasion = 2,
                AttackSpeed = -10
            });
            allItems.Add(new Item
            {
                Name = "Сапоги скорохода",
                ItemType = "Ботинки",
                Category = "Броня",
                Rarity = "Простой",
                Armor = 0,
                HP = 2,
                Evasion = 3,
                AttackSpeed = -20
            });
            allItems.Add(new Item
            {
                Name = "Тяжелые сапоги",
                ItemType = "Ботинки",
                Category = "Броня",
                Rarity = "Простой",
                Armor = 2,
                HP = 4,
                Evasion = 0,
                AttackSpeed = -30
            });
            //Уникальные ботинки
            allItems.Add(new Item
            {
                Name = "Укрепленные ботинки",
                ItemType = "Ботинки",
                Category = "Броня",
                Rarity = "Уникальный",
                Armor = 3,
                HP = 6,
                Evasion = 2,
                AttackSpeed = -20
            });
            allItems.Add(new Item
            {
                Name = "Сапоги Странника",
                ItemType = "Ботинки",
                Category = "Броня",
                Rarity = "Уникальный",
                Armor = 2,
                HP = 5,
                Evasion = 4,
                AttackSpeed = -25
            });
            allItems.Add(new Item
            {
                Name = "Ботинки тени",
                ItemType = "Ботинки",
                Category = "Броня",
                Rarity = "Уникальный",
                Armor = 1,
                HP = 4,
                Evasion = 6,
                AttackSpeed = -30,
                CritChance = 2
            });
            allItems.Add(new Item
            {
                Name = "Сапоги легионера",
                ItemType = "Ботинки",
                Category = "Броня",
                Rarity = "Уникальный",
                Armor = 3,
                HP = 7,
                Evasion = 2,
                AttackSpeed = -25
            });
            allItems.Add(new Item
            {
                Name = "Ботинки техномага",
                ItemType = "Ботинки",
                Category = "Броня",
                Rarity = "Уникальный",
                Armor = 1,
                HP = 8,
                Evasion = 3,
                AttackSpeed = -15,
                CritChance = 1
            });
            //Редкие сапоги
            allItems.Add(new Item
            {
                Name = "Мерцающие сапоги",
                ItemType = "Ботинки",
                Category = "Броня",
                Rarity = "Редкий",
                Armor = 4,
                HP = 10,
                Evasion = 8,
                AttackSpeed = -40
            });
            allItems.Add(new Item
            {
                Name = "Сапоги дракона",
                ItemType = "Ботинки",
                Category = "Броня",
                Rarity = "Редкий",
                Armor = 5,
                HP = 12,
                Evasion = 5,
                AttackSpeed = -50,
                CritChance = 3
            });
            allItems.Add(new Item
            {
                Name = "Ботинки ветра",
                ItemType = "Ботинки",
                Category = "Броня",
                Rarity = "Редкий",
                Armor = 2,
                HP = 9,
                Evasion = 15,
                AttackSpeed = -60,
            });
            allItems.Add(new Item
            {
                Name = "Сапоги титана",
                ItemType = "Ботинки",
                Category = "Броня",
                Rarity = "Редкий",
                Armor = 6,
                HP = 15,
                Evasion = 4,
                AttackSpeed = -45
            });
            allItems.Add(new Item
            {
                Name = "Легендарные ЭкзоСтупи",
                ItemType = "Ботинки",
                Category = "Броня",
                Rarity = "Редкий",
                Armor = 7,
                HP = 18,
                Evasion = 7,
                AttackSpeed = -55,
                CritChance = 5
            });

            //Мечи
            //Простые мечи
            allItems.Add(new Item
            {
                Name = "Короткий плазма-меч",
                ItemType = "Меч",
                Category = "Оружие",
                Rarity = "Простой",
                Damage = 6,
                AttackSpeed = 980,       
                CritMultiplier = 1.12,
                CritChance = 6
            });
            allItems.Add(new Item
            {
                Name = "Длинный лазерный меч",
                ItemType = "Меч",
                Category = "Оружие",
                Rarity = "Простой",
                Damage = 7,
                AttackSpeed = 970,       
                CritMultiplier = 1.13,
                CritChance = 6
            });
            allItems.Add(new Item
            {
                Name = "Полуторный виброКлинок",
                ItemType = "Меч",
                Category = "Оружие",
                Rarity = "Простой",
                Damage = 8,
                AttackSpeed = 960,       
                CritMultiplier = 1.14,
                CritChance = 7
            });
            allItems.Add(new Item
            {
                Name = "Меч с гардой",
                ItemType = "Меч",
                Category = "Оружие",
                Rarity = "Простой",
                Damage = 7,
                AttackSpeed = 950,       
                CritMultiplier = 1.13,
                CritChance = 7
            });
            allItems.Add(new Item
            {
                Name = "Широкий энергоМеч",
                ItemType = "Меч",
                Category = "Оружие",
                Rarity = "Простой",
                Damage = 9,
                AttackSpeed = 940,        
                CritMultiplier = 1.15,
                CritChance = 6
            });
            //Уникальные мечи
            allItems.Add(new Item
            {
                Name = "Стальной МоноКлинок",
                ItemType = "Меч",
                Category = "Оружие",
                Rarity = "Уникальный",
                Damage = 11,
                AttackSpeed = 920,
                CritMultiplier = 1.18,
                CritChance = 8
            });
            allItems.Add(new Item
            {
                Name = "Меч рыцаря Ордена",
                ItemType = "Меч",
                Category = "Оружие",
                Rarity = "Уникальный",
                Damage = 12,
                AttackSpeed = 910,
                CritMultiplier = 1.2,
                CritChance = 9
            });
            allItems.Add(new Item
            {
                Name = "Рунический клинок",
                ItemType = "Меч",
                Category = "Оружие",
                Rarity = "Уникальный",
                Damage = 13,
                AttackSpeed = 900,
                CritMultiplier = 1.22,
                CritChance = 10
            });
            allItems.Add(new Item
            {
                Name = "Меч плазмы",
                ItemType = "Меч",
                Category = "Оружие",
                Rarity = "Уникальный",
                Damage = 14,
                AttackSpeed = 880,
                CritMultiplier = 1.25,
                CritChance = 10
            });
            allItems.Add(new Item
            {
                Name = "Меч холода",
                ItemType = "Меч",
                Category = "Оружие",
                Rarity = "Уникальный",
                Damage = 13,
                AttackSpeed = 890,
                CritMultiplier = 1.23,
                CritChance = 11
            });
            //Редкие мечи
            allItems.Add(new Item
            {
                Name = "Клинок королей",
                ItemType = "Меч",
                Category = "Оружие",
                Rarity = "Редкий",
                Damage = 18,
                AttackSpeed = 850,
                CritMultiplier = 1.3,
                CritChance = 12
            });
            allItems.Add(new Item
            {
                Name = "Меч дракона",
                ItemType = "Меч",
                Category = "Оружие",
                Rarity = "Редкий",
                Damage = 20,
                AttackSpeed = 830,
                CritMultiplier = 1.35,
                CritChance = 13
            });
            allItems.Add(new Item
            {
                Name = "Световой меч",
                ItemType = "Меч",
                Category = "Оружие",
                Rarity = "Редкий",
                Damage = 19,
                AttackSpeed = 820,
                CritMultiplier = 1.38,
                CritChance = 14
            });
            allItems.Add(new Item
            {
                Name = "Меч тысячи истин",
                ItemType = "Меч",
                Category = "Оружие",
                Rarity = "Редкий",
                Damage = 22,
                AttackSpeed = 810,
                CritMultiplier = 1.4,
                CritChance = 15
            });
            allItems.Add(new Item
            {
                Name = "Эскалибур прототип",
                ItemType = "Меч",
                Category = "Оружие",
                Rarity = "Редкий",
                Damage = 25,
                AttackSpeed = 800,
                CritMultiplier = 1.45,
                CritChance = 16
            });

            //КИНЖАЛЫ
            //простые кинжалы
            allItems.Add(new Item
            {
                Name = "Обычный виброСтилет",
                ItemType = "Кинжалы",
                Category = "Оружие",
                Rarity = "Простой",
                Damage = 4,
                AttackSpeed = 800,
                CritMultiplier = 1.2,
                CritChance = 8
            });
            allItems.Add(new Item
            {
                Name = "Зазубренный иглоДротик",
                ItemType = "Кинжалы",
                Category = "Оружие",
                Rarity = "Простой",
                Damage = 5,
                AttackSpeed = 790,
                CritMultiplier = 1.22,
                CritChance = 9
            });
            allItems.Add(new Item
            {
                Name = "Кинжал охотника",
                ItemType = "Кинжалы",
                Category = "Оружие",
                Rarity = "Простой",
                Damage = 5,
                AttackSpeed = 780,
                CritMultiplier = 1.21,
                CritChance = 10
            });
            allItems.Add(new Item
            {
                Name = "Кинжал разбойника",
                ItemType = "Кинжалы",
                Category = "Оружие",
                Rarity = "Простой",
                Damage = 6,
                AttackSpeed = 770,
                CritMultiplier = 1.23,
                CritChance = 10
            });
            allItems.Add(new Item
            {
                Name = "Кинжал с рукоятью",
                ItemType = "Кинжалы",
                Category = "Оружие",
                Rarity = "Простой",
                Damage = 5,
                AttackSpeed = 760,
                CritMultiplier = 1.22,
                CritChance = 11
            });
            //Уникальные кинжалы
            allItems.Add(new Item
            {
                Name = "Ядовитый",
                ItemType = "Кинжалы",
                Category = "Оружие",
                Rarity = "Уникальный",
                Damage = 8,
                AttackSpeed = 740,
                CritMultiplier = 1.28,
                CritChance = 13
            });
            allItems.Add(new Item
            {
                Name = "Кинжал убийцы",
                ItemType = "Кинжалы",
                Category = "Оружие",
                Rarity = "Уникальный",
                Damage = 9,
                AttackSpeed = 730,
                CritMultiplier = 1.3,
                CritChance = 14
            });
            allItems.Add(new Item
            {
                Name = "Кинжал тени",
                ItemType = "Кинжалы",
                Category = "Оружие",
                Rarity = "Уникальный",
                Damage = 9,
                AttackSpeed = 720,
                CritMultiplier = 1.32,
                CritChance = 15
            });
            allItems.Add(new Item
            {
                Name = "Кинжал вампира",
                ItemType = "Кинжалы",
                Category = "Оружие",
                Rarity = "Уникальный",
                Damage = 10,
                AttackSpeed = 710,
                CritMultiplier = 1.33,
                CritChance = 15
            });
            allItems.Add(new Item
            {
                Name = "Кинжал техномага",
                ItemType = "Кинжалы",
                Category = "Оружие",
                Rarity = "Уникальный",
                Damage = 8,
                AttackSpeed = 700,
                CritMultiplier = 1.35,
                CritChance = 16
            });
            //Редкие кинжалы
            allItems.Add(new Item
            {
                Name = "Теневой стилет",
                ItemType = "Кинжалы",
                Category = "Оружие",
                Rarity = "Редкий",
                Damage = 13,
                AttackSpeed = 680,
                CritMultiplier = 1.4,
                CritChance = 18
            });
            allItems.Add(new Item
            {
                Name = "Кинжал ночи",
                ItemType = "Кинжалы",
                Category = "Оружие",
                Rarity = "Редкий",
                Damage = 14,
                AttackSpeed = 670,
                CritMultiplier = 1.42,
                CritChance = 19
            });
            allItems.Add(new Item
            {
                Name = "Кинжал дракона",
                ItemType = "Кинжалы",
                Category = "Оружие",
                Rarity = "Редкий",
                Damage = 15,
                AttackSpeed = 660,
                CritMultiplier = 1.45,
                CritChance = 20
            });
            allItems.Add(new Item
            {
                Name = "Клинок ассасина",
                ItemType = "Кинжалы",
                Category = "Оружие",
                Rarity = "Редкий",
                Damage = 16,
                AttackSpeed = 650,
                CritMultiplier = 1.48,
                CritChance = 21
            });
            allItems.Add(new Item
            {
                Name = "Стилет богов",
                ItemType = "Кинжалы",
                Category = "Оружие",
                Rarity = "Редкий",
                Damage = 18,
                AttackSpeed = 640,
                CritMultiplier = 1.5,
                CritChance = 22
            });

            //ДУБИНЫ
            //простые дубины
            allItems.Add(new Item
            {
                Name = "Деревянная дубина",
                ItemType = "Дубины",
                Category = "Оружие",
                Rarity = "Простой",
                Damage = 8,
                AttackSpeed = 1100,
                CritMultiplier = 1.1,
                CritChance = 5
            });
            allItems.Add(new Item
            {
                Name = "Палица",
                ItemType = "Дубины",
                Category = "Оружие",
                Rarity = "Простой",
                Damage = 9,
                AttackSpeed = 1080,
                CritMultiplier = 1.11,
                CritChance = 5
            });
            allItems.Add(new Item
            {
                Name = "Булава",
                ItemType = "Дубины",
                Category = "Оружие",
                Rarity = "Простой",
                Damage = 10,
                AttackSpeed = 1060,
                CritMultiplier = 1.12,
                CritChance = 6
            });
            allItems.Add(new Item
            {
                Name = "Шипастая дубина",
                ItemType = "Дубины",
                Category = "Оружие",
                Rarity = "Простой",
                Damage = 10,
                AttackSpeed = 1050,
                CritMultiplier = 1.13,
                CritChance = 6
            });
            allItems.Add(new Item
            {
                Name = "Каменная дубина",
                ItemType = "Дубины",
                Category = "Оружие",
                Rarity = "Простой",
                Damage = 11,
                AttackSpeed = 1040,
                CritMultiplier = 1.14,
                CritChance = 5
            });
            //Уникальные дубины
            allItems.Add(new Item
            {
                Name = "Железный молот",
                ItemType = "Дубины",
                Category = "Оружие",
                Rarity = "Уникальный",
                Damage = 14,
                AttackSpeed = 1020,
                CritMultiplier = 1.18,
                CritChance = 7
            });
            allItems.Add(new Item
            {
                Name = "Боевой молот",
                ItemType = "Дубины",
                Category = "Оружие",
                Rarity = "Уникальный",
                Damage = 15,
                AttackSpeed = 1000,
                CritMultiplier = 1.2,
                CritChance = 8
            });
            allItems.Add(new Item
            {
                Name = "Дубина огров",
                ItemType = "Дубины",
                Category = "Оружие",
                Rarity = "Уникальный",
                Damage = 16,
                AttackSpeed = 980,
                CritMultiplier = 1.22,
                CritChance = 8
            });
            allItems.Add(new Item
            {
                Name = "Молот грома",
                ItemType = "Дубины",
                Category = "Оружие",
                Rarity = "Уникальный",
                Damage = 17,
                AttackSpeed = 960,
                CritMultiplier = 1.25,
                CritChance = 9
            });
            allItems.Add(new Item
            {
                Name = "Дробящий молот",
                ItemType = "Дубины",
                Category = "Оружие",
                Rarity = "Уникальный",
                Damage = 16,
                AttackSpeed = 950,
                CritMultiplier = 1.23,
                CritChance = 9
            });
            //Редкие дубины
            allItems.Add(new Item
            {
                Name = "Громобой",
                ItemType = "Дубины",
                Category = "Оружие",
                Rarity = "Редкий",
                Damage = 22,
                AttackSpeed = 900,
                CritMultiplier = 1.35,
                CritChance = 11
            });
            allItems.Add(new Item
            {
                Name = "Молот великанов",
                ItemType = "Дубины",
                Category = "Оружие",
                Rarity = "Редкий",
                Damage = 23,
                AttackSpeed = 880,
                CritMultiplier = 1.38,
                CritChance = 12
            });
            allItems.Add(new Item
            {
                Name = "Дубина разрушителя",
                ItemType = "Дубины",
                Category = "Оружие",
                Rarity = "Редкий",
                Damage = 24,
                AttackSpeed = 860,
                CritMultiplier = 1.4,
                CritChance = 12
            });
            allItems.Add(new Item
            {
                Name = "Молот титана",
                ItemType = "Дубины",
                Category = "Оружие",
                Rarity = "Редкий",
                Damage = 26,
                AttackSpeed = 840,
                CritMultiplier = 1.42,
                CritChance = 13
            });
            allItems.Add(new Item
            {
                Name = "Землетряс",
                ItemType = "Дубины",
                Category = "Оружие",
                Rarity = "Редкий",
                Damage = 28,
                AttackSpeed = 820,
                CritMultiplier = 1.45,
                CritChance = 14
            });

            //ЭСТОКИ
            //простые эстоки
            allItems.Add(new Item
            {
                Name = "Кузнечный эсток",
                ItemType = "Эстоки",
                Category = "Оружие",
                Rarity = "Простой",
                Damage = 5,
                AttackSpeed = 1000,
                CritMultiplier = 1.12,
                CritChance = 6
            });
            allItems.Add(new Item
            {
                Name = "Тренировочная рапира",
                ItemType = "Эстоки",
                Category = "Оружие",
                Rarity = "Простой",
                Damage = 6,
                AttackSpeed = 990,
                CritMultiplier = 1.13,
                CritChance = 6
            });
            allItems.Add(new Item
            {
                Name = "Тонкая игла",
                ItemType = "Эстоки",
                Category = "Оружие",
                Rarity = "Простой",
                Damage = 6,
                AttackSpeed = 980,
                CritMultiplier = 1.14,
                CritChance = 7
            });
            allItems.Add(new Item
            {
                Name = "Граненый эсток",
                ItemType = "Эстоки",
                Category = "Оружие",
                Rarity = "Простой",
                Damage = 7,
                AttackSpeed = 970,
                CritMultiplier = 1.15,
                CritChance = 7
            });
            allItems.Add(new Item
            {
                Name = "Эсток дуэлянта",
                ItemType = "Эстоки",
                Category = "Оружие",
                Rarity = "Простой",
                Damage = 7,
                AttackSpeed = 960,
                CritMultiplier = 1.16,
                CritChance = 8
            });
            //Уникальные эстоки
            allItems.Add(new Item
            {
                Name = "Проникающий эсток",
                ItemType = "Эстоки",
                Category = "Оружие",
                Rarity = "Уникальный",
                Damage = 10,
                AttackSpeed = 940,
                CritMultiplier = 1.2,
                CritChance = 10
            });
            allItems.Add(new Item
            {
                Name = "Эсток рыцаря",
                ItemType = "Эстоки",
                Category = "Оружие",
                Rarity = "Уникальный",
                Damage = 11,
                AttackSpeed = 930,
                CritMultiplier = 1.22,
                CritChance = 10
            });
            allItems.Add(new Item
            {
                Name = "Эсток правосудия",
                ItemType = "Эстоки",
                Category = "Оружие",
                Rarity = "Уникальный",
                Damage = 11,
                AttackSpeed = 920,
                CritMultiplier = 1.23,
                CritChance = 11
            });
            allItems.Add(new Item
            {
                Name = "Эсток стража",
                ItemType = "Эстоки",
                Category = "Оружие",
                Rarity = "Уникальный",
                Damage = 12,
                AttackSpeed = 910,
                CritMultiplier = 1.25,
                CritChance = 11
            });
            allItems.Add(new Item
            {
                Name = "Эсток техномага",
                ItemType = "Эстоки",
                Category = "Оружие",
                Rarity = "Уникальный",
                Damage = 10,
                AttackSpeed = 900,
                CritMultiplier = 1.28,
                CritChance = 12
            });
            //Редкие эстоки
            allItems.Add(new Item
            {
                Name = "Фаланговый эсток",
                ItemType = "Эстоки",
                Category = "Оружие",
                Rarity = "Редкий",
                Damage = 16,
                AttackSpeed = 880,
                CritMultiplier = 1.35,
                CritChance = 14
            });
            allItems.Add(new Item
            {
                Name = "Эсток дракона",
                ItemType = "Эстоки",
                Category = "Оружие",
                Rarity = "Редкий",
                Damage = 17,
                AttackSpeed = 870,
                CritMultiplier = 1.38,
                CritChance = 15
            });
            allItems.Add(new Item
            {
                Name = "Эсток героя",
                ItemType = "Эстоки",
                Category = "Оружие",
                Rarity = "Редкий",
                Damage = 18,
                AttackSpeed = 860,
                CritMultiplier = 1.4,
                CritChance = 15
            });
            allItems.Add(new Item
            {
                Name = "Эсток небес",
                ItemType = "Эстоки",
                Category = "Оружие",
                Rarity = "Редкий",
                Damage = 19,
                AttackSpeed = 850,
                CritMultiplier = 1.42,
                CritChance = 16
            });
            allItems.Add(new Item
            {
                Name = "Легендарный жсток",
                ItemType = "Эстоки",
                Category = "Оружие",
                Rarity = "Редкий",
                Damage = 20,
                AttackSpeed = 840,
                CritMultiplier = 1.45,
                CritChance = 17
            });

            //ТОПОРЫ
            //Простые топоры
            allItems.Add(new Item
            {
                Name = "Боевой топор",
                ItemType = "Топор",
                Category = "Оружие",
                Rarity = "Простой",
                Damage = 8,
                AttackSpeed = 1050,
                CritMultiplier = 1.1,
                CritChance = 5
            });
            allItems.Add(new Item
            {
                Name = "Секира",
                ItemType = "Топор",
                Category = "Оружие",
                Rarity = "Простой",
                Damage = 9,
                AttackSpeed = 1040,
                CritMultiplier = 1.11,
                CritChance = 5
            });
            allItems.Add(new Item
            {
                Name = "Топор лесоруба",
                ItemType = "Топор",
                Category = "Оружие",
                Rarity = "Простой",
                Damage = 9,
                AttackSpeed = 1030,
                CritMultiplier = 1.12,
                CritChance = 6
            });
            allItems.Add(new Item
            {
                Name = "Двуручный топор",
                ItemType = "Топор",
                Category = "Оружие",
                Rarity = "Простой",
                Damage = 10,
                AttackSpeed = 1020,
                CritMultiplier = 1.13,
                CritChance = 6
            });
            allItems.Add(new Item
            {
                Name = "Топор берсерска",
                ItemType = "Топор",
                Category = "Оружие",
                Rarity = "Простой",
                Damage = 11,
                AttackSpeed = 1010,
                CritMultiplier = 1.14,
                CritChance = 6
            });
            //Уникальные топоры
            allItems.Add(new Item
            {
                Name = "Клеймор Топор",
                ItemType = "Топор",
                Category = "Оружие",
                Rarity = "Уникальный",
                Damage = 14,
                AttackSpeed = 990,
                CritMultiplier = 1.2,
                CritChance = 8
            });
            allItems.Add(new Item
            {
                Name = "Топор варвара",
                ItemType = "Топор",
                Category = "Оружие",
                Rarity = "Уникальный",
                Damage = 15,
                AttackSpeed = 980,
                CritMultiplier = 1.22,
                CritChance = 8
            });
            allItems.Add(new Item
            {
                Name = "Топор палача",
                ItemType = "Топор",
                Category = "Оружие",
                Rarity = "Уникальный",
                Damage = 16,
                AttackSpeed = 970,
                CritMultiplier = 1.24,
                CritChance = 9
            });
            allItems.Add(new Item
            {
                Name = "Ледяной топор",
                ItemType = "Топор",
                Category = "Оружие",
                Rarity = "Уникальный",
                Damage = 15,
                AttackSpeed = 960,
                CritMultiplier = 1.25,
                CritChance = 10
            });
            allItems.Add(new Item
            {
                Name = "Огненный топор",
                ItemType = "Топор",
                Category = "Оружие",
                Rarity = "Уникальный",
                Damage = 16,
                AttackSpeed = 950,
                CritMultiplier = 1.26,
                CritChance = 10
            });
            //Редкие топоры
            allItems.Add(new Item
            {
                Name = "Рунический топор",
                ItemType = "Топор",
                Category = "Оружие",
                Rarity = "Редкий",
                Damage = 22,
                AttackSpeed = 920,
                CritMultiplier = 1.38,
                CritChance = 12
            });
            allItems.Add(new Item
            {
                Name = "Топор дракона",
                ItemType = "Топор",
                Category = "Оружие",
                Rarity = "Редкий",
                Damage = 23,
                AttackSpeed = 910,
                CritMultiplier = 1.4,
                CritChance = 13
            });
            allItems.Add(new Item
            {
                Name = "Топор разрушителя",
                ItemType = "Топор",
                Category = "Оружие",
                Rarity = "Редкий",
                Damage = 24,
                AttackSpeed = 900,
                CritMultiplier = 1.42,
                CritChance = 13
            });
            allItems.Add(new Item
            {
                Name = "Топор титана",
                ItemType = "Топор",
                Category = "Оружие",
                Rarity = "Редкий",
                Damage = 26,
                AttackSpeed = 890,
                CritMultiplier = 1.45,
                CritChance = 14
            });
            allItems.Add(new Item
            {
                Name = "Громовой топор",
                ItemType = "Топор",
                Category = "Оружие",
                Rarity = "Редкий",
                Damage = 28,
                AttackSpeed = 880,
                CritMultiplier = 1.48,
                CritChance = 15
            });

            return allItems;
        }
        public static List<Item> GetRandomLoot(int floor)
        {
            List<Item> allItems = GetAllItems();
            List<Item> available = new List<Item>();

            for (int i = 0; i < allItems.Count; i++)
            {
                Item item = allItems[i];

                if (floor <= 3)
                {
                    if (item.Rarity == "Простой" || item.Rarity == "Уникальный")
                    {
                        available.Add(item);
                    }
                }
                else if (floor <= 7)
                {
                    if (item.Rarity == "Уникальный" || item.Rarity == "Редкий")
                    {
                        available.Add(item);
                    }
                }
                else
                {
                    if (item.Rarity == "Редкий")
                    {
                        available.Add(item);
                    }
                }
            }

            List<Item> result = new List<Item>();

            if (available.Count > 0)
            {
                List<Item> temp = new List<Item>();
                for (int i = 0; i < available.Count; i++)
                {
                    temp.Add(available[i]);
                }

                for (int i = 0; i < 3 && temp.Count > 0; i++)
                {
                    int index = _random.Next(temp.Count);
                    result.Add(temp[index]);
                    temp.RemoveAt(index);
                }
            }

            while (result.Count < 3)
            {
                result.Add(new Item
                {
                    Name = "Пустой предмет",
                    Rarity = "Простой",
                    Category = "Броня",
                    ItemType = "Шлем"
                });
            }

            return result;
        }
    }
}
  