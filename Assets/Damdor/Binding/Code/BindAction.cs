using System;

namespace Damdor.Binding
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class BindAction : Attribute
    {
        public string View { get; }
        public string Action { get; }

        public BindAction(string view = null, string action = null)
        {
            View = view;
            action = action;
        }
        
    }
    
}