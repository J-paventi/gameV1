namespace gameV1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            TextUI systemMessage = new TextUI();
            systemMessage.DisplayWelcomeMsg();
            player.Name = systemMessage.GetPlayerName();
            player.ChangePlayerWeapon(systemMessage.ChooseStarterWeapon(player.Name));
            while(player.Health > 0)
            {
                Combat monsterFight = new Combat(new Monster(), player);
                monsterFight.StartCombat();
            }
        }
    }
}
