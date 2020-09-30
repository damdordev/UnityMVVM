using System;

namespace Damdor.Binding
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class Bind : Attribute
    {
        public string View { get; }
        public string Model { get; }

        public Bind(string view = null, string model = null)
        {
            View = view;
            Model = model;
        }
        
    }
    
}