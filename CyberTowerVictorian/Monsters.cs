using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CyberTowerVictorian
{
    public static class Monsters
    {
        private static List<Unit> _allMonsters;
        public static List<Unit> GetAllMonsters()
        {
            if (_allMonsters == null)
            {
                _allMonsters = JsonDataManager.LoadMonstersFromJson();

                // Если файла нет, создаем из ваших данных
                if (_allMonsters.Count == 0)
                {
                    _allMonsters = CreateDefaultMonsters();
                    JsonDataManager.SaveMonstersToJson(_allMonsters);
                }
            }

            return _allMonsters;
        }

        private static List<Unit> CreateDefaultMonsters()
        {
            List<Unit> towerMonsters = new List<Unit>();
            //Категория БИОМАШИНЫ
            //биомашины основные 1-3 этаж
            towerMonsters.Add(new Unit {
                Name = "Ржавый дрон",
                Category = "БиоМашины",    
                Level = 1,
                IsBoss = false,
                HP = 28, // здоровье
                Damage = 6, // урон
                Armor = 1,  // броня
                AttackSpeed = 980, // скорость атаки в мс (меньше = быстрее)
                CritMultiplier = 1.12,// множитель крита
                CritChance = 6, // шанс крита в %
                Evasion = 5, // уклонение в %
                Description = "Ржавый разведывательный дрон, оставленный после войны. Слабый, но быстрый."
            });
            towerMonsters.Add(new Unit
            {
                Name = "МутантНосильщик",
                Category = "БиоМашины",
                Level = 2,
                IsBoss = false,
                HP = 35, 
                Damage = 7, 
                Armor = 2,  
                AttackSpeed = 960, 
                CritMultiplier = 1.13,
                CritChance = 7, 
                Evasion = 5, 
                Description = ""
            });
            towerMonsters.Add(new Unit
            {
                Name = "Фантомный хакер",
                Category = "БиоМашины",
                Level = 3,
                IsBoss = false,
                HP = 32,
                Damage = 8,
                Armor = 0,
                AttackSpeed = 940,
                CritMultiplier = 1.15,
                CritChance = 8,
                Evasion = 10,
                Description = ""
            });
            //Биомашины боссы 4 этаж
            towerMonsters.Add(new Unit
            {
                Name = "КиберВампир",
                Category = "БиоМашины",
                Level = 4,
                IsBoss = true,
                HP = 100,
                Damage = 15,
                Armor = 5,
                AttackSpeed = 900,
                CritMultiplier = 1.2,
                CritChance = 12,
                Evasion = 12,
                Description = ""
            });
            towerMonsters.Add(new Unit
            {
                Name = "Могильные экзо",
                Category = "БиоМашины",
                Level = 4,
                IsBoss = true,
                HP = 120,
                Damage = 12,
                Armor = 10,
                AttackSpeed = 1000,
                CritMultiplier = 1.18,
                CritChance = 10,
                Evasion = 8,
                Description = ""
            });
            //Уникальные биоМашины 5-7 этаж
            towerMonsters.Add(new Unit
            {
                Name = "НекроТехномант",
                Category = "БиоМашины",
                Level = 5,
                IsBoss = false,
                HP = 70,
                Damage = 14,
                Armor = 4,
                AttackSpeed = 880,
                CritMultiplier = 1.25,
                CritChance = 15,
                Evasion = 7,
                Description = ""
            });
            towerMonsters.Add(new Unit
            {
                Name = "БаншиСигнал",
                Category = "БиоМашины",
                Level = 6,
                IsBoss = false,
                HP = 65,
                Damage = 16,
                Armor = 2,
                AttackSpeed = 820,
                CritMultiplier = 1.3,
                CritChance = 18,
                Evasion = 15,
                Description = ""
            });
            towerMonsters.Add(new Unit
            {
                Name = "Костяной мех",
                Category = "БиоМашины",
                Level = 7,
                IsBoss = false,
                HP = 110,
                Damage = 22,
                Armor = 12,
                AttackSpeed = 800,
                CritMultiplier = 1.35,
                CritChance = 12,
                Evasion = 10,
                Description = ""
            });
            //Биомашины боссы 8 этаж
            towerMonsters.Add(new Unit
            {
                Name = "Король Серверов",
                Category = "БиоМашины",
                Level = 8,
                IsBoss = true,
                HP = 350,
                Damage = 35,
                Armor = 30,
                AttackSpeed = 750,
                CritMultiplier = 1.5,
                CritChance = 20,
                Evasion = 12,
                Description = ""
            });
            towerMonsters.Add(new Unit
            {
                Name = "Владыка Свалок",
                Category = "БиоМашины",
                Level = 8,
                IsBoss = true,
                HP = 400,
                Damage = 30,
                Armor = 40,
                AttackSpeed = 850,
                CritMultiplier = 1.45,
                CritChance = 18,
                Evasion = 15,
                Description = ""
            });

            //ИНОПРИШИЛЕНЦЫ
            //Основные 1-3 этаж
            towerMonsters.Add(new Unit
            {
                Name = "Личинка ксеноморфа",
                Category = "Пришельцы",
                Level = 1,
                IsBoss = false,
                HP = 25,
                Damage = 7,
                Armor = 0,
                AttackSpeed = 950,
                CritMultiplier = 1.15,
                CritChance = 7,
                Evasion = 6,
                Description = ""
            });
            towerMonsters.Add(new Unit
            {
                Name = "Огненный слизень",
                Category = "Пришельцы",
                Level = 2,
                IsBoss = false,
                HP = 33,
                Damage = 9,
                Armor = 1,
                AttackSpeed = 920,
                CritMultiplier = 1.16,
                CritChance = 8,
                Evasion = 7,
                Description = ""
            });
            towerMonsters.Add(new Unit
            {
                Name = "Телепат Паразит",
                Category = "Пришельцы",
                Level = 3,
                IsBoss = false,
                HP = 38,
                Damage = 10,
                Armor = 2,
                AttackSpeed = 900,
                CritMultiplier = 1.18,
                CritChance = 9,
                Evasion = 9,
                Description = ""
            });
            //Боссы 4 этаж
            towerMonsters.Add(new Unit
            {
                Name = "Воин улья",
                Category = "Пришельцы",
                Level = 4,
                IsBoss = true,
                HP = 110,
                Damage = 18,
                Armor = 6,
                AttackSpeed = 850,
                CritMultiplier = 1.25,
                CritChance = 14,
                Evasion = 10,
                Description = ""
            });
            towerMonsters.Add(new Unit
            {
                Name = "Командир роя",
                Category = "Пришельцы",
                Level = 4,
                IsBoss = true,
                HP = 130,
                Damage = 16,
                Armor = 12,
                AttackSpeed = 880,
                CritMultiplier = 1.22,
                CritChance = 12,
                Evasion = 8,
                Description = ""
            });
            //Уникальные 5-7 этаж
            towerMonsters.Add(new Unit
            {
                Name = "Суккуб андроид",
                Category = "Пришельцы",
                Level = 5,
                IsBoss = false,
                HP = 72,
                Damage = 15,
                Armor = 3,
                AttackSpeed = 820,
                CritMultiplier = 1.28,
                CritChance = 18,
                Evasion = 14,
                Description = ""
            });
            towerMonsters.Add(new Unit
            {
                Name = "Плазматичный",
                Category = "Пришельцы",
                Level = 6,
                IsBoss = false,
                HP = 85,
                Damage = 20,
                Armor = 5,
                AttackSpeed = 800,
                CritMultiplier = 1.32,
                CritChance = 16,
                Evasion = 9,
                Description = ""
            });
            towerMonsters.Add(new Unit
            {
                Name = "Пустота",
                Category = "Пришельцы",
                Level = 7,
                IsBoss = false,
                HP = 120,
                Damage = 25,
                Armor = 10,
                AttackSpeed = 780,
                CritMultiplier = 1.38,
                CritChance = 15,
                Evasion = 12,
                Description = ""
            });
            //Боссы 8 этаж
            towerMonsters.Add(new Unit
            {
                Name = "Архитектор реальности",
                Category = "Пришельцы",
                Level = 8,
                IsBoss = true,
                HP = 380,
                Damage = 42,
                Armor = 35,
                AttackSpeed = 720,
                CritMultiplier = 1.6,
                CritChance = 22,
                Evasion = 15,
                Description = ""
            });
            towerMonsters.Add(new Unit
            {
                Name = "Падший андроид",
                Category = "Пришельцы",
                Level = 8,
                IsBoss = true,
                HP = 420,
                Damage = 38,
                Armor = 38,
                AttackSpeed = 760,
                CritMultiplier = 1.55,
                CritChance = 20,
                Evasion = 18,
                Description = ""
            });

            //КИБЕР ЗВЕРИ
            //1-3 этаж
            towerMonsters.Add(new Unit
            {
                Name = "КиберВолк",
                Category = "КиберЗвери",
                Level = 1,
                IsBoss = false,
                HP = 30,
                Damage = 5,
                Armor = 0,
                AttackSpeed = 950,
                CritMultiplier = 1.1,
                CritChance = 5,
                Evasion = 8,
                Description = ""
            });
            towerMonsters.Add(new Unit
            {
                Name = "БронеМедведь",
                Category = "КиберЗвери",
                Level = 2,
                IsBoss = false,
                HP = 45,
                Damage = 8,
                Armor = 3,
                AttackSpeed = 1050,
                CritMultiplier = 1.12,
                CritChance = 4,
                Evasion = 4,
                Description = ""
            });
            towerMonsters.Add(new Unit
            {
                Name = "РысьНевидимка",
                Category = "КиберЗвери",
                Level = 3,
                IsBoss = false,
                HP = 34,
                Damage = 7,
                Armor = 1,
                AttackSpeed = 880,
                CritMultiplier = 1.14,
                CritChance = 7,
                Evasion = 12,
                Description = ""
            });
            //боссы 4 этаж
            towerMonsters.Add(new Unit
            {
                Name = "Саблезуб3000 ",
                Category = "КиберЗвери",
                Level = 4,
                IsBoss = true,
                HP = 115,
                Damage = 16,
                Armor = 5,
                AttackSpeed = 860,
                CritMultiplier = 1.2,
                CritChance = 10,
                Evasion = 10, 
                Description = ""
            });
            towerMonsters.Add(new Unit
            {
                Name = "МамонтТанк",
                Category = "КиберЗвери",
                Level = 4,
                IsBoss = true,
                HP = 160,
                Damage = 14,
                Armor = 15,
                AttackSpeed = 1100,
                CritMultiplier = 1.18,
                CritChance = 6,
                Evasion = 5,
                Description = ""
            });
            //5-7 этаж
            towerMonsters.Add(new Unit
            {
                Name = "ГрифонРазведчик",
                Category = "КиберЗвери",
                Level = 5,
                IsBoss = false,
                HP = 80,
                Damage = 17,
                Armor = 4,
                AttackSpeed = 820,
                CritMultiplier = 1.24,
                CritChance = 12,
                Evasion = 12,
                Description = ""
            });
            towerMonsters.Add(new Unit
            {
                Name = "Лев3000",
                Category = "КиберЗвери",
                Level = 6,
                IsBoss = false,
                HP = 105,
                Damage = 21,
                Armor = 8,
                AttackSpeed = 840,
                CritMultiplier = 1.28,
                CritChance = 14,
                Evasion = 10,
                Description = ""
            });
            towerMonsters.Add(new Unit
            {
                Name = "Древний вивернМех",
                Category = "КиберЗвери",
                Level = 7,
                IsBoss = false,
                HP = 130,
                Damage = 28,
                Armor = 14,
                AttackSpeed = 790,
                CritMultiplier = 1.35,
                CritChance = 13,
                Evasion = 11,
                Description = ""
            });
            //боссы 8 этаж
            towerMonsters.Add(new Unit
            {
                Name = "ФенрирПрототип",
                Category = "КиберЗвери",
                Level = 8,
                IsBoss = true,
                HP = 390,
                Damage = 40,
                Armor = 25,
                AttackSpeed = 700,
                CritMultiplier = 1.55,
                CritChance = 20,
                Evasion = 20,
                Description = ""
            });
            towerMonsters.Add(new Unit
            {
                Name = "ХимераСимбионт",
                Category = "КиберЗвери",
                Level = 8,
                IsBoss = true,
                HP = 410,
                Damage = 38,
                Armor = 30,
                AttackSpeed = 780,
                CritMultiplier = 1.5,
                CritChance = 18,
                Evasion = 16,
                Description = ""
            });

            //НАЕМНИКИ
            //1-3 этаж
            towerMonsters.Add(new Unit
            {
                Name = "Наемник с лазером",
                Category = "Наемники",
                Level = 1,
                IsBoss = false,
                HP = 27,
                Damage = 6,
                Armor = 0,
                AttackSpeed = 920,
                CritMultiplier = 1.13,
                CritChance = 7,
                Evasion = 7,
                Description = ""
            });
            towerMonsters.Add(new Unit
            {
                Name = "Охранник корпорации",
                Category = "Наемники",
                Level = 2,
                IsBoss = false,
                HP = 40,
                Damage = 7,
                Armor = 4,
                AttackSpeed = 1000,
                CritMultiplier = 1.1,
                CritChance = 5,
                Evasion = 5,
                Description = ""
            }); 
            towerMonsters.Add(new Unit
            {
                Name = "СнайперНевидимка",
                Category = "Наемники",
                Level = 3,
                IsBoss = false,
                HP = 32,
                Damage = 9,
                Armor = 1,
                AttackSpeed = 890,
                CritMultiplier = 1.16,
                CritChance = 9,
                Evasion = 8,
                Description = ""
            });
            //Боссы 4 этаж
            towerMonsters.Add(new Unit
            {
                Name = "Космодесантник",
                Category = "Наемники",
                Level = 4,
                IsBoss = true,
                HP = 125,
                Damage = 17,
                Armor = 12,
                AttackSpeed = 950,
                CritMultiplier = 1.2,
                CritChance = 8,
                Evasion = 6,
                Description = ""
            });
            towerMonsters.Add(new Unit
            {
                Name = "Техномаг",
                Category = "Наемники",
                Level = 4,
                IsBoss = true,
                HP = 90,
                Damage = 22,
                Armor = 2,
                AttackSpeed = 1100,
                CritMultiplier = 1.3,
                CritChance = 15,
                Evasion = 10,
                Description = ""
            });
            //5-7 этаж
            towerMonsters.Add(new Unit
            {
                Name = "КиберАссасин",
                Category = "Наемники",
                Level = 5,
                IsBoss = false,
                HP = 68,
                Damage = 16,
                Armor = 2,
                AttackSpeed = 800,
                CritMultiplier = 1.26,
                CritChance = 20,
                Evasion = 15,
                Description = ""
            });
            towerMonsters.Add(new Unit
            {
                Name = "Капитан Стражи",
                Category = "Наемники",
                Level = 6,
                IsBoss = false,
                HP = 98,
                Damage = 20,
                Armor = 10,
                AttackSpeed = 920,
                CritMultiplier = 1.22,
                CritChance = 12,
                Evasion = 9,
                Description = ""
            });
            towerMonsters.Add(new Unit
            {
                Name = "Хакер9000",
                Category = "Наемники",
                Level = 7,
                IsBoss = false,
                HP = 95,
                Damage = 27,
                Armor = 5,
                AttackSpeed = 1050,
                CritMultiplier = 1.4,
                CritChance = 18,
                Evasion = 12,
                Description = ""
            });
            //Боссы 8 этаж
            towerMonsters.Add(new Unit
            {
                Name = "Король Генерал",
                Category = "Наемники",
                Level = 8,
                IsBoss = true,
                HP = 370,
                Damage = 38,
                Armor = 40,
                AttackSpeed = 850,
                CritMultiplier = 1.5,
                CritChance = 15,
                Evasion = 10,
                Description = ""
            });
            towerMonsters.Add(new Unit
            {
                Name = "Темный паладин",
                Category = "Наемники",
                Level = 8,
                IsBoss = true,
                HP = 400,
                Damage = 36,
                Armor = 45,
                AttackSpeed = 820,
                CritMultiplier = 1.48,
                CritChance = 18,
                Evasion = 12,
                Description = ""
            });

            //ЭНЕРГОСУЩНОСТИ
            //1-3 этаж
            towerMonsters.Add(new Unit
            {
                Name = "Плазмалоид",
                Category = "Энергетические сущности",
                Level = 1,
                IsBoss = false,
                HP = 26,
                Damage = 8,
                Armor = 0,
                AttackSpeed = 960,
                CritMultiplier = 1.14,
                CritChance = 6,
                Evasion = 5,
                Description = ""
            });
            towerMonsters.Add(new Unit
            {
                Name = "ГидроДрон",
                Category = "Энергетические сущности",
                Level = 2,
                IsBoss = false,
                HP = 38,
                Damage = 7,
                Armor = 2,
                AttackSpeed = 1000,
                CritMultiplier = 1.12,
                CritChance = 7,
                Evasion = 7,
                Description = ""
            });
            towerMonsters.Add(new Unit
            {
                Name = "КристаллГолем",
                Category = "Энергетические сущности",
                Level = 3,
                IsBoss = false,
                HP = 50,
                Damage = 9,
                Armor = 6,
                AttackSpeed = 1080,
                CritMultiplier = 1.1,
                CritChance = 4,
                Evasion = 4,
                Description = ""
            });
            //Боссы 4 этаж
            towerMonsters.Add(new Unit
            {
                Name = "Электрический шторм",
                Category = "Энергетические сущности",
                Level = 4,
                IsBoss = true,
                HP = 95,
                Damage = 18,
                Armor = 3,
                AttackSpeed = 820,
                CritMultiplier = 1.22,
                CritChance = 14,
                Evasion = 18,
                Description = ""
            });
            towerMonsters.Add(new Unit
            {
                Name = "МагмаМех",
                Category = "Энергетические сущности",
                Level = 4,
                IsBoss = true,
                HP = 140,
                Damage = 20,
                Armor = 12,
                AttackSpeed = 940,
                CritMultiplier = 1.25,
                CritChance = 10,
                Evasion = 8,
                Description = ""
            });
            //5-7 этаж 
            towerMonsters.Add(new Unit
            {
                Name = "Ледяной синтет",
                Category = "Энергетические сущности",
                Level = 5,
                IsBoss = false,
                HP = 82,
                Damage = 16,
                Armor = 5,
                AttackSpeed = 900,
                CritMultiplier = 1.2,
                CritChance = 12,
                Evasion = 9,
                Description = ""
            });
            towerMonsters.Add(new Unit
            {
                Name = "Элементаль хаоса",
                Category = "Энергетические сущности",
                Level = 6,
                IsBoss = false,
                HP = 100,
                Damage = 24,
                Armor = 7,
                AttackSpeed = 860,
                CritMultiplier = 1.3,
                CritChance = 16,
                Evasion = 12,
                Description = ""
            });
            towerMonsters.Add(new Unit
            {
                Name = "Древний каменный страж",
                Category = "Энергетические сущности",
                Level = 7,
                IsBoss = false,
                HP = 150,
                Damage = 22,
                Armor = 20,
                AttackSpeed = 1050,
                CritMultiplier = 1.18,
                CritChance = 8,
                Evasion = 6,
                Description = ""
            });
            //Боссы 8 этаж
            towerMonsters.Add(new Unit
            {
                Name = "Повелитель стихий",
                Category = "Энергетические сущности",
                Level = 8,
                IsBoss = true,
                HP = 380,
                Damage = 45,
                Armor = 30,
                AttackSpeed = 800,
                CritMultiplier = 1.55,
                CritChance = 20,
                Evasion = 15,
                Description = ""
            });
            towerMonsters.Add(new Unit
            {
                Name = "Аномалия пространства",
                Category = "Энергетические сущности",
                Level = 8,
                IsBoss = true,
                HP = 420,
                Damage = 40,
                Armor = 35,
                AttackSpeed = 780,
                CritMultiplier = 1.6,
                CritChance = 22,
                Evasion = 18,
                Description = ""
            });
            return towerMonsters;
        }
        public static List<Unit> GetMonstersByFloor(int floor)
        {
            List<Unit> allMonsters = GetAllMonsters();
            List<Unit> result = new List<Unit>();

            for (int i = 0; i < allMonsters.Count; i++)
            {
                Unit monster = allMonsters[i];
                if (monster.Level == floor && monster.IsBoss == false)
                {
                    result.Add(monster);
                }
            }

            return result;
        }

        public static Unit GetRandomBoss(int floor, string category)
        {
            List<Unit> allMonsters = GetAllMonsters();
            List<Unit> bosses = new List<Unit>();

            for (int i = 0; i < allMonsters.Count; i++)
            {
                Unit monster = allMonsters[i];
                if (monster.IsBoss && monster.Level == floor && monster.Category == category)
                {
                    bosses.Add(monster);
                }
            }

            if (bosses.Count == 0)
            {
                return null;
            }

            Random rnd = new Random();
            int index = rnd.Next(bosses.Count);
            return bosses[index];
        }
    }
}
   