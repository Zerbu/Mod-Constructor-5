using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Commodities
{
    [ObjectEditor(typeof(CommoditySettingsComponent))]
    public partial class CommoditySettingsComponentEditor : UserControl, IObjectEditor
    {
        public CommoditySettingsComponentEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}