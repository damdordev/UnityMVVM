using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Damdor.Binding;
using UnityEngine;

namespace Binding
{

    public class BindingGroup
    {
        private readonly List<BaseBinding> bindings = new List<BaseBinding>();

        public BindingGroup(Type viewType)
        {
            var modelViewType = viewType.BaseType.GetGenericArguments()[0];

            foreach (var (field, bind) in GetBindingsFields(viewType))
            {
                bindings.Add(BindingFactory.CreateBinding(bind, field,  modelViewType.GetProperty(GetBindPropertyName(field, bind)).GetMethod));
            }
        }

        public void AssignValues(object view, object model)
        {
            foreach (var binding in bindings)
            {
                binding.AssignValues(view, model);
            }
        }

        private static IEnumerable<(FieldInfo field, BindModel bin)> GetBindingsFields(Type modelType)
        {
            return modelType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                            .SelectMany(field => field.GetCustomAttributes<BindModel>().Select(bind => (field, bind)));
        }

        private static string GetBindPropertyName(FieldInfo field, BindModel bind)
        {
            return bind.Model ?? char.ToUpper(field.Name[0]) + field.Name.Substring(1);
        }

    }
}