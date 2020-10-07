using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Damdor.Binding;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Binding
{

    public class BindingData { }
    

    public class BindingGroup
    {
        private class Data : BindingData
        {
            public Dictionary<Button, UnityAction> buttonActions = new Dictionary<Button, UnityAction>();
        }
        
        private readonly List<BaseBinding> bindings = new List<BaseBinding>();
        private readonly Dictionary<FieldInfo, MethodInfo> buttonBindings = new Dictionary<FieldInfo, MethodInfo>();
        private readonly object[] args = new object[0];

        public BindingGroup(Type viewType)
        {
            var modelViewType = viewType.BaseType.GetGenericArguments()[0];

            foreach (var (field, bind) in GetBindingsFields(viewType))
            {
                bindings.Add(BindingFactory.CreateBinding(bind, field,  modelViewType.GetProperty(GetBindPropertyName(field, bind)).GetMethod));
            }
            
            foreach (var (field, bind) in GetBindingsButtons(viewType))
            {
                buttonBindings.Add(field, modelViewType.GetMethod(GetActionMethodName(field, bind)));
            }
        }

        public BindingData Bind(object view, object model, BindingData bindingData)
        {
            var data = (bindingData as Data) ?? new Data();
            
            foreach (var binding in bindings)
            {
                binding.AssignValues(view, model);
            }

            foreach (var pair in buttonBindings)
            {
                var button = (Button) pair.Key.GetValue(view);
                var method = pair.Value;
                var action = new UnityAction(() => method.Invoke(model, args));
                
                data.buttonActions.Add(button, action);
                button.onClick.AddListener(action);
            }

            return data;
        }

        public void Unbind(BindingData bindingData)
        {
            var data = bindingData as Data;

            foreach (var pair in data.buttonActions)
            {
                pair.Key.onClick.RemoveListener(pair.Value);
            }
            data.buttonActions.Clear();
        }

        private static IEnumerable<(FieldInfo field, BindModel bind)> GetBindingsFields(Type modelType)
        {
            return modelType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                            .SelectMany(field => field.GetCustomAttributes<BindModel>().Select(bind => (field, bind)));
        }
        
        private static IEnumerable<(FieldInfo field, BindAction bind)> GetBindingsButtons(Type modelType)
        {
            return modelType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                            .SelectMany(field => field.GetCustomAttributes<BindAction>().Select(bind => (field, bind)));
        }

        private static string GetBindPropertyName(FieldInfo field, BindModel bind)
        {
            return bind.Model ?? char.ToUpper(field.Name[0]) + field.Name.Substring(1);
        }
        
        private static string GetActionMethodName(FieldInfo field, BindAction bind)
        {
            return bind.Action ?? field.Name.Substring("button_".Length);
        }

    }
}