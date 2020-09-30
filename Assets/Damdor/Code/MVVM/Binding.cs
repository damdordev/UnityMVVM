using System;
using System.Reflection;
using UnityEngine.UI;

namespace Damdor.MVVM
{
    public abstract class Binding
    {
        private readonly object[] args = new object[0];
        
        private readonly FieldInfo getViewFieldValue;
        private readonly MethodBase getViewModelFieldValue;

        public Binding(Type viewType, Type modelViewType, FieldInfo getViewFieldValue, string modelViewFieldName)
        {
            this.getViewFieldValue = getViewFieldValue;
            getViewModelFieldValue = modelViewType.GetProperty(modelViewFieldName)?.GetMethod;
        }

        public abstract void Bind(object view, object viewModel);

        protected T GetViewFieldValue<T>(object view) => (T) getViewFieldValue.GetValue(view);
        protected T GetViewModelFieldValue<T>(object viewModel) => (T) getViewModelFieldValue.Invoke(viewModel, args);
    }

    public class TextBinding : Binding
    {

        public TextBinding(Type viewType, Type modelViewType, FieldInfo getViewFieldValue, string modelViewFieldName)
            : base(viewType, modelViewType, getViewFieldValue, modelViewFieldName)
        {
        }
        
        public override void Bind(object view, object viewModel)
        {
            GetViewFieldValue<Text>(view).text = GetViewModelFieldValue<string>(viewModel);
        }
    }
    
}