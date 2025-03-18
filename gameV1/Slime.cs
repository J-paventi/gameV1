using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameV1
{

    internal class Slime
    {
        // Class members
        private string name;
        private int health;
        private int mana;
        private int level;
        private int damage;
        private int accuracy;
        private int evasion;
        private int xpValue;
        private int goldValue;

        // Mutators and Accessors
        public int Health { get => health; set => health = value; }
        public int Mana { get => mana; set => mana = value; }
        public int Level { get => level; set => level = value; }
        public int Damage { get => damage; set => damage = value; }
        public int Accuracy { get => accuracy; set => accuracy = value; }
        public int Evasion { get => evasion; set => evasion = value; }
        public int XpValue { get => xpValue; }
        public int GoldValue { get => goldValue; }
        public string Name
        {
            get { return name; }
            set
            {
                if (value == null)
                {
                    name = "Slime";
                }
                else
                {
                    name = value;
                }
            }
        }

        public Slime()
        {
            Name = name;
            Health = 25;
            Mana = 0;
            Level = 1;
            Damage = 1;
            accuracy = 100;
            evasion = 10;
            xpValue = 10;
            goldValue = 5;
        }

        public void GetSlimeDetails()
        {
            Console.WriteLine($"\nName: {Name}");
            Console.WriteLine($"Health: {Health}");
            Console.WriteLine($"Mana: {Mana}");
            Console.WriteLine($"Level: {Level}");
        }

        public int TakeDamage(int damage)
        {
            Health -= damage;
            return Health;
        }

        public int AttackDmg()
        {
            int damage = Damage;
            damage += SlimeDamageRange();
            return damage; 
        }

        public int SlimeDamageRange()
        {
            Random random = new Random();
            int slimeAttPwr = random.Next(1, 6)*Level;
            return slimeAttPwr;
        }
    }
}
