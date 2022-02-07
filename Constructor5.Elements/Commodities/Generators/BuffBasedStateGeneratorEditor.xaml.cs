using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Commodities.Generators
{
    [ObjectEditor(typeof(BuffBasedStateGenerator))]
    public partial class BuffBasedStateGeneratorEditor : UserControl, IObjectEditor
    {
        public BuffBasedStateGeneratorEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}