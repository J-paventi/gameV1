using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameV1
{
    internal class Weapons
    {
        // Class members
        private Dictionary<string, int> weaponList;

        // Mutators and Accessors
        public Dictionary<string, int> WeaponList { get => weaponList; }

        public Weapons() 
        {
            weaponList = new Dictionary<string, int>()
            {
                { "Knuckles", 2 },
                { "Wooden Sword", 5 },
                { "Wooden Spear", 3 },
                { "Wooden Bow", 5 },
                { "Knuckle Dusters", 3 },
                { "Sword", 7 },
                { "Spear", 5 },
                { "Bow", 7 },
                { "Iron Knuckles", 6 },
                { "Iron Sword", 10 },
                { "Iron Spear", 7 },
                { "Iron Bow", 10 },
                { "Steel Knuckles", 8 },
                { "Steel Sword", 15 },
                { "Steel Spear", 12 },
                { "Steel Bow", 15 },
                { "Doom Laser", 100 },
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
