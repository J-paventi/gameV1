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
            TextUI textUI = new();
            CombatMessages combatMsg = new();
            monster = monster.GetRandomMonster();
            monster.GetMonsterDetails();
            Console.Clear();
            combatMsg.MonsterAppearsMsg(monster);
            RollInitiative();
            combatMsg.CombatScreen(player, monster);
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
            TextUI textUI = new();
            CombatMessages combatMsg = new();
            Console.Clear();
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
            }
            else
            {
                combatMsg.PlayerMissMsg(player);
            }
            combatMsg.CombatScreen(player, monster);
            if (monster.Health <= 0)
            {
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
            combatMsg.CombatScreen(player, monster);
            if (player.Health <= 0)
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
