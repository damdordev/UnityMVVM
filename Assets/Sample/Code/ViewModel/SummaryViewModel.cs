using Damdor.MVVM;

namespace Damdor.Sample
{
    public class SummaryViewModel : ViewModel
    {
        public PlayerViewModel Player { get; }
        public PlayerViewModel Opponent { get; }
        
        public SummaryViewModel(PlayerModel player, PlayerModel opponent)
        {
            Player = new PlayerViewModel(player);
            Opponent = new PlayerViewModel(opponent);
        }

        public void IncreasePlayerPoints() => Server.IncreasePlayerPoints();
    }
}