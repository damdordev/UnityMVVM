using Damdor.MVVM;
using UnityEngine;

namespace Damdor.Sample
{
    public class PlayerViewModel : ViewModel
    {
        public string Nick => playerModel.Nick;
        public string Points => playerModel.Points.ToString();
        public Color Color => playerModel.Color;
        
        private readonly PlayerModel playerModel;

        public PlayerViewModel(PlayerModel model)
        {
            playerModel = model;
        }

    }
}