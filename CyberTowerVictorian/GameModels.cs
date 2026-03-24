using System;
using System.Collections.Generic;

namespace CyberTowerVictorian
{
    public class EnemiesData
    {
        public List<EnemyCategory> Categories { get; set; }
    }

    public class EnemyCategory
    {
        public string CategoryName { get; set; }
        public List<Unit> Enemies { get; set; }
    }

    public class ItemsData
    {
        public List<EquipmentCategory> Categories { get; set; }
    }

    public class EquipmentCategory
    {
        public string CategoryName { get; set; }
        public bool IsWeapon { get; set; }
        public List<Item> Items { get; set; }
    }

    public class PlayerData
    {
        public double CurrentHP { get; set; }
        public double CurrentArmor { get; set; }
        public int CurrentFloor { get; set; }
        public string WeaponName { get; set; }
        public string HelmetName { get; set; }
        public string ChestName { get; set; }
        public string GlovesName { get; set; }
        public string PantsName { get; set; }
        public string BootsName { get; set; }
    }
}