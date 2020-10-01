using UnityEngine.Events;

namespace Damdor.Binding
{
    public interface IUpdatable
    {
        event UnityAction update;
    }
}