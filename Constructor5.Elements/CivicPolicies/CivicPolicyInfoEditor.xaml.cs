using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.CivicPolicies
{
    [ObjectEditor(typeof(CivicPolicyInfo))]
    public partial class CivicPolicyInfoEditor : UserControl, IObjectEditor
    {
        public CivicPolicyInfoEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
        }
    }
}