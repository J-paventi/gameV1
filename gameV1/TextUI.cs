using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameV1
{
    internal class TextUI
    {
        public void DisplayWelcomeMsg()
        {
            Console.WriteLine("Welcome to GAME NOT NAMED YET.\n");
            Console.WriteLine("Press any key to continue\n");
            Console.ReadKey();
        }

        public string GetPlayerName()
        {
            Console.WriteLine("Please enter a name for your character.\n");
            Console.Write("Name: ");
            string? inputName = Console.ReadLine();
            while (string.IsNullOrEmpty(inputName))
            {
                if (string.IsNullOrEmpty(inputName))
                {
                    Console.WriteLine("\nName cannot be empty.\n");
                    Console.Write("Name: ");
                    inputName = Console.ReadLine();
                }
            }

            return inputName;
        }

        public string ChooseStarterWeapon(string playerName)
        {
            Console.WriteLine($"\nWelcome, {playerName}. Please choose a weapon.\n");
            Weapons weapons = new Weapons();
            var filteredWeapons = weapons.StarterWeapons();

            foreach (var weapon in filteredWeapons)
            {
                Console.WriteLine($"{weapon.Key} - {weapon.Value} damage");
            }

            string? weaponChoice = null;
            while (true)
            {
                Console.Write("\nWeapon: ");
                weaponChoice = Console.ReadLine();
                if (weaponChoice != null && 
                    filteredWeapons.Any(w => w.Key.Equals(weaponChoice, StringComparison.OrdinalIgnoreCase)))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid weapon choice. Please try again.\n");
                }
            }

            return weaponChoice;
        }
    }
}
