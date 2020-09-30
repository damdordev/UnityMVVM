using System.Reflection;

namespace Damdor.Binding
{
    
    public abstract class GenericBinding<TView, TModel> : Binding
    {
        protected GenericBinding(Bind bind, FieldInfo getViewField, MethodBase getModelField)
            : base(bind, getViewField, getModelField)
        {
        }
        
        public override void Bind(object view, object viewModel)
        {
            Bind(GetViewFieldValue<TView>(view), GetViewModelFieldValue<TModel>(viewModel));
        }

        protected abstract void Bind(TView view, TModel model);
    }
    
}