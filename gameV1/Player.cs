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
        private int mana;
        private int level;
        private int levelUpThreshold;
        private int gold;
        private int damage;
        private KeyValuePair<string, int> equippedWeapon;

        // Mutators and Accessors
        public int Health { get => health; set => health = value; }
        public int Mana { get => mana; set => mana = value; }
        public int Level { get => level; set => level = value; }
        public int LevelUpThreshold { get => levelUpThreshold; set => levelUpThreshold = value; }
        public int TotalExperience { get => experience; set => experience = value; }
        public int Gold { get => gold; set => gold = value; }
        public int Damage { get => damage; set => damage = value; }
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

        // Player Stats
        private int maxHealth;
        private int maxMana;
        private int strength;
        private int dexterity;
        private int constitution;
        private int intelligence;
        private int wisdom;
        private int charisma;
        private int accuracy;
        private int evasion;
        private int experience;
        private float critChance;

        // Player Stat Accessor and Mutators
        public int MaxHealth { get => maxHealth; set => maxHealth = value; }
        public int MaxMana { get => maxMana; set => maxMana = value; }
        public int Strength { get => strength; set => strength = value; }
        public int Dexterity { get => dexterity; set => dexterity = value; }
        public int Constitution { get => constitution; set => constitution = value; }
        public int Intelligence { get => intelligence; set => intelligence = value; }
        public int Wisdom { get => wisdom; set => wisdom = value; }
        public int Charisma { get => charisma; set => charisma = value; }
        public int Accuracy { get => accuracy; set => accuracy = value; }
        public int Evasion { get => evasion; set => evasion = value; }
        public float CritChance { get => critChance; set => critChance = value; }

        public Player()
        {
            name = "Player";
            MaxHealth = 100;
            Health = MaxHealth;
            MaxMana = 100;
            Mana = MaxMana;
            Level = 0;
            LevelUpThreshold = 100;
            TotalExperience = 0;
            Gold = 10;
            Strength = 10;
            Accuracy = 100;
            Evasion = 15;
            Damage = 1;
            CritChance = 3;
            Weapons weapons = new Weapons();
            EquippedWeapon = weapons.SetWeapon("No Weapon");
        }
        public void GetPlayerDetails()
        {
            Console.WriteLine($"\nName: {Name}");
            Console.WriteLine($"Health: {Health}");
            Console.WriteLine($"Mana: {Mana}");
            Console.WriteLine($"Level: {Level}");
            Console.WriteLine($"TotalExperience: {TotalExperience}");
            Console.WriteLine($"Gold: {Gold}");
            Console.WriteLine($"Weapon: {EquippedWeapon}");
        }

        public void ChangePlayerWeapon(string weaponName)
        {
            Weapons weapons = new Weapons();
            EquippedWeapon = weapons.SetWeapon(weaponName);
            weapons = Weapons.GetWeaponsClass(weaponName);
            UpdateStatsWithWeapon(weapons);
        }

        public void UpdateStatsWithWeapon(Weapons weapon)
        {
            Damage += weapon.DamageModifier;
            Accuracy += weapon.AccuracyModifier;
            CritChance += weapon.CritChanceModifier;
        }

        public bool GainExperience(Player player, int xp)
        {
            bool levelUp = false;
            TotalExperience += xp;
            if (TotalExperience >= player.LevelUpThreshold)
            {
                levelUp = true;
            }

            return levelUp;
        }

        public void LevelUp(Player player)
        {
            TextUI textUI = new();
            Level++;
            MaxHealth += 10;
            Health = MaxHealth;
            MaxMana += 10;
            Mana = MaxMana;
            LevelUpThreshold += (int)(LevelUpThreshold * 1.05);
            TextUI.DisplayPlayerLevelUp(player);
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
            Random random = new();
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

        public static int CalculateCritDamage(int damageCalc)
        {
            damageCalc *= 2;

            return damageCalc;
        }
    }
}
