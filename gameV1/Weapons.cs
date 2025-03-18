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
    }
}
