using Damdor.Binding;
using UnityEngine;

namespace Damdor.MVVM
{
    public abstract class View<TModel> : MonoBehaviour, ISetupable<TModel> where TModel : class

    {
        protected BindingModel binding => _binding ?? (_binding = new BindingModel(this));

        private BindingModel _binding;
        protected TModel model;

        public void Setup(TModel model)
        {
            Unbind();
            this.model = model;
            if (isActiveAndEnabled)
            {
                Bind();
            }
        }

        protected virtual void OnEnable()
        {
            if (model != null)
            {
                Bind();
            }
        }

        protected virtual void OnDisable()
        {
            Unbind();
        }

        protected virtual void OnBind() { }
        protected virtual void OnUnbind(){}

        private void Bind()
        {
            binding.Bind(model);
            OnBind();
        }

        private void Unbind()
        {
            if (model != null)
            {
                OnUnbind();
            }
            binding.Unbind();
            model = null;
        }

    }
}