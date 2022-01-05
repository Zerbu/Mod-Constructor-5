using Constructor5.Base.ElementSystem;
using Constructor5.UI.Dialogs;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Constructor5.Elements.Buffs.References
{
    /// <summary>
    /// Interaction logic for BuffWithReasonControl.xaml
    /// </summary>
    public partial class BuffWithReasonControl : UserControl
    {
        public static readonly DependencyProperty BuffWithReasonProperty =
            DependencyProperty.Register("BuffWithReason", typeof(BuffWithReason), typeof(BuffWithReasonControl), new PropertyMetadata(null));

        public static readonly DependencyProperty EditorTagProperty =
            DependencyProperty.Register("EditorTag", typeof(string), typeof(BuffWithReasonControl), new PropertyMetadata(null));

        public BuffWithReasonControl() => InitializeComponent();

        public event Func<Element> CreateElementFunction;

        public BuffWithReason BuffWithReason
        {
            get => (BuffWithReason)GetValue(BuffWithReasonProperty);
            set => SetValue(BuffWithReasonProperty, value);
        }

        public string EditorTag
        {
            get => (string)GetValue(EditorTagProperty);
            set => SetValue(EditorTagProperty, value);
        }

        private void HelpButton_Click(object sender, RoutedEventArgs e)
            => FancyMessageBox.Show("This is the text that will appear below the name of the buff in the UI, indicating why it was added. For example: (From Custom Trait)");

        private Element ReferenceControl_CreateElementFunction() => CreateElementFunction?.Invoke();
    }
}