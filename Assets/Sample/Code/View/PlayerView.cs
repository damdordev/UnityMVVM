using Damdor.Binding;
using Damdor.MVVM;
using UnityEngine;
using UnityEngine.UI;


namespace Damdor.Sample
{

    public class PlayerView : View<PlayerViewModel>
    {
        [SerializeField, BindModel]
        private Text nick;
        [SerializeField, BindModel, BindModel( model: "Color")]
        private Text points;
    }

}