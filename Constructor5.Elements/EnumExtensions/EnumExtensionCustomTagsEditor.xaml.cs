using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.EnumExtensions
{
    [ObjectEditor(typeof(EnumExtensionCustomTags))]
    public partial class EnumExtensionCustomTagsEditor : UserControl, IObjectEditor
    {
        public EnumExtensionCustomTagsEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
        }
    }
}