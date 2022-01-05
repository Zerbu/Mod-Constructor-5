using Constructor5.Base.ElementSystem;
using Constructor5.Elements;
using Constructor5.Elements.Buffs.Components;
using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.LootActionTypes.Buffs
{
    [ObjectEditor(typeof(AddPersistantBuffAction))]
    public partial class AddPersistantBuffActionEditor : UserControl, IObjectEditor
    {
        public AddPersistantBuffActionEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;

        private Element BuffWithReasonControl_CreateElementFunction()
        {
            var result = (Buff)ElementManager.Create(typeof(Buff), null, true);
            result.GetComponent<BuffSpecialCasesComponent>().HideTimeout = true;
            return result;
        }
    }
}