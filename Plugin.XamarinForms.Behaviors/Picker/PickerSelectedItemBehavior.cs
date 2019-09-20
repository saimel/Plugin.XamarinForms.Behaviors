using System;
using Xamarin.Forms;

namespace Plugin.XamarinForms.Behaviors
{
    public class PickerSelectedItemBehavior : Behavior<Picker>
    {
        public static BindableProperty ValidItemStyleProperty = BindableProperty.Create(
            nameof(ValidItemStyle), typeof(Style), typeof(PickerSelectedItemBehavior), defaultBindingMode: BindingMode.OneTime);

        public static BindableProperty InvalidItemStyleProperty = BindableProperty.Create(
            nameof(InvalidItemStyle), typeof(Style), typeof(PickerSelectedItemBehavior), defaultBindingMode: BindingMode.OneTime);

        public Style ValidItemStyle
        {
            get => (Style)GetValue(ValidItemStyleProperty);
            set => SetValue(ValidItemStyleProperty, value);
        }

        public Style InvalidItemStyle
        {
            get => (Style)GetValue(InvalidItemStyleProperty);
            set => SetValue(InvalidItemStyleProperty, value);
        }

        protected override void OnAttachedTo(Picker bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.SelectedIndexChanged += OnSelectedIndexChanged;
            bindable.Style = bindable.SelectedIndex != 0 ? ValidItemStyle : InvalidItemStyle;
        }

        protected override void OnDetachingFrom(Picker bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.SelectedIndexChanged -= OnSelectedIndexChanged;
        }

        private void OnSelectedIndexChanged(object sender, EventArgs args)
        {
            var pckSender = (Picker)sender;
            pckSender.Style = pckSender.SelectedIndex != 0 ? ValidItemStyle : InvalidItemStyle;
        }
    }
}
