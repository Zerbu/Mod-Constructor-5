using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Commodities
{
    [ObjectEditor(typeof(Commodity))]
    public partial class CommodityEditor : UserControl, IObjectEditor
    {
        public CommodityEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}