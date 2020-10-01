using System;
using System.Collections.Generic;
using Binding;

namespace Damdor.Binding
{

    public class BindingModel
    {
        private static readonly Dictionary<Type, BindingGroup> bindings = new Dictionary<Type, BindingGroup>();

        private BindingGroup binding;
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
            if (isBinded)
            {
                return;
            }

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
            binding.AssignValues(view, model);
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
