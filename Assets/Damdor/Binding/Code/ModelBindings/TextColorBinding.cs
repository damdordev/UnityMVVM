using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

namespace Damdor.Binding
{
    public class TextColorBinding : GenericBinding<Text, Color>
    {
        public TextColorBinding(BindModel bind, FieldInfo getViewField, MethodBase getModelField)
            : base(bind, getViewField, getModelField) { }

        protected override void Bind(Text view, Color model)
        {
            view.color = model;
        }
    }
}