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
        private bool isPlayerTurn;

        public int Round { get => round; set => round = value; }
        public int MonsterInitiative { get => monsterInitiative; set => monsterInitiative = value; }
        public int PlayerInitiative { get => playerInitiative; set => playerInitiative = value; }
        public bool IsPlayerTurn { get => isPlayerTurn; set => isPlayerTurn = value; }

        public Combat(Monster monster, Player player)
        {
            this.monster = monster;
            this.player = player;
        }

        public void StartCombat()
        {
            TextUI textUI = new();
            CombatMessages combatMsg = new();
            monster = monster.GetRandomMonster();
            monster.GetMonsterDetails();
            Console.Clear();
            combatMsg.MonsterAppearsMsg(monster);
            RollInitiative();
            combatMsg.CombatScreen(player, monster, IsPlayerTurn);
            Console.Clear();
            combatMsg.EndCombat();
            if(monster.Health <= 0)
            {
                combatMsg.Loot(player, monster);
            }
            else
            {
                Console.WriteLine("You have been defeated!");
                Console.ReadKey();
            }
        }

        public void RollInitiative()
        {
            TextUI textUI = new();
            CombatMessages combatMsg = new();
            Console.Clear();
            Random random = new();
            int playerInitiative = random.Next(1, 21);
            int monsterInitiative = random.Next(1, 21);
            PlayerInitiative = playerInitiative;
            MonsterInitiative = monsterInitiative;
            combatMsg.CombatInitiativeMessage(player, monster, playerInitiative, monsterInitiative);
            if (playerInitiative > monsterInitiative)
            {
                combatMsg.PlayerInitiativeMessage(player);
                Console.ReadKey();
                PlayerTurn();
            }
            else
            {
                combatMsg.MonsterInitiativeMessage(monster);
                Console.ReadKey();
                MonsterTurn();
            }
        }

        public void PlayerTurn()
        {
            IsPlayerTurn = true;
            TextUI textUI = new();
            CombatMessages combatMsg = new();
            int playerChoice = -1;
            Console.Clear();

            combatMsg.CombatScreen(player, monster, IsPlayerTurn);
            if(isPlayerTurn == true)
            {
                string playerMenuChoice = combatMsg.PlayerCombatMenu();
                int.TryParse(playerMenuChoice, out int result);
                playerChoice = result;
                Console.Clear();
            }

            if(playerChoice == 1)       // Attack
            {
                combatMsg.PlayerAttackMsg(player, monster);
                if (HitOrMissPlayer(player, monster) == 1)
                {
                    bool isCrit;
                    int attackDmg = player.CalculateDamage();
                    if ((isCrit = player.CritCheck()) == true)
                    {
                        attackDmg = Player.CalculateCritDamage(attackDmg);
                        combatMsg.PlayerCriticalHitMsg(player);
                        Console.ReadKey();
                    }
                    monster.TakeDamage(attackDmg);
                    combatMsg.PlayerDamageMsg(monster, attackDmg);
                    combatMsg.CombatScreen(player, monster, IsPlayerTurn);
                }
                else
                {
                    combatMsg.PlayerMissMsg(player);
                    combatMsg.CombatScreen(player, monster, IsPlayerTurn);
                }
            }
            if(playerChoice == 2)       // Cast Spell
            {
                Console.WriteLine("Not yet implemented.");
            }
            if (playerChoice == 3)      // Inventory
            {
                Console.WriteLine("Not yet implemented.");
            }
            if (playerChoice == 4)      // Run Away
            {
                Console.WriteLine("Not yet implemented.");
            }
            if (monster.Health <= 0)    // Monster Defeated
            {
                Console.ReadKey();
                combatMsg.MonsterDefeatedMsg(monster);
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
            IsPlayerTurn = false;
            CombatMessages combatMsg = new();
            combatMsg.MonsterAttackMsg(monster, player);
            if (HitOrMissMonster(player, monster) == 1)
            {
                int attackDmg = monster.AttackDmg();
                player.TakeDamage(attackDmg);
                combatMsg.MonsterDamageMsg(player, attackDmg);
            }
            else
            {
                combatMsg.MonsterMissMsg(monster);
            }
            combatMsg.CombatScreen(player, monster, IsPlayerTurn);
            if (player.Health <= 0)     // Player Defeated
            {
                combatMsg.PlayerDefeatedMsg(player);
            }
            else
            {
                Console.ReadKey();
                PlayerTurn();
            }
        }

        public static int HitOrMissPlayer(Player player, Monster monster)
        {
            Random random = new();
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

        public static int HitOrMissMonster(Player player, Monster monster)
        {
            Random random = new();
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
