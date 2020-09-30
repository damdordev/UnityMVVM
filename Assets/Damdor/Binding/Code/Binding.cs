using System;
using System.Reflection;

namespace Damdor.Binding
{
    public abstract class Binding
    {
        private readonly object[] args = new object[0];
        
        private readonly FieldInfo getViewField;
        private readonly MethodBase getModelField;

        protected Binding(Bind bind, FieldInfo getViewField, MethodBase getModelField)
        {
            this.getViewField = getViewField;
            this.getModelField = getModelField;
        }

        public abstract void Bind(object view, object viewModel);

        protected T GetViewFieldValue<T>(object view) => (T) getViewField.GetValue(view);
        protected T GetViewModelFieldValue<T>(object viewModel) => (T) getModelField.Invoke(viewModel, args);
    }
    
}