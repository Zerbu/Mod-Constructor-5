using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Commodities
{
    [ObjectEditor(typeof(CommodityStatesComponent))]
    public partial class CommodityStatesComponentEditor : UserControl, IObjectEditor
    {
        public CommodityStatesComponentEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}