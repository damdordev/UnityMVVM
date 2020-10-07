using System;

namespace Damdor.Sample
{
    public class Server
    {
        public static PlayerModel Player { get; } = new PlayerModel("Janek", 11, PlayerModel.PlayerType.Wizard);
        public static PlayerModel Opponent { get; } = new PlayerModel("Kazik", 9, PlayerModel.PlayerType.Rouge);

        public static void IncreasePlayerPoints()
        {
            Player.Update(Player.Points + 1);
        }
        
    }
}