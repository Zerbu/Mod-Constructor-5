using Constructor5.Base.ElementSystem;
using Constructor5.Elements.Traits.Components;
using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Buffs.Components
{
    [ObjectEditor(typeof(BuffSpecialCasesComponent))]
    public partial class BuffSpecialCasesEditor : UserControl, IObjectEditor
    {
        public BuffSpecialCasesEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;

        private Element CreateTemporaryTrait()
        {
            var buff = (Buff)((BuffSpecialCasesComponent)DataContext).Element;
            var buffInfo = buff.GetComponent<BuffInfoComponent>();

            var result = (Trait)ElementManager.Create(typeof(Trait), null, true);

            var traitInfo = result.GetTraitComponent<TraitInfoComponent>();
            traitInfo.Name = buffInfo.Name;
            traitInfo.Description = buffInfo.Description;
            traitInfo.Icon = buffInfo.Icon;

            result.GetTraitComponent<TraitSpecialCasesComponent>().IsNonPersisted = true;
            return result;
        }
    }
}
