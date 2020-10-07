using System;
using System.Reflection;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;

namespace Damdor.Binding
{

    public class BindingFactory
    {
        private static readonly object[] args = new object[3];


        public static BaseBinding CreateBinding(BindModel bind, FieldInfo field, MethodInfo getModel)
        {
            var viewType = field.FieldType;
            var modelType = getModel.ReturnType;
            
            if (viewType == typeof(Text) && modelType == typeof(string))
            {
                return new TextBinding(bind, field, getModel);
            }
            else if (viewType == typeof(Text) && modelType == typeof(Color))
            {
                return new TextColorBinding(bind, field, getModel);
            }

            var setupType = typeof(ISetupable<>).MakeGenericType(modelType);
            if (setupType.IsAssignableFrom(viewType))
            {
                args[0] = bind;
                args[1] = field;
                args[2] = getModel;
                var result = (BaseBinding) Activator.CreateInstance(typeof(SetupableBinding<,>).MakeGenericType(viewType, modelType), args);
                args[0] = args[1] = args[2] = null;
                return result;
            }

            throw new ArgumentException("Wrong binding");
        }
        
    }
    
}
