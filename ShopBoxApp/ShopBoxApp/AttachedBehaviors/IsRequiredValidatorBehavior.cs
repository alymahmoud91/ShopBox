using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShopBoxApp.AttachedBehaviors
{
    public class IsRequiredValidatorBehavior : Behavior<Entry>
    {
        static readonly BindablePropertyKey IsNotValidPropertyKey = BindableProperty.CreateReadOnly("IsNotValid", typeof(bool), typeof(IsRequiredValidatorBehavior), false);

        public static readonly BindableProperty IsValidProperty = IsNotValidPropertyKey.BindableProperty;

        public bool IsNotValid
        {
            get { return (bool)base.GetValue(IsValidProperty); }
            private set { base.SetValue(IsNotValidPropertyKey, value); }
        }

        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += HandleTextChanged;
        }

        void HandleTextChanged(object sender, TextChangedEventArgs e)
        {
            IsNotValid = e.NewTextValue.Length > 0;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= HandleTextChanged;
        }
    }

}
