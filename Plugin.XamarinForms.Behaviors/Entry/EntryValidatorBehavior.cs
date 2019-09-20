using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Plugin.XamarinForms.Behaviors
{
    public class EntryValidatorBehavior : Behavior<Entry>
    {
        public string Pattern { get; set; }

        public static BindableProperty ValidValueStyleProperty = BindableProperty.Create(
            nameof(ValidValueStyle), typeof(Style), typeof(EntryValidatorBehavior), defaultBindingMode: BindingMode.OneTime);

        public Style ValidValueStyle
        {
            get => (Style)GetValue(ValidValueStyleProperty);
            set => SetValue(ValidValueStyleProperty, value);
        }

        public static BindableProperty NotValidValueStyleProperty = BindableProperty.Create(
            nameof(NotValidValueStyle), typeof(Style), typeof(EntryValidatorBehavior), defaultBindingMode: BindingMode.OneTime);

        public Style NotValidValueStyle
        {
            get => (Style)GetValue(NotValidValueStyleProperty);
            set => SetValue(NotValidValueStyleProperty, value);
        }

        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += OnTextChanged;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= OnTextChanged;
        }

        private void OnTextChanged(object sender, TextChangedEventArgs args)
        {
            if (string.IsNullOrEmpty(Pattern) == true)
            {
                return;
            }

            var entry = (sender as Entry);
            entry.Style = Regex.IsMatch(args.NewTextValue, $@"{Pattern}") == true ? ValidValueStyle : NotValidValueStyle;
        }
    }
}
