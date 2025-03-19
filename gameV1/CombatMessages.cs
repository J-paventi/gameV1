using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace gameV1
{
    internal class CombatMessages
    {
        // Combat UI Screens
        public void CombatScreen(Player player, Monster monster, bool playerTurn)
        {
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine($"| Name: {player.Name, -20} | Name: {monster.Name, -20} |");
            Console.WriteLine($"| Health: {player.Health, -18} | Health: {monster.Health, -18} |");
            Console.WriteLine($"| Mana: {player.Mana, -20} | Mana: {monster.Mana, -20} |");
            Console.WriteLine($"| Level: {player.Level, -19} | Level: {monster.Level, -19} |");
            Console.WriteLine($"| Weapon: {player.EquippedWeapon, -18} | Weapon: {monster.MonsterWeapon, -18} |");
            Console.WriteLine("-----------------------------------------------------------");
        }

        public string PlayerCombatMenu()
        {
            Console.WriteLine("\n-------------");
            Console.WriteLine("| 1. Attack |");
            //Console.WriteLine("2. Use Health Potion");
            //Console.WriteLine("3. Use Mana Potion");
            //Console.WriteLine("4. Run Away");
            Console.WriteLine("-------------");
            string? playerChoice = Console.ReadLine();
            while (string.IsNullOrEmpty(playerChoice))
            {
                Console.WriteLine("Invalid choice. Please try again.");
                playerChoice = Console.ReadLine();
            }
            return playerChoice;
        }

        // Beginning of Combat
        public void MonsterAppearsMsg(Monster monster)
        {
            Console.WriteLine($"\nA wild {monster.Name} appears!\n");
        }

        public void CombatInitiativeMessage(Player player, Monster monster,
            int playerInitiative, int monsterInitiative)
        {
            Console.WriteLine($"\n{player.Name} Initiative: {playerInitiative}");
            Console.WriteLine($"\n{monster.Name} Initiative: {monsterInitiative}\n");
        }

        public void PlayerInitiativeMessage(Player player)
        {
            Console.WriteLine($"{player.Name} goes first!\n");
        }

        public void MonsterInitiativeMessage(Monster monster)
        {
            Console.WriteLine($"{monster.Name} goes first!\n");
        }

        // Player Combat Actions
        public void PlayerAttackMsg(Player player, Monster monster)
        {
            Console.WriteLine($"{player.Name} attacks " +
                $"{monster.Name} with {player.EquippedWeapon.Key}!\n");
        }

        public void PlayerCriticalHitMsg(Player player)
        {
            Console.WriteLine($"{player.Name} lands a critical hit!\n");
        }

        public void PlayerDamageMsg(Monster monster, int attackDmg)
        {
            Console.WriteLine($"{monster.Name} takes {attackDmg} damage!\n");
        }

        public void PlayerMissMsg(Player player)
        {
            Console.WriteLine($"{player.Name} misses!\n");
        }

        // Monster Combat Actions
        public void MonsterAttackMsg(Monster monster, Player player)
        {
            Console.WriteLine($"{monster.Name} attacks {player.Name}!\n");
        }

        public void MonsterCriticalHitMsg(Monster monster)
        {
            Console.WriteLine($"{monster.Name} lands a critical hit!\n");
        }

        public void MonsterDamageMsg(Player player, int attackDmg)
        {
            Console.WriteLine($"{player.Name} takes {attackDmg} damage!\n");
        }

        public void MonsterMissMsg(Monster monster)
        {
            Console.WriteLine($"{monster.Name} misses!\n");
        }

        // End of Combat
        public void MonsterDefeatedMsg(Monster monster)
        {
            Console.WriteLine($"{monster.Name} has been defeated!\n");
        }

        public void PlayerDefeatedMsg(Player player)
        {
            Console.WriteLine($"{player.Name} has been defeated!\n");
        }

        public void EndCombat()
        {
            Console.WriteLine("The battle has ended!");
            Console.ReadKey();
        }

        // Loot
        public void Loot(Player player, Monster monster)
        {
            Console.WriteLine("\nYou have looted the monster!");
            Console.WriteLine("You have found a health potion!");
            AddToPlayerInventory(player, "Health Potion", 1);
            Console.WriteLine("You have found a mana potion!");
            AddToPlayerInventory(player, "Mana Potion", 1);
            bool didPlayerLevel = player.GainExperience(player, monster.XpValue);
            if (didPlayerLevel == true)
            {
                player.LevelUp(player);
            }
            AddToPlayerInventory(player, "Gold", monster.GoldValue);
            Console.WriteLine("You have gained experience and gold!");
            player.GetPlayerDetails();
            Console.ReadKey();
        }

        public void AddToPlayerInventory(Player player, string key, int value)
        {
            if (player.Inventory.ContainsKey(key))
            {
                player.Inventory[key] += value;
            }
            else
            {
                player.Inventory.Add(key, value);
            }
        }
    }
}
