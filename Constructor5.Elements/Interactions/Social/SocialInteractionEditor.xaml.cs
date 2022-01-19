using Constructor5.Elements.Interactions.Social;
using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.UI.Interactions.Social
{
    [ObjectEditor(typeof(SocialInteraction))]
    public partial class SocialInteractionEditor : UserControl, IObjectEditor
    {
        public SocialInteractionEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}
