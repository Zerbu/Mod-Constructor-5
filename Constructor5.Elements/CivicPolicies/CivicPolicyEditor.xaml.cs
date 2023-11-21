using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.CivicPolicies
{
    [ObjectEditor(typeof(CivicPolicy))]
    public partial class CivicPolicyEditor : UserControl, IObjectEditor
    {
        public CivicPolicyEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}