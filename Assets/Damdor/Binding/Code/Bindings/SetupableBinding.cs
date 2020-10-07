using System.Reflection;
using UnityEngine.UI;

namespace Damdor.Binding
{
    public class SetupableBinding<TView, TModel> : GenericBinding<TView, TModel> where TView : ISetupable<TModel>
    {
        public SetupableBinding(BindModel bind, FieldInfo getViewField, MethodBase getModelField)
            : base(bind, getViewField, getModelField) { }

        protected override void Bind(TView view, TModel model)
        {
            view.Setup(model);
        }
    }
}