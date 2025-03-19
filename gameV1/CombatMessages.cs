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
        // Combat UI Screen
        public void CombatScreen(Player player, Monster monster)
        {
            Console.WriteLine($"\nName: {player.Name}\t\t\t\t\tName: {monster.Name}");
            Console.WriteLine($"Health: {player.Health}\t\t\t\t\tHealth: {monster.Health}");
            Console.WriteLine($"Mana: {player.Mana}\t\t\t\t\tMana: {monster.Mana}");
            Console.WriteLine($"Level: {player.Level}\t\t\t\t\tLevel: {monster.Level}");
            Console.WriteLine($"Weapon: {player.EquippedWeapon}");
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
            if (player.Health != player.MaxHealth)
            {
                player.Health += 10;
                if (player.Health > player.MaxHealth)
                {
                    player.Health = player.MaxHealth;
                }
            }
            Console.WriteLine("You have found a mana potion!");
            if (player.Mana != player.MaxMana)
            {
                player.Mana += 10;
                if (player.Mana > player.MaxMana)
                {
                    player.Mana = player.MaxMana;
                }
            }

            bool didPlayerLevel = player.GainExperience(player, monster.XpValue);
            if (didPlayerLevel == true)
            {
                player.LevelUp(player);
            }
            player.Gold += monster.GoldValue;
            Console.WriteLine("You have gained experience and gold!");
            player.GetPlayerDetails();
            Console.ReadKey();
        }
    }
}
