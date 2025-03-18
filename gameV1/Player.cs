using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameV1
{
    internal class Player
    {
        // Class members
        private string name;
        private int health;
        private int maxHealth;
        private int mana;
        private int maxMana;
        private int level;
        private int experience;
        private int gold;
        private int strength;
        private int accuracy;
        private int evasion;
        private int damage;
        private float critChance;
        private KeyValuePair<string, int> equippedWeapon;

        // Mutators and Accessors
        public int Health { get => health; set => health = value; }
        public int MaxHealth { get => maxHealth; set => maxHealth = value; }
        public int Mana { get => mana; set => mana = value; }
        public int MaxMana { get => maxMana; set => maxMana = value; }
        public int Level { get => level; set => level = value; }
        public int Experience { get => experience; set => experience = value; }
        public int Gold { get => gold; set => gold = value; }
        public int Strength { get => strength; set => strength = value; }
        public int Accuracy { get => accuracy; set => accuracy = value; }
        public int Evasion { get => evasion; set => evasion = value; }
        public int Damage { get => damage; set => damage = value; }
        public float CritChance { get => critChance; set => critChance = value; }
        public KeyValuePair<string, int> EquippedWeapon
        {
            get
            {
                return equippedWeapon;
            }
            set
            {
                equippedWeapon = value;
            }
        }
        public string Name 
        {
            get { return name; } 
            set 
            {
                if(value == null)
                {
                    name = "Player";
                }
                else
                {
                    name = value;
                }
            }
        }

        public Player()
        {
            Name = name;
            MaxHealth = 100;
            Health = MaxHealth;
            MaxMana = 100;
            Mana = MaxMana;
            Level = 0;
            Experience = 0;
            Gold = 10;
            Strength = 10;
            Accuracy = 100;
            Evasion = 15;
            Damage = 1;
            CritChance = 100;
            Weapons weapons = new Weapons();
            EquippedWeapon = weapons.SetWeapon("No Weapon");
        }
        public void GetPlayerDetails()
        {
            Console.WriteLine($"\nName: {Name}");
            Console.WriteLine($"Health: {Health}");
            Console.WriteLine($"Mana: {Mana}");
            Console.WriteLine($"Level: {Level}");
            Console.WriteLine($"Experience: {Experience}");
            Console.WriteLine($"Gold: {Gold}");
            Console.WriteLine($"Weapon: {EquippedWeapon}");
        }

        public void ChangePlayerWeapon(string weaponName)
        {
            Weapons weapons = new Weapons();
            EquippedWeapon = weapons.SetWeapon(weaponName);
            weapons = weapons.GetWeaponsClass(weaponName);
            UpdateStatsWithWeapon(weapons);
        }

        public void UpdateStatsWithWeapon(Weapons weapon)
        {
            Damage += weapon.DamageModifier;
            Accuracy += weapon.AccuracyModifier;
            CritChance += weapon.CritChanceModifier;
        }

        public void GainExperience(int xp)
        {
            Experience += xp;
            if (Experience >= 100 + (Level*123))
            {
                LevelUp();
            }
        }

        public void LevelUp()
        {
            Level++;
            MaxHealth += 10;
            Health = MaxHealth;
            MaxMana += 10;
            Mana = MaxMana;
        }

        public int TakeDamage(int damage)
        {
            Health -= damage;
            return Health;
        }

        public int CalculateDamage()
        {
            int baseDamage = Damage;
            int damageSum = 0;
            bool isCrit = false;
            Random random = new Random();
            if (baseDamage < Strength)
            {
                damageSum = random.Next(baseDamage, (Strength + 1)); // Add random damage between base and strength
            }
            else
            {
                damageSum = random.Next(Strength, (baseDamage + 1)); // Add random damage between strength and base
            }
            return damageSum;
        }

        public bool CritCheck()
        {
            Random random = new Random();
            int critRoll = random.Next(1, 101);
            if (critRoll <= CritChance)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int CalculateCritDamage(int damageCalc)
        {
            damageCalc = damageCalc * 2;

            return damageCalc;
        }
    }
}
