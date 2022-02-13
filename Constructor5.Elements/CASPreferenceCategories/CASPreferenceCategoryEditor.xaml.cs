using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.CASPreferenceCategories
{
    [ObjectEditor(typeof(CASPreferenceCategory))]
    public partial class CASPreferenceCategoryEditor : UserControl, IObjectEditor
    {
        public CASPreferenceCategoryEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}