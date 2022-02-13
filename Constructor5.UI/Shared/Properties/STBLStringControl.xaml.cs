using Constructor5.Base.ElementSystem;
using Constructor5.Base.PropertyTypes;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Constructor5.UI.Shared
{
    /// <summary>
    /// Interaction logic for TextStringControl.xaml
    /// </summary>
    public partial class STBLStringControl : UserControl
    {
        public static readonly DependencyProperty IsMultiLineProperty =
            DependencyProperty.Register("IsMultiLine", typeof(bool), typeof(STBLStringControl), new PropertyMetadata(false));

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(STBLString), typeof(STBLStringControl),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public static readonly DependencyProperty UpdateLabelForElementProperty =
            DependencyProperty.Register("UpdateLabelForElement", typeof(Element), typeof(STBLStringControl), new PropertyMetadata(null));

        public STBLStringControl() => InitializeComponent();

        public bool IsMultiLine
        {
            get { return (bool)GetValue(IsMultiLineProperty); }
            set { SetValue(IsMultiLineProperty, value); }
        }

        public STBLString Text
        {
            get => (STBLString)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public Element UpdateLabelForElement
        {
            get => (Element)GetValue(UpdateLabelForElementProperty);
            set => SetValue(UpdateLabelForElementProperty, value);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (UpdateLabelForElement != null)
            {
                UpdateLabelForElement.GeneratedLabel = !string.IsNullOrEmpty(TextBox.Text) ? TextBox.Text : UpdateLabelForElement.GetDefaultLabel();
            }
        }
    }
}