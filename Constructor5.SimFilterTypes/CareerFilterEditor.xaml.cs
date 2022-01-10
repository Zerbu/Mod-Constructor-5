using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.SimFilterTypes
{
    [ObjectEditor(typeof(CareerFilter))]
    public partial class CareerFilterEditor : UserControl, IObjectEditor
    {
        public CareerFilterEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}