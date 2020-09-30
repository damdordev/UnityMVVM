using System;
using System.Collections.Generic;
using UnityEngine;

namespace Damdor.MVVM
{
    public abstract class View<TViewModel> : MonoBehaviour, ISetupable<TViewModel>
    {
        private static Dictionary<Type, BindingGroup> bindings = new Dictionary<Type, BindingGroup>();
        
        public void Setup(TViewModel model)
        {
            InitializeBindingForType(GetType());
            bindings[GetType()].Bind(this, model);
        }

        private static void InitializeBindingForType(Type type)
        {
            if (bindings.ContainsKey(type))
            {
                return;
            }
            
            bindings[type] = new BindingGroup(type);
        }
        
    }
}