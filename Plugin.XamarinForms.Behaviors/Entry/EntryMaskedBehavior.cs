using System.Collections.Generic;
using Xamarin.Forms;

namespace Plugin.XamarinForms.Behaviors
{
    public class EntryMaskedBehavior : Behavior<Entry>
    {
        private string _mask = "";
        private IDictionary<int, char> _pattern;

        public string Mask
        {
            get => _mask;
            set
            {
                _mask = value;
                ParseMask();
            }
        }

        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += OnTextChanged;

            if (Mask.Length > 0)
            {
                bindable.MaxLength = Mask.Length;
            }
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= OnTextChanged;
        }

        private void OnTextChanged(object sender, TextChangedEventArgs args)
        {
            var entry = sender as Entry;
            string text = entry.Text;

            if (_pattern == null || string.IsNullOrEmpty(text) == true)
            {
                return;
            }

            foreach (var p in _pattern)
            {
                if (text.Length >= p.Key + 1)
                {
                    var c = p.Value.ToString();
                    if (text.Substring(p.Key, 1) != c)
                    {
                        text = text.Insert(p.Key, c);
                    }
                }
            }

            if (entry.Text != text)
            {
                entry.Text = text;
            }
        }

        private void ParseMask()
        {
            if (string.IsNullOrEmpty(Mask) == true)
            {
                _pattern = null;
                return;
            }

            _pattern = new Dictionary<int, char>();

            for (int i = 0; i < Mask.Length; ++i)
            {
                if (Mask[i] != 'X')
                {
                    _pattern.Add(i, Mask[i]);
                }
            }
        }
    }
}
