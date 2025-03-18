using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace gameV1
{
    internal class Combat
    {
        private Monster monster;
        private Player player;
        private int round;
        private int monsterInitiative;
        private int playerInitiative;

        public int Round { get => round; set => round = value; }
        public int MonsterInitiative { get => monsterInitiative; set => monsterInitiative = value; }
        public int PlayerInitiative { get => playerInitiative; set => playerInitiative = value; }

        public Combat(Monster monster, Player player)
        {
            this.monster = monster;
            this.player = player;
        }

        public void StartCombat()
        {
            monster = monster.GetRandomMonster();
            monster.GetMonsterDetails();
            Console.Clear();
            Console.WriteLine($"\nA {monster.Name} appears!");
            RollInitiative();
            CombatScreen();
            Console.Clear();
            EndCombat();
            Loot();
        }

        public void RollInitiative()
        {
            Console.Clear();
            Random random = new Random();
            int PlayerInitiative = random.Next(1, 21);
            int MonsterInitiative = random.Next(1, 21);
            CombatDetails();
            if (PlayerInitiative > MonsterInitiative)
            {
                Console.WriteLine($"{player.Name} goes first!\n");
                Console.ReadKey();
                PlayerTurn();
            }
            else
            {
                Console.WriteLine($"{monster.Name} goes first!\n");
                Console.ReadKey();
                MonsterTurn();
            }
        }

        public void PlayerTurn()
        {
            Console.Clear();
            Console.WriteLine($"\n{player.Name} attacks {monster.Name} with {player.EquippedWeapon.Key}!");
            if(HitOrMissPlayer(player, monster) == 1)
            {
                bool isCrit;
                int attackDmg = player.CalculateDamage();
                if ((isCrit = player.CritCheck()) == true)
                {
                    attackDmg = player.CalculateCritDamage(attackDmg);
                    Console.WriteLine("Critical hit!");
                }
                monster.TakeDamage(attackDmg);
                Console.WriteLine($"{monster.Name} takes {attackDmg}!");
            }
            else
            {
                Console.WriteLine($"{player.Name} misses!");
            }
            CombatScreen();
            if (monster.Health <= 0)
            {
                Console.WriteLine($"{monster.Name} has been defeated!");
            }
            else
            {
                Console.ReadKey();
                MonsterTurn();
            }
        }

        public void MonsterTurn()
        {
            Console.Clear();
            Console.WriteLine($"\n{monster.Name} attacks {player.Name}!");
            if(HitOrMissMonster(player, monster) == 1)
            {
                int attackDmg = monster.AttackDmg();
                player.TakeDamage(attackDmg);
                Console.WriteLine($"{player.Name} takes {attackDmg}!");
            }
            else
            {
                Console.WriteLine($"{monster.Name} misses!");
            }
            CombatScreen();
            if (player.Health <= 0)
            {
                Console.WriteLine($"{player.Name} has been defeated!");
            }
            else
            {
                Console.ReadKey();
                PlayerTurn();
            }
        }

        public void CombatDetails()
        {
            Console.WriteLine($"\n{player.Name} Initiative: {PlayerInitiative}");
            Console.WriteLine($"{monster.Name} Initiative: {MonsterInitiative}");
        }

        public void CombatScreen()
        {
            Console.WriteLine($"\nName: {player.Name}\t\t\t\t\tName: {monster.Name}");
            Console.WriteLine($"Health: {player.Health}\t\t\t\t\tHealth: {monster.Health}");
            Console.WriteLine($"Mana: {player.Mana}\t\t\t\t\tMana: {monster.Mana}");
            Console.WriteLine($"Level: {player.Level}\t\t\t\t\tLevel: {monster.Level}");
            Console.WriteLine($"Weapon: {player.EquippedWeapon}");
        }

        public void EndCombat()
        {
            Console.WriteLine("The battle has ended!");
            CombatScreen(); 
            Console.ReadKey();
        }

        public void Loot()
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
            player.Experience += monster.XpValue;
            player.Gold += monster.GoldValue;
            Console.WriteLine("You have gained experience and gold!");
            player.GetPlayerDetails();
            Console.ReadKey();
        }

        public int HitOrMissPlayer(Player player, Monster monster)
        {
            Random random = new Random();
            int hitOrMiss = random.Next(1, 101);
            if (hitOrMiss <= player.Accuracy - monster.Evasion)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int HitOrMissMonster(Player player, Monster monster)
        {
            Random random = new Random();
            int hitOrMiss = random.Next(1, 101);
            if (hitOrMiss <= monster.Accuracy - player.Evasion)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
