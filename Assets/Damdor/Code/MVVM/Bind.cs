using System;

namespace Damdor.MVVM
{
    [AttributeUsage(AttributeTargets.Field)]
    public class Bind : Attribute
    {
        public string PropertyName { get; }

        public Bind(string propertyName = null)
        {
            PropertyName = propertyName;
        }
        
    }
    
}