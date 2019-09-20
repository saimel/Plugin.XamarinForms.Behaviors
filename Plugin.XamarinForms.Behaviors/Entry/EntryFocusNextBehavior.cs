using System;
using Xamarin.Forms;

namespace Plugin.XamarinForms.Behaviors
{
    public class EntryFocusNextBehavior : Behavior<Entry>
    {
        public static BindableProperty NextEntryProperty = BindableProperty.Create(
            nameof(NextEntry), typeof(Entry), typeof(EntryFocusNextBehavior), defaultBindingMode: BindingMode.OneTime);

        public Entry NextEntry
        {
            get => GetValue(NextEntryProperty) as Entry;
            set => SetValue(NextEntryProperty, value);
        }

        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.Completed += OnCompleted;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.Completed -= OnCompleted;
        }

        private void OnCompleted(object sender, EventArgs args)
        {
            NextEntry?.Focus();
        }
    }
}
