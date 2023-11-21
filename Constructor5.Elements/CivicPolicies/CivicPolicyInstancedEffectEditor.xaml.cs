using Constructor5.Base.ElementSystem;
using Constructor5.Elements.Buffs.Components;
using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.CivicPolicies
{
    [ObjectEditor(typeof(CivicPolicyInstancedEffect))]
    public partial class CivicPolicyInstancedEffectEditor : UserControl, IObjectEditor
    {
        public CivicPolicyInstancedEffectEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
        }

        private Base.ElementSystem.Element ReferenceControl_CreateElementFunction()
        {
            var result = (Buff)ElementManager.Create(typeof(Buff), null, true);

            var info = result.GetComponent<BuffInfoComponent>();
            info.HasFixedDuration = true;
            info.AddEmotionCategory = false;
            info.Duration = 2147483647;
            result.GetComponent<BuffSpecialCasesComponent>().HideTimeout = true;

            return result;
        }
    }
}