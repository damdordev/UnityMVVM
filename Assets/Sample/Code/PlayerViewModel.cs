using Damdor.MVVM;

namespace Damdor.Sample
{
    public class PlayerViewModel : ViewModel
    {
        public string Nick => playerModel.Nick;
        public string Points => playerModel.Points.ToString();
        
        private readonly PlayerModel playerModel;

        public PlayerViewModel(PlayerModel model)
        {
            playerModel = model;
        }

    }
}