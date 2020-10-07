using System;
using Damdor.Binding;
using UnityEngine;
using UnityEngine.UI;

namespace Damdor.Sample
{

    public class SummaryWindow : Window<SummaryViewModel>
    {
        [SerializeField, BindModel]
        private PlayerView player;
        [SerializeField, BindModel]
        private PlayerView opponent;
        [SerializeField]
        private Button increasePlayerPointsButton;

        private void Awake()
        {
            increasePlayerPointsButton.onClick.AddListener(() => model.IncreasePlayerPoints());
        }
        
        private void Start()
        {
            Setup(new SummaryViewModel(Server.Player, Server.Opponent));
        }
    }
}