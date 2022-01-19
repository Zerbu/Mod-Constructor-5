using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.LikesDislikes
{
    [ObjectEditor(typeof(LikeDislike))]
    public partial class LikeDislikeEditor : UserControl, IObjectEditor
    {
        public LikeDislikeEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}