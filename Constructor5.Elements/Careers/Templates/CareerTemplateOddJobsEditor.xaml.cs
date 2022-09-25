using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Careers.Templates
{
    [ObjectEditor(typeof(CareerTemplateOddJobs))]
    public partial class CareerTemplateOddJobsEditor : UserControl, IObjectEditor
    {
        public CareerTemplateOddJobsEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
        }
    }
}