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
        private Slime slime;
        private Player player;
        private int round;
        private int slimeInitiative;
        private int playerInitiative;

        public int Round { get => round; set => round = value; }
        public int SlimeInitiative { get => slimeInitiative; set => slimeInitiative = value; }
        public int PlayerInitiative { get => playerInitiative; set => playerInitiative = value; }

        public Combat() { }

        public Combat(Slime slime, Player player)
        {
            this.slime = slime;
            this.player = player;
        }

        public void StartCombat()
        {
            Console.Clear();
            Console.WriteLine("\nA slime appears!");
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
            int SlimeInitiative = random.Next(1, 21);
            CombatDetails();
            if (PlayerInitiative > SlimeInitiative)
            {
                Console.WriteLine($"{player.Name} goes first!\n");
                Console.ReadKey();
                PlayerTurn();
            }
            else
            {
                Console.WriteLine($"{slime.Name} goes first!\n");
                Console.ReadKey();
                SlimeTurn();
            }
        }

        public void PlayerTurn()
        {
            Console.Clear();
            Console.WriteLine($"\n{player.Name} attacks {slime.Name} with {player.EquippedWeapon.Key}!");
            if(HitOrMissPlayer(player, slime) == 1)
            {
                bool isCrit;
                int attackDmg = player.CalculateDamage();
                if ((isCrit = player.CritCheck()) == true)
                {
                    attackDmg = player.CalculateCritDamage(attackDmg);
                    Console.WriteLine("Critical hit!");
                }
                slime.TakeDamage(attackDmg);
                Console.WriteLine($"{slime.Name} takes {attackDmg}!");
            }
            else
            {
                Console.WriteLine($"{player.Name} misses!");
            }
            CombatScreen();
            if (slime.Health <= 0)
            {
                Console.WriteLine($"{slime.Name} has been defeated!");
            }
            else
            {
                Console.ReadKey();
                SlimeTurn();
            }
        }

        public void SlimeTurn()
        {
            Console.Clear();
            Console.WriteLine($"\n{slime.Name} attacks {player.Name}!");
            if(HitOrMissSlime(player, slime) == 1)
            {
                int attackDmg = slime.AttackDmg();
                player.TakeDamage(attackDmg);
                Console.WriteLine($"{player.Name} takes {attackDmg}!");
            }
            else
            {
                Console.WriteLine($"{slime.Name} misses!");
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
            Console.WriteLine($"{slime.Name} Initiative: {SlimeInitiative}");
        }

        public void CombatScreen()
        {
            Console.WriteLine($"\nName: {player.Name}\t\t\t\t\tName: {slime.Name}");
            Console.WriteLine($"Health: {player.Health}\t\t\t\t\tHealth: {slime.Health}");
            Console.WriteLine($"Mana: {player.Mana}\t\t\t\t\tMana: {slime.Mana}");
            Console.WriteLine($"Level: {player.Level}\t\t\t\t\tLevel: {slime.Level}");
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
            Console.WriteLine("\nYou have looted the slime!");
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
            player.Experience += slime.XpValue;
            player.Gold += slime.GoldValue;
            Console.WriteLine("You have gained experience and gold!");
            player.GetPlayerDetails();
            Console.ReadKey();
        }

        public int HitOrMissPlayer(Player player, Slime slime)
        {
            Random random = new Random();
            int hitOrMiss = random.Next(1, 101);
            if (hitOrMiss <= player.Accuracy - slime.Evasion)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int HitOrMissSlime(Player player, Slime slime)
        {
            Random random = new Random();
            int hitOrMiss = random.Next(1, 101);
            if (hitOrMiss <= slime.Accuracy - player.Evasion)
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
