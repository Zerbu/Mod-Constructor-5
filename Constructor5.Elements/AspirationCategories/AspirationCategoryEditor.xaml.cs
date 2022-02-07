using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.AspirationCategories
{
    [ObjectEditor(typeof(AspirationCategory))]
    public partial class AspirationCategoryEditor : UserControl, IObjectEditor
    {
        public AspirationCategoryEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}
