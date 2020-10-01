using System.Collections.Generic;
using Damdor.Binding;
using UnityEngine.Events;

namespace Damdor.MVVM
{
    public class ViewModel : IUpdatable, IBindListener
    {
        public event UnityAction update;

        private List<IUpdatable> updatables;

        public virtual void OnBind()
        {
            if (updatables != null)
            {
                foreach (var u in updatables)
                {
                    u.update += SignalUpdate;
                }
            }
        }

        public virtual void OnUnbind()
        {
            if (updatables != null)
            {
                foreach (var u in updatables)
                {
                    u.update -= SignalUpdate;
                }
            }
        }

        protected void SignalUpdate() => update?.Invoke();

        protected void RegisterUpdatable(IUpdatable updatable)
        {
            if (updatables == null)
            {
                updatables = new List<IUpdatable>();
            }
            updatables.Add(updatable);
        }
    }
}