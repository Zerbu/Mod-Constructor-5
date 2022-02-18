using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Careers.Templates
{
    [ObjectEditor(typeof(CareerTemplateVolunteer))]
    public partial class CareerTemplateVolunteerEditor : UserControl, IObjectEditor
    {
        public CareerTemplateVolunteerEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}