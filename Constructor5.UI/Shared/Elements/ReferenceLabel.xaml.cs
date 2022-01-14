using Constructor5.Base.ElementSystem;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Reference = Constructor5.Base.ElementSystem.Reference;

namespace Constructor5.UI.Shared
{
    /// <summary>
    /// Interaction logic for ReferenceLabel.xaml
    /// </summary>
    public partial class ReferenceLabel : UserControl
    {
        public ReferenceLabel() => InitializeComponent();

        public Reference Reference
        {
            get => (Reference)GetValue(ReferenceProperty);
            set => SetValue(ReferenceProperty, value);
        }

        public static readonly DependencyProperty ReferenceProperty =
            DependencyProperty.Register("Reference", typeof(Reference), typeof(ReferenceLabel), new PropertyMetadata(null));
    }
}
