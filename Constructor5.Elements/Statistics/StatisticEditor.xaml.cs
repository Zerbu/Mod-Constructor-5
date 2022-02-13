using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Statistics
{
    [ObjectEditor(typeof(Statistic))]
    public partial class StatisticEditor : UserControl, IObjectEditor
    {
        public StatisticEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}