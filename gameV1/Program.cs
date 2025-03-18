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
            //player.GetPlayerDetails();
            player.ChangePlayerWeapon(systemMessage.ChooseStarterWeapon(player.Name));
            //player.GetPlayerDetails();
            Combat slimeFight = new Combat(new Slime(), player);
            slimeFight.StartCombat();
        }
    }
}
