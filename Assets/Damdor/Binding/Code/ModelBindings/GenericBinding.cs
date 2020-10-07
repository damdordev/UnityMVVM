using System.Reflection;
using UnityEngine;

namespace Damdor.Binding
{
    
    public abstract class GenericBinding<TView, TModel> : BaseBinding
    {
        protected GenericBinding(BindModel bind, FieldInfo getViewField, MethodBase getModelField)
            : base(bind, getViewField, getModelField)
        {
        }
        
        public override void AssignValues(object view, object viewModel)
        {
            Bind(GetViewFieldValue<TView>(view), GetViewModelFieldValue<TModel>(viewModel));
        }

        protected abstract void Bind(TView view, TModel model);
    }
    
}