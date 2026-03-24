using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberTowerVictorian
{
    public class Unit
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public int Level { get; set; }
        public bool IsBoss { get; set; }

        public double Damage { get; set; } = 5;
        public double HP { get; set; } = 25;
        public double Armor { get; set; } = 0;
        public int AttackSpeed { get; set; } = 1000;
        public double CritMultiplier { get; set; } = 1.1;
        public double CritChance { get; set; } = 5;
        public double Evasion { get; set; } = 5;

        public string Description { get; set; }

        // Экипировка (добавляем для игрока)
        public Item Weapon { get; set; }
        public Item Helmet { get; set; }
        public Item Chest { get; set; }
        public Item Gloves { get; set; }
        public Item Pants { get; set; }
        public Item Boots { get; set; }

        // Текущие значения в бою
        public double CurrentHP { get; set; }
        public double CurrentArmor { get; set; }

        public Unit()
        {
            CurrentHP = HP;
            CurrentArmor = Armor;
        }

        // Получение урона
        public void TakeDamage(double rawDamage)
        {
            Random rnd = new Random();
            double randomValue = rnd.NextDouble() * 100;

            if (randomValue < Evasion)
            {
                return;
            }

            if (CurrentArmor >= rawDamage)
            {
                CurrentArmor = CurrentArmor - rawDamage;
            }
            else
            {
                double remainingDamage = rawDamage - CurrentArmor;
                CurrentArmor = 0;
                CurrentHP = CurrentHP - remainingDamage;
            }
        }

        // Атака
        public double Attack(Unit target)
        {
            double damage = Damage;
            Random rnd = new Random();

            double randomValue = rnd.NextDouble() * 100;

            if (randomValue < CritChance)
            {
                damage = damage * CritMultiplier;
            }

            target.TakeDamage(damage);
            return damage;
        }

        // Восстановление после боя
        public void Restore()
        {
            CurrentHP = HP + GetArmorBonusHP();
            CurrentArmor = Armor + GetArmorBonusArmor();
        }

        private double GetArmorBonusHP()
        {
            double bonus = 0;
            if (Helmet != null) bonus = bonus + Helmet.HP;
            if (Chest != null) bonus = bonus + Chest.HP;
            if (Gloves != null) bonus = bonus + Gloves.HP;
            if (Pants != null) bonus = bonus + Pants.HP;
            if (Boots != null) bonus = bonus + Boots.HP;
            return bonus;
        }

        private double GetArmorBonusArmor()
        {
            double bonus = 0;
            if (Helmet != null) bonus = bonus + Helmet.Armor;
            if (Chest != null) bonus = bonus + Chest.Armor;
            if (Gloves != null) bonus = bonus + Gloves.Armor;
            if (Pants != null) bonus = bonus + Pants.Armor;
            if (Boots != null) bonus = bonus + Boots.Armor;
            return bonus;
        }

        public double GetTotalDamage()
        {
            double total = Damage;
            if (Weapon != null)
            {
                total = total + Weapon.Damage;
            }
            return total;
        }

        public int GetTotalAttackSpeed()
        {
            int speed = AttackSpeed;
            if (Weapon != null && Weapon.AttackSpeed > 0)
            {
                speed = Weapon.AttackSpeed;
            }

            if (Helmet != null) speed = speed + Helmet.AttackSpeed;
            if (Chest != null) speed = speed + Chest.AttackSpeed;
            if (Gloves != null) speed = speed + Gloves.AttackSpeed;
            if (Pants != null) speed = speed + Pants.AttackSpeed;
            if (Boots != null) speed = speed + Boots.AttackSpeed;

            if (speed < 200) speed = 200;
            return speed;
        }

        public double GetTotalCritMultiplier()
        {
            if (Weapon != null && Weapon.CritMultiplier > 0)
                return Weapon.CritMultiplier;
            return CritMultiplier;
        }

        public double GetTotalCritChance()
        {
            if (Weapon != null && Weapon.CritChance > 0)
                return Weapon.CritChance;
            return CritChance;
        }

        public double GetTotalEvasion()
        {
            double total = Evasion;
            if (Helmet != null) total = total + Helmet.Evasion;
            if (Chest != null) total = total + Chest.Evasion;
            if (Gloves != null) total = total + Gloves.Evasion;
            if (Pants != null) total = total + Pants.Evasion;
            if (Boots != null) total = total + Boots.Evasion;
            return total;
        }

        public bool IsAlive()
        {
            if (CurrentHP > 0)
                return true;
            else
                return false;
        }
    }
}
