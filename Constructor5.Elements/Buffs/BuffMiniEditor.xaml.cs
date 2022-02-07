using Constructor5.Elements.Buffs.Components;
using Constructor5.UI.Shared;
using System.Windows;
using System.Windows.Controls;

namespace Constructor5.Elements.Buffs
{
    [ObjectEditor(typeof(Buff), "ElementMini")]
    public partial class BuffMiniEditor : UserControl, IObjectEditor
    {
        public static readonly DependencyProperty BuffInfoComponentProperty =
            DependencyProperty.Register("BuffInfoComponent", typeof(BuffInfoComponent), typeof(BuffMiniEditor), new PropertyMetadata(null));

        public static readonly DependencyProperty BuffSpecialCasesComponentProperty =
            DependencyProperty.Register("BuffSpecialCasesComponent", typeof(BuffSpecialCasesComponent), typeof(BuffMiniEditor), new PropertyMetadata(null));

        public BuffMiniEditor() => InitializeComponent();

        public BuffInfoComponent BuffInfoComponent
        {
            get => (BuffInfoComponent)GetValue(BuffInfoComponentProperty);
            set => SetValue(BuffInfoComponentProperty, value);
        }

        public BuffSpecialCasesComponent BuffSpecialCasesComponent
        {
            get => (BuffSpecialCasesComponent)GetValue(BuffSpecialCasesComponentProperty);
            set => SetValue(BuffSpecialCasesComponentProperty, value);
        }

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
            BuffInfoComponent = ((Buff)obj).GetComponent<BuffInfoComponent>();
            BuffSpecialCasesComponent = ((Buff)obj).GetComponent<BuffSpecialCasesComponent>();
            if (tag == "ProximityBuff")
            {
                ProximityStack.Visibility = Visibility.Visible;
            }
            if (tag == "NoDuration" || tag == "ProximityBuff")
            {
                DurationPanel.Visibility = Visibility.Collapsed;
            }
            if (tag == "PersistantBuff")
            {
                DurationPanel.Visibility = Visibility.Collapsed;
                HideTimeoutPanel.Visibility = Visibility.Visible;
            }
            if (tag == "ShowHideTimeout")
            {
                HideTimeoutPanel.Visibility = Visibility.Visible;
            }
        }
    }
}