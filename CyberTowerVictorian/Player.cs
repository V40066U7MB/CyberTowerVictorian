using System;
using System.Collections.Generic;

namespace CyberTowerVictorian
{
    public class Player
    {
        // Текущие значения
        public double CurrentHP { get; set; }
        public double CurrentArmor { get; set; }

        // Экипировка (ссылки на твои Item)
        public Item Weapon { get; set; }
        public Item Helmet { get; set; }
        public Item Chest { get; set; }
        public Item Gloves { get; set; }
        public Item Pants { get; set; }
        public Item Boots { get; set; }

        // Суммарные характеристики
        public double TotalMaxHP { get; private set; }
        public double TotalMaxArmor { get; private set; }
        public double TotalDamage { get; private set; }
        public int TotalAttackSpeed { get; private set; }
        public double TotalCritChance { get; private set; }
        public double TotalCritMultiplier { get; private set; }
        public double TotalEvasion { get; private set; }

        private Random _rnd = new Random();

        public Player()
        {
            // Базовые значения (без экипировки)
            TotalMaxHP = 25;
            TotalMaxArmor = 0;
            TotalDamage = 5;
            TotalAttackSpeed = 1000;
            TotalCritChance = 5;
            TotalCritMultiplier = 1.1;
            TotalEvasion = 5;
        }

        public void UpdateStats()
        {
            // Сброс на базовые
            TotalMaxHP = 25;
            TotalMaxArmor = 0;
            TotalDamage = 5;
            TotalAttackSpeed = 1000;
            TotalCritChance = 5;
            TotalCritMultiplier = 1.1;
            TotalEvasion = 5;

            // Оружие
            if (Weapon != null)
            {
                TotalDamage = Weapon.Damage;
                TotalAttackSpeed = Weapon.AttackSpeed;
                TotalCritChance += Weapon.CritChance;
                // Множитель крита от оружия заменяет базовый (как у друга)
                if (Weapon.CritMultiplier > 0)
                    TotalCritMultiplier = Weapon.CritMultiplier;
            }

            // Броня
            ApplyArmorBonuses(Helmet);
            ApplyArmorBonuses(Chest);
            ApplyArmorBonuses(Gloves);
            ApplyArmorBonuses(Pants);
            ApplyArmorBonuses(Boots);

            // Корректировка текущих значений
            if (CurrentHP > TotalMaxHP) CurrentHP = TotalMaxHP;
            if (CurrentArmor > TotalMaxArmor) CurrentArmor = TotalMaxArmor;
        }

        private void ApplyArmorBonuses(Item armor)
        {
            if (armor == null) return;
            TotalMaxHP += armor.HP;
            TotalMaxArmor += armor.Armor;
            TotalEvasion += armor.Evasion;
            TotalCritChance += armor.CritChance;
            // Броня может давать добавку к множителю крита (суммируем)
            if (armor.CritMultiplier > 0)
                TotalCritMultiplier += armor.CritMultiplier - 1.0; // добавляем как надбавку
            // Скорость атаки может меняться (отрицательные значения = ускорение)
            TotalAttackSpeed += armor.AttackSpeed;
            if (TotalAttackSpeed < 200) TotalAttackSpeed = 200; // минимум
        }

        public void FullHeal()
        {
            CurrentHP = TotalMaxHP;
            CurrentArmor = TotalMaxArmor;
        }

        public void TakeDamage(double damage)
        {
            if (damage <= 0) return;
            if (CurrentArmor >= damage)
            {
                CurrentArmor -= damage;
            }
            else
            {
                damage -= CurrentArmor;
                CurrentArmor = 0;
                CurrentHP -= damage;
                if (CurrentHP < 0) CurrentHP = 0;
            }
        }

        public double GetRandomDamage()
        {
            // Урон фиксированный (как у врагов). Можно добавить разброс, если хочешь.
            return TotalDamage;
        }

        public double AttackTarget(Unit target)
        {
            // Проверка уклонения врага
            if (_rnd.NextDouble() * 100 < target.Evasion)
                return 0;

            double damage = GetRandomDamage();
            if (_rnd.NextDouble() * 100 < TotalCritChance)
            {
                damage *= TotalCritMultiplier;
            }

            target.TakeDamage(damage);
            return damage;
        }
    }
}
