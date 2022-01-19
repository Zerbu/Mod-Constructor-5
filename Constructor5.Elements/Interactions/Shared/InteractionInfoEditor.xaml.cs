using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Interactions.Social
{
    [ObjectEditor(typeof(InteractionInfoComponent))]
    public partial class SIInfoEditor : UserControl, IObjectEditor
    {
        public SIInfoEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;

            var component = (InteractionInfoComponent)obj;
            if (!(component.Element is SocialInteraction))
            {
                TargetNameControl.Visibility = System.Windows.Visibility.Collapsed;
            }
        }
    }
}