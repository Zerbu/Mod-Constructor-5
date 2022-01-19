using Constructor5.Core;
using System;
using System.Collections;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Constructor5.UI.Shared
{
    /// <summary>
    /// Interaction logic for EnumSelectorControl.xaml
    /// </summary>
    public partial class EnumSelectorControl : UserControl
    {
        public static readonly DependencyProperty ReplacementsProperty =
            DependencyProperty.Register("Replacements", typeof(EnumSelectorReplaceDictionary), typeof(EnumSelectorControl), new PropertyMetadata(null, (dp, e) =>
            {
                var control = (EnumSelectorControl)dp;
                ((ObjectDataProvider)control.Resources["DataProvider"]).MethodParameters[1] = e.NewValue;
            }));

        public static readonly DependencyProperty SelectedItemProperty =
                    DependencyProperty.Register("SelectedItem", typeof(object), typeof(EnumSelectorControl), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, (dp, e) =>
                    {
                        var control = (EnumSelectorControl)dp;
                        var dataProvider = ((ObjectDataProvider)control.Resources["DataProvider"]);
                        var list = (IList)control.ComboBox.ItemsSource;

                        var value = list.OfType<EnumSelectorValue>().FirstOrDefault(x => x.Value.Equals(e.NewValue));

                        var index = list.IndexOf(value);
                        if (control.ComboBox.SelectedIndex != index)
                        {
                            control.ComboBox.SelectedIndex = index;
                        }
                    }));

        public static readonly DependencyProperty TypeProperty =
                    DependencyProperty.Register("Type", typeof(Type), typeof(EnumSelectorControl), new PropertyMetadata(null, (dp, e) =>
                    {
                        var control = (EnumSelectorControl)dp;
                        ((ObjectDataProvider)control.Resources["DataProvider"]).MethodParameters[0] = e.NewValue;
                    }));

        public EnumSelectorControl()
        {
            InitializeComponent();
            var dataProvider = (ObjectDataProvider)Resources["DataProvider"];
            dataProvider.MethodParameters.Add(null);
            dataProvider.MethodParameters.Add(null);
        }

        public EnumSelectorReplaceDictionary Replacements
        {
            get => (EnumSelectorReplaceDictionary)GetValue(ReplacementsProperty);
            set => SetValue(ReplacementsProperty, value);
        }

        public object SelectedItem
        {
            get => (object)GetValue(SelectedItemProperty);
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

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = (EnumSelectorValue)ComboBox.SelectedItem;
            SelectedItem = selectedItem?.Value;
        }
    }
}