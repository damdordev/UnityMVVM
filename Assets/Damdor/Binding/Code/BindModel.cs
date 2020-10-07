using System;

namespace Damdor.Binding
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class BindModel : Attribute
    {
        public string View { get; }
        public string Model { get; }

        public BindModel(string view = null, string model = null)
        {
            View = view;
            Model = model;
        }
        
    }
    
}