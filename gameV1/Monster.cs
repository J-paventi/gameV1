using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameV1
{

    internal class Monster
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
        private Dictionary<string, int> monsterList;

        // Mutators and Accessors
        public int Health { get => health; set => health = value; }
        public int Mana { get => mana; set => mana = value; }
        public int Level { get => level; set => level = value; }
        public int Damage { get => damage; set => damage = value; }
        public int Accuracy { get => accuracy; set => accuracy = value; }
        public int Evasion { get => evasion; set => evasion = value; }
        public int XpValue { get => xpValue; }
        public int GoldValue { get => goldValue; }
        public Dictionary<string, int> MonsterList { get => monsterList; }
        public string Name
        {
            get { return name; }
            set
            {
                if (value == null)
                {
                    name = "Monster";
                }
                else
                {
                    name = value;
                }
            }
        }

        public Monster()
        {
            name = "monster";
            Health = 0;
            Mana = 0;
            Level = 0;
            Damage = 0;
            Accuracy = 0;
            Evasion = 0;

            monsterList = new Dictionary<string, int>()
            {
                { "Slime", 0 },
                { "Goblin", 0 },
                { "Vicious Hamster", 0 },
            };
        }

        public void GetMonsterDetails()
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
            damage += MonsterDamageRange();
            return damage; 
        }

        public int MonsterDamageRange()
        {
            Random random = new Random();
            int slimeAttPwr = random.Next(1, 6)*Level;
            return slimeAttPwr;
        }

        public Monster GetMonsterClass(string monsterName)
        {
            return monsterName switch
            {
                "Slime" => new Slime(),
                "Goblin" => new Goblin(),
                "Vicious Hamster" => new ViciousHamster(),
                _ => new Slime(),
            };
        }

        public Monster GetRandomMonster()
        {
            Random random = new Random();
            List<string> keys = monsterList.Keys.ToList();
            string randomKey = keys[random.Next(keys.Count)];
            return GetMonsterClass(randomKey);
        }

        internal class Slime : Monster
        {
            public Slime()
            {
                Name = "Slime";
                Health = 25;
                Mana = 0;
                Level = 1;
                Damage = 1;
                accuracy = 100;
                evasion = 10;
                xpValue = 10;
                goldValue = 5;
            }
        }

        internal class Goblin : Monster
        {
            public Goblin()
            {
                Name = "Goblin";
                Health = 20;
                Mana = 0;
                Level = 1;
                Damage = 3;
                accuracy = 100;
                evasion = 20;
                xpValue = 20;
                goldValue = 10;
            }
        }

        internal class ViciousHamster : Monster
        {
            public ViciousHamster()
            {
                Name = "Vicious Hamster";
                Health = 10;
                Mana = 0;
                Level = 1;
                Damage = 5;
                accuracy = 100;
                evasion = 40;
                xpValue = 30;
                goldValue = 0;
            }
        }
    }
}
