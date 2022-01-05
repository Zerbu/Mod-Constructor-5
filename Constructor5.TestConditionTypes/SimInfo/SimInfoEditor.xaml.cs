using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.TestConditionTypes.SimInfo
{
    /// <summary>
    /// Interaction logic for SimInfoEditor.xaml
    /// </summary>
    [ObjectEditor(typeof(SimInfoCondition))]
    public partial class SimInfoEditor : UserControl, IObjectEditor
    {
        public SimInfoEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}