using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.PieMenuCategories
{
    [ObjectEditor(typeof(PieMenuCategory))]
    public partial class PieMenuCategoryEditor : UserControl, IObjectEditor
    {
        public PieMenuCategoryEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
        }
    }
}