using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

namespace Damdor.Binding
{

    public class BindingFactory
    {

        public static BaseBinding CreateBinding(Bind bind, FieldInfo field, MethodInfo getModel)
        {
            if (field.FieldType == typeof(Text) && getModel.ReturnType == typeof(string))
            {
                return new TextBinding(bind, field, getModel);
            }
            else if (field.FieldType == typeof(Text) && getModel.ReturnType == typeof(Color))
            {
                return new TextColorBinding(bind, field, getModel);
            }
            
            throw new ArgumentException("Wrong binding");
        }
        
    }
    
}
