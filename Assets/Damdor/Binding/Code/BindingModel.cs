using System;
using System.Collections.Generic;
using Binding;
using UnityEngine.UI;

namespace Damdor.Binding
{

    public class BindingModel
    {
        private static readonly Dictionary<Type, BindingGroup> bindings = new Dictionary<Type, BindingGroup>();

        private BindingGroup binding;
        private BindingData data;
        
        private object view;
        private object model;
        private bool isBinded;

        public BindingModel(object view)
        {
            this.view = view;
            var type = view.GetType();
            InitializeBindingForType(view.GetType());
            binding = bindings[type];
        }

        public void Bind(object model)
        {
            Unbind();
            this.model = model;
            UpdateValues();
            if (model is IUpdatable updatable)
            {
                updatable.update += UpdateValues;
            }

            if (model is IBindListener listener)
            {
                listener.OnBind();
            }

            isBinded = true;
        }

        public void Unbind()
        {
            if (!isBinded)
            {
                return;
            }
            
            binding.Unbind(data);

            if (model is IUpdatable updatable)
            {
                updatable.update -= UpdateValues;
            }

            if (model is IBindListener listener)
            {
                listener.OnUnbind();
            }

            model = null;
            isBinded = false;
        }

        private void UpdateValues()
        {
            data = binding.Bind(view, model, data);
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
