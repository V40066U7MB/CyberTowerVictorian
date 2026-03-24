using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberTowerVictorian
{
    public class Item
    {
        public string Name { get; set; }
        public string ItemType { get; set; } // Меч, Шлем, и т.д.
        public string Category { get; set; } // Оружие или Броня
        public string Rarity { get; set; }   // Простой, Уникальный, Редкий

        // Характеристики, которые предмет может изменять
        public double Damage { get; set; }
        public double Armor { get; set; }
        public double HP { get; set; }
        public int AttackSpeed { get; set; }
        public double CritMultiplier { get; set; }
        public double CritChance { get; set; }
        public double Evasion { get; set; }

        public bool IsWeapon()
        {
            if (Category == "Оружие")
                return true;
            else
                return false;
        }
    }
}