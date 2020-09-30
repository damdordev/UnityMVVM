using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Damdor.Binding;

namespace BindingGroup
{

    public class BindingGroup
    {
        private Type viewType;
        private Type modelViewType;
        
        private List<Damdor.Binding.Binding> bindings = new List<Damdor.Binding.Binding>();

        public BindingGroup(Type viewType)
        {
            this.viewType = viewType;
            modelViewType = viewType.BaseType.GetGenericArguments()[0];

            foreach (var (field, bind) in GetBindingsFields(viewType))
            {
                bindings.Add(BindingFactory.CreateBinding(bind, field,  modelViewType.GetProperty(GetBindPropertyName(field, bind)).GetMethod));
            }
        }

        public void Bind(object view, object modelView)
        {
            foreach (var binding in bindings)
            {
                binding.Bind(view, modelView);
            }
        }

        private static IEnumerable<(FieldInfo field, Bind bin)> GetBindingsFields(Type modelType)
        {
            return modelType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                            .SelectMany(field => field.GetCustomAttributes<Bind>().Select(bind => (field, bind)));
        }

        private static string GetBindPropertyName(FieldInfo field, Bind bind)
        {
            return bind.Model ?? char.ToUpper(field.Name[0]) + field.Name.Substring(1);
        }
        
    }
}