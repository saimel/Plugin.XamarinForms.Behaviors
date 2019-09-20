using System.ComponentModel;
using Xamarin.Forms;

namespace Plugin.XamarinForms.Behaviors
{
    public class VisualElementEnableBehavior : Behavior<VisualElement>
    {
        public static BindableProperty EnableStyleProperty = BindableProperty.Create(
               nameof(EnableStyle), typeof(Style), typeof(VisualElementEnableBehavior), defaultBindingMode: BindingMode.OneTime);

        public Style EnableStyle
        {
            get => (Style)GetValue(EnableStyleProperty);
            set => SetValue(EnableStyleProperty, value);
        }

        public static BindableProperty DisableStyleProperty = BindableProperty.Create(
            nameof(DisableStyle), typeof(Style), typeof(VisualElementEnableBehavior), defaultBindingMode: BindingMode.OneTime);

        public Style DisableStyle
        {
            get => (Style)GetValue(DisableStyleProperty);
            set => SetValue(DisableStyleProperty, value);
        }

        protected override void OnAttachedTo(VisualElement bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.PropertyChanged += OnPropertyChanged;
            bindable.Style = bindable.IsEnabled ? EnableStyle : DisableStyle;
        }

        protected override void OnDetachingFrom(VisualElement bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.PropertyChanged -= OnPropertyChanged;
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName.ToLowerInvariant().Equals("isenabled") == true)
            {
                (sender as VisualElement).Style = (sender as VisualElement).IsEnabled ? EnableStyle : DisableStyle;
            }
        }
    }
}
