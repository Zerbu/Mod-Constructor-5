using Constructor5.Base.ElementSystem;
using Constructor5.Elements.Buffs.Components;
using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.LotTraits
{
    [ObjectEditor(typeof(LotTraitBuffs))]
    public partial class LotTraitBuffsEditor : UserControl, IObjectEditor
    {
        public LotTraitBuffsEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;

        private Base.ElementSystem.Element ReferenceListControl_CreateElementFunction()
        {
            var result = (Buff)ElementManager.Create(typeof(Buff), null, true);

            var info = result.GetComponent<BuffInfoComponent>();
            info.HasFixedDuration = true;
            info.AddEmotionCategory = false;
            info.Duration = 2147483647;
            info.IsNonPersisted = true;
            result.GetComponent<BuffSpecialCasesComponent>().HideTimeout = true;

            return result;
        }
    }
}