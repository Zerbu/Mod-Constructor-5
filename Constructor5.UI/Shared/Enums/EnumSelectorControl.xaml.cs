using Constructor5.Base.LocalizationSystem;
using Constructor5.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Constructor5.UI.Shared
{
    /// <summary>
    /// Interaction logic for EnumSelectorControl.xaml
    /// </summary>
    public partial class EnumSelectorControl : UserControl
    {
        public static readonly DependencyProperty IsLocalizableProperty =
            DependencyProperty.Register("IsLocalizable", typeof(bool), typeof(EnumSelectorControl), new PropertyMetadata(true));

        public static readonly DependencyProperty ReplacementsProperty =
                    DependencyProperty.Register("Replacements", typeof(EnumSelectorReplaceDictionary), typeof(EnumSelectorControl), new PropertyMetadata(null, (dp, e) =>
            {
                var control = (EnumSelectorControl)dp;
                control.RefreshContent();
            }));

        public static readonly DependencyProperty SelectedItemProperty =
                    DependencyProperty.Register("SelectedItem", typeof(object), typeof(EnumSelectorControl), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, (dp, e) =>
                    {
                        var control = (EnumSelectorControl)dp;
                        control.ComboBox.SelectedItem = control.EnumSelectorValues.First(x => x.Value.Equals(e.NewValue)).DisplayText;
                    }));

        public static readonly DependencyProperty TypeProperty =
                    DependencyProperty.Register("Type", typeof(Type), typeof(EnumSelectorControl), new PropertyMetadata(null, (dp, e) =>
                    {
                        var control = (EnumSelectorControl)dp;
                        //control.RefreshContent();
                    }));

        public EnumSelectorControl() => InitializeComponent();

        public bool IsLocalizable
        {
            get => (bool)GetValue(IsLocalizableProperty);
            set => SetValue(IsLocalizableProperty, value);
        }

        public EnumSelectorReplaceDictionary Replacements
        {
            get => (EnumSelectorReplaceDictionary)GetValue(ReplacementsProperty);
            set => SetValue(ReplacementsProperty, value);
        }

        public object SelectedItem
        {
            get => GetValue(SelectedItemProperty);
            set => SetValue(SelectedItemProperty, value);
        }

        public Type Type
        {
            get => (Type)GetValue(TypeProperty);
            set => SetValue(TypeProperty, value);
        }

        public string TypeName
        {
            get => Type.Name;
            set => Type = Reflection.GetTypeByName(value);
        }

        private List<EnumSelectorValue> EnumSelectorValues { get; } = new List<EnumSelectorValue>();

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
            => SelectedItem = EnumSelectorValues.FirstOrDefault(x => x.DisplayText.Equals(ComboBox.SelectedItem)).Value;

        private void RefreshContent()
        {
            EnumSelectorValues.Clear();
            ComboBox.Items.Clear();
            foreach (var value in Type.GetEnumValues())
            {
                var valueString = value.ToString();

                var replacement = Replacements?.ContainsKey(value.ToString()) == true ? Replacements[value.ToString()] : null;
                var displayText = IsLocalizable ? TextStringManager.Get(replacement ?? valueString) : replacement ?? valueString;
                var result = new EnumSelectorValue
                {
                    Value = value,
                    DisplayText = displayText
                };
                EnumSelectorValues.Add(result);
                ComboBox.Items.Add(displayText);
            }
        }
    }
}