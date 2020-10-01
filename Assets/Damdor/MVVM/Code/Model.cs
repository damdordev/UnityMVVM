using Damdor.Binding;
using UnityEngine.Events;

namespace Damdor.MVVM
{
    public class Model : IUpdatable
    {
        public event UnityAction update;

        protected void SignalUpdate() => update?.Invoke();
    }
}