using System;
using System.Collections.Generic;
using System.Reflection;

namespace Damdor.MVVM
{

    public class BindingGroup
    {
        private Type viewType;
        private Type modelViewType;
        
        private List<Binding> bindings = new List<Binding>();

        public BindingGroup(Type viewType)
        {
            this.viewType = viewType;
            modelViewType = viewType.BaseType.GetGenericArguments()[0];

            foreach (var field in viewType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic))
            {
                var bind = field.GetCustomAttribute<Bind>();
                if (bind == null)
                {
                    continue;
                }

                var propertyName = bind.PropertyName;
                if (propertyName == null)
                {
                    propertyName = char.ToUpper(field.Name[0]) + field.Name.Substring(1);
                }
                
                bindings.Add(new TextBinding(viewType, modelViewType, field, propertyName));
            }

        }

        public void Bind(object view, object modelView)
        {
            foreach (var binding in bindings)
            {
                binding.Bind(view, modelView);
            }
        }
        
    }
}