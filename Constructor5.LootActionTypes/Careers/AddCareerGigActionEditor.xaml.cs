using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.LootActionTypes.Careers
{
    [ObjectEditor(typeof(AddCareerGigAction))]
    public partial class AddCareerGigActionEditor : UserControl, IObjectEditor
    {
        public AddCareerGigActionEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
        }
    }
}