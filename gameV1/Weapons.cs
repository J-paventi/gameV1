using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameV1
{
    internal class Weapons
    {
        private int damageModifier;
        private int accuracyModifier;
        private float critChanceModifier;
        private float critDamageModifier;

        public int DamageModifier { get => damageModifier; set => damageModifier = value; }
        public int AccuracyModifier { get => accuracyModifier; set => accuracyModifier = value; }
        public float CritChanceModifier { get => critChanceModifier; set => critChanceModifier = value; }
        public float CritDamageModifier { get => critDamageModifier; set => critDamageModifier = value; }

        // Class members
        private Dictionary<string, int> weaponList;

        // Mutators and Accessors
        public Dictionary<string, int> WeaponList { get => weaponList; }

        public Weapons()
        {
            weaponList = new Dictionary<string, int>()
            {
                // Level 0 Weapons
                { "Knuckles", 0 },
                { "Wooden Sword", 0 },
                { "Wooden Spear", 0 },
                { "Wooden Bow", 0 },
                // Level 1 Weapons
                { "Knuckle Dusters", 1 },
                { "Sword", 1 },
                { "Spear", 1 },
                { "Bow", 1 },
                // Level 2 Weapons
                { "Iron Knuckles", 2 },
                { "Iron Sword", 2 },
                { "Iron Spear", 2 },
                { "Iron Bow", 2 },
                // Level 3 Weapons
                { "Steel Knuckles", 3 },
                { "Steel Sword", 3 },
                { "Steel Spear", 3 },
                { "Steel Bow", 3 },
                // Debug Weapons
                { "Debug Knuckles", 100 },
                { "Debug Sword", 100 },
                { "Debug Spear", 100 },
                { "Debug Bow", 100 },
            };
        }

        public List<KeyValuePair<string, int>> StarterWeapons()
        {
            return weaponList.Take(4).ToList();
        }



        public string GetWeaponWithValue(int damage)
        {
            foreach (KeyValuePair<string, int> weapon in weaponList)
            {
                if (weapon.Value <= damage)
                {
                    return weapon.Key;
                }
            }

            return "No Weapon Found";
        }

        public List<KeyValuePair<string, int>> FilterWeapons(int minDamage)
        {
            List<KeyValuePair<string, int>> filteredWeapons = new List<KeyValuePair<string, int>>();
            foreach (KeyValuePair<string, int> weapon in weaponList)
            {
                if (weapon.Value <= minDamage)
                {
                    filteredWeapons.Add(weapon);
                }
            }
            return filteredWeapons;
        }

        public KeyValuePair<string, int> SetWeapon(string weaponName)
        {
            foreach (KeyValuePair<string, int> weapon in weaponList)
            {
                if (weapon.Key == weaponName)
                {
                    return weapon;
                }
            }
            return new KeyValuePair<string, int>("No Weapon", 0);
        }

        public string SearchWeaponByName(string weaponName)
        {
            var weapon = weaponList.FirstOrDefault(w => w.Key.Equals(weaponName, StringComparison.OrdinalIgnoreCase));
            return weapon.Key;
        }


        public Weapons GetWeaponsClass(string weaponName)
        {
            return weaponName switch
            {
                "Knuckles" => new Knuckles(),
                "Wooden Sword" => new Swords.WoodenSword(),
                "Wooden Spear" => new Spears.WoodenSpear(),
                "Wooden Bow" => new Bows.WoodenBow(),
                "Knuckle Dusters" => new Knuckles.KnuckleDusters(),
                "Sword" => new Swords(),
                "Spear" => new Spears(),
                "Bow" => new Bows(),
                "Iron Knuckles" => new Knuckles.IronKnuckles(),
                "Iron Sword" => new Swords.IronSword(),
                "Iron Spear" => new Spears.IronSpear(),
                "Iron Bow" => new Bows.IronBow(),
                "Steel Knuckles" => new Knuckles.SteelKnuckles(),
                "Steel Sword" => new Swords.SteelSword(),
                "Steel Spear" => new Spears.SteelSpear(),
                "Steel Bow" => new Bows.SteelBow(),
                "Debug Knuckles" => new Knuckles.DebugKnuckles(),
                "Debug Sword" => new Swords.DebugSword(),
                "Debug Spear" => new Spears.DebugSpear(),
                "Debug Bow" => new Bows.DebugBow(),
                _ => new Weapons(),
            };
         }

        internal class Knuckles : Weapons
        {
            public Knuckles()
            {
                DamageModifier = 2;
                AccuracyModifier = 15;
                CritChanceModifier = 0.75f;
                CritDamageModifier = 1.5f;
            }

            internal class KnuckleDusters : Knuckles
            {
                public KnuckleDusters()
                {
                    DamageModifier = 3;
                    AccuracyModifier = 20;
                    CritChanceModifier = 0.8f;
                    CritDamageModifier = 1.8f;
                }
            }

            internal class IronKnuckles : Knuckles
            {
                public IronKnuckles()
                {
                    DamageModifier = 4;
                    AccuracyModifier = 20;
                    CritChanceModifier = 0.8f;
                    CritDamageModifier = 2;
                }
            }

            internal class SteelKnuckles : Knuckles
            {
                public SteelKnuckles()
                {
                    DamageModifier = 5;
                    AccuracyModifier = 25;
                    CritChanceModifier = 0.9f;
                    CritDamageModifier = 2.5f;
                }
            }

            internal class DebugKnuckles : Knuckles
            {
                public DebugKnuckles()
                {
                    DamageModifier = 100;
                    AccuracyModifier = 100;
                    CritChanceModifier = 1;
                    CritDamageModifier = 100;
                }
            }
        }

        internal class Swords : Weapons
        {
            public Swords()
            {
                DamageModifier = 5;
                AccuracyModifier = 10;
                CritChanceModifier = 0.5f;
                CritDamageModifier = 2;
            }

            internal class  WoodenSword : Swords
            {
                public WoodenSword()
                {
                    DamageModifier = 3;
                    AccuracyModifier = 5;
                    CritChanceModifier = 0.2f;
                    CritDamageModifier = 1.2f;
                }
            }

            internal class IronSword : Swords
            {
                public IronSword()
                {
                    DamageModifier = 6;
                    AccuracyModifier = 15;
                    CritChanceModifier = 0.6f;
                    CritDamageModifier = 2.5f;
                }
            }

            internal class SteelSword : Swords
            {
                public SteelSword()
                {
                    DamageModifier = 7;
                    AccuracyModifier = 20;
                    CritChanceModifier = 0.7f;
                    CritDamageModifier = 3;
                }
            }

            internal class DebugSword : Swords
            {
                public DebugSword()
                {
                    DamageModifier = 100;
                    AccuracyModifier = 100;
                    CritChanceModifier = 1;
                    CritDamageModifier = 100;
                }
            }
        }

        internal class Spears : Weapons
        {
            public Spears()
            {
                DamageModifier = 3;
                AccuracyModifier = 25;
                CritChanceModifier = 0.6f;
                CritDamageModifier = 2;
            }

            internal class WoodenSpear : Spears
            {
                public WoodenSpear()
                {
                    DamageModifier = 2;
                    AccuracyModifier = 20;
                    CritChanceModifier = 0.4f;
                    CritDamageModifier = 1.5f;
                }
            }

            internal class IronSpear : Spears
            {
                public IronSpear()
                {
                    DamageModifier = 4;
                    AccuracyModifier = 30;
                    CritChanceModifier = 0.7f;
                    CritDamageModifier = 2.5f;
                }
            }

            internal class SteelSpear : Spears
            {
                public SteelSpear()
                {
                    DamageModifier = 5;
                    AccuracyModifier = 35;
                    CritChanceModifier = 0.8f;
                    CritDamageModifier = 3;
                }
            }

            internal class DebugSpear : Spears
            {
                public DebugSpear()
                {
                    DamageModifier = 100;
                    AccuracyModifier = 100;
                    CritChanceModifier = 1;
                    CritDamageModifier = 100;
                }
            }
        }

        internal class Bows : Weapons
        {
            public Bows()
            {
                DamageModifier = 4;
                AccuracyModifier = 30;
                CritChanceModifier = 0.7f;
                CritDamageModifier = 2.5f;
            }
            internal class WoodenBow : Bows
            {
                public WoodenBow()
                {
                    DamageModifier = 3;
                    AccuracyModifier = 25;
                    CritChanceModifier = 0.5f;
                    CritDamageModifier = 2;
                }
            }

            internal class IronBow : Bows
            {
                public IronBow()
                {
                    DamageModifier = 5;
                    AccuracyModifier = 35;
                    CritChanceModifier = 0.8f;
                    CritDamageModifier = 3;
                }
            }

            internal class SteelBow : Bows
            {
                public SteelBow()
                {
                    DamageModifier = 6;
                    AccuracyModifier = 40;
                    CritChanceModifier = 0.9f;
                    CritDamageModifier = 3.5f;
                }
            }

            internal class DebugBow : Bows
            {
                public DebugBow()
                {
                    DamageModifier = 100;
                    AccuracyModifier = 100;
                    CritChanceModifier = 1;
                    CritDamageModifier = 100;
                }
            }
        }
    }
}
