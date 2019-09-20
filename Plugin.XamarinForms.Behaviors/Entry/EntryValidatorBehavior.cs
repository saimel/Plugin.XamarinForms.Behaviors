using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Plugin.XamarinForms.Behaviors
{
    public class EntryValidatorBehavior : Behavior<Entry>
    {
        public string Pattern { get; set; }

        public static BindableProperty MatchingStyleProperty = BindableProperty.Create(
            nameof(MatchingStyle), typeof(Style), typeof(EntryValidatorBehavior), defaultBindingMode: BindingMode.OneTime);

        public Style MatchingStyle
        {
            get => (Style)GetValue(MatchingStyleProperty);
            set => SetValue(MatchingStyleProperty, value);
        }

        public static BindableProperty NotMatchingStyleProperty = BindableProperty.Create(
            nameof(NotMatchingStyle), typeof(Style), typeof(EntryValidatorBehavior), defaultBindingMode: BindingMode.OneTime);

        public Style NotMatchingStyle
        {
            get => (Style)GetValue(NotMatchingStyleProperty);
            set => SetValue(NotMatchingStyleProperty, value);
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
            entry.Style = Regex.IsMatch(args.NewTextValue, $@"{Pattern}") == true ? MatchingStyle : NotMatchingStyle;
        }
    }
}
