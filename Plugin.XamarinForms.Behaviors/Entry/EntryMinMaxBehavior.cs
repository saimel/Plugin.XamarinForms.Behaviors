using Xamarin.Forms;

namespace Plugin.XamarinForms.Behaviors
{
    public class EntryMinMaxBehavior : Behavior<Entry>
    {
        public static BindableProperty MinValueProperty = BindableProperty.Create(
            nameof(MinValue), typeof(double), typeof(EntryMinMaxBehavior), 0.0);

        public double MinValue
        {
            get => (double)GetValue(MinValueProperty);
            set => SetValue(MinValueProperty, value);
        }

        public static BindableProperty MaxValueProperty = BindableProperty.Create(
            nameof(MaxValue), typeof(double), typeof(EntryMinMaxBehavior), 0.0);

        public double MaxValue
        {
            get => (double)GetValue(MaxValueProperty);
            set => SetValue(MaxValueProperty, value);
        }

        public static BindableProperty ValidValueStyleProperty = BindableProperty.Create(
            nameof(ValidValueStyle), typeof(Style), typeof(EntryMinMaxBehavior), defaultBindingMode: BindingMode.OneTime);

        public Style ValidValueStyle
        {
            get => (Style)GetValue(ValidValueStyleProperty);
            set => SetValue(ValidValueStyleProperty, value);
        }

        public static BindableProperty NotValidValueStyleProperty = BindableProperty.Create(
            nameof(NotValidValueStyle), typeof(Style), typeof(EntryMinMaxBehavior), defaultBindingMode: BindingMode.OneTime);

        public Style NotValidValueStyle
        {
            get => (Style)GetValue(NotValidValueStyleProperty);
            set => SetValue(NotValidValueStyleProperty, value);
        }

        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += OnTextChanged;
            bindable.Keyboard = Keyboard.Numeric;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= OnTextChanged;
        }

        private void OnTextChanged(object sender, TextChangedEventArgs args)
        {
            var entry = (Entry)sender;

            if (string.IsNullOrEmpty(args.NewTextValue) == true)
            {
                entry.Style = NotValidValueStyle;
                return;
            }

            if (double.TryParse(args.NewTextValue, out double result) == true)
            {
                if (result < MinValue || result > MaxValue)
                {
                    entry.Style = NotValidValueStyle;
                }
                else
                {
                    entry.Style = ValidValueStyle;
                }
            }
            else
            {
                entry.Style = NotValidValueStyle;
            }
        }
    }
}
