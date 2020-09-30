using Damdor.Binding;
using Damdor.MVVM;
using UnityEngine;
using UnityEngine.UI;


namespace Damdor.Sample
{

    public class PlayerView : View<PlayerViewModel>
    {
        [SerializeField, Bind]
        private Text nick;
        [SerializeField, Bind, Bind( model: "Color")]
        private Text points;
    }

}