using System.Collections.Generic;
using Damdor.MVVM;
using UnityEngine;

namespace Damdor.Sample
{
    public class PlayerViewModel : ViewModel
    {
        private Dictionary<PlayerModel.PlayerType, Color> playerTypeToColor =
            new Dictionary<PlayerModel.PlayerType, Color>
            {
                {PlayerModel.PlayerType.Warrior, Color.red},
                {PlayerModel.PlayerType.Wizard, Color.blue},
                {PlayerModel.PlayerType.Rouge, Color.green},
            };
        
        public string Nick => model.Nick;
        public string Points => model.Points.ToString();
        public Color Color => playerTypeToColor[model.Type];
        
        private readonly PlayerModel model;

        public PlayerViewModel(PlayerModel model)
        {
            this.model = model;
            RegisterUpdatable(model);
        }
    }
}