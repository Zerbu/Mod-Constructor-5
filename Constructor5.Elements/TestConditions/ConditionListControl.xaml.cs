using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Constructor5.Elements.TestConditions
{
    /// <summary>
    /// Interaction logic for ConditionListControl.xaml
    /// </summary>
    public partial class ConditionListControl : UserControl
    {
        public static readonly DependencyProperty ConditionListProperty =
            DependencyProperty.Register("ConditionList", typeof(IEnumerable<TestConditionListItem>), typeof(ConditionListControl), new PropertyMetadata(null));

        public static readonly DependencyProperty EditorTagProperty =
            DependencyProperty.Register("EditorTag", typeof(string), typeof(ConditionListControl), new PropertyMetadata(null));

        public static readonly DependencyProperty RegistryCategoryProperty =
                    DependencyProperty.Register("RegistryCategory", typeof(string), typeof(ConditionListControl), new PropertyMetadata("TestConditionTypes"));

        public ConditionListControl() => InitializeComponent();

        public IEnumerable<TestConditionListItem> ConditionList
        {
            get => (IEnumerable<TestConditionListItem>)GetValue(ConditionListProperty);
            set => SetValue(ConditionListProperty, value);
        }

        public string EditorTag
        {
            get => (string)GetValue(EditorTagProperty);
            set => SetValue(EditorTagProperty, value);
        }

        public string RegistryCategory
        {
            get => (string)GetValue(RegistryCategoryProperty);
            set => SetValue(RegistryCategoryProperty, value);
        }
    }
}