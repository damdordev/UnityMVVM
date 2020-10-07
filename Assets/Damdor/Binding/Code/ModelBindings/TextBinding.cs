using System.Reflection;
using UnityEngine.UI;

namespace Damdor.Binding
{
    public class TextBinding : GenericBinding<Text, string>
    {
        public TextBinding(BindModel bind, FieldInfo getViewField, MethodBase getModelField)
            : base(bind, getViewField, getModelField) { }

        protected override void Bind(Text view, string model)
        {
            view.text = model;
        }
    }
}