using Constructor5.Base.ElementSystem;
using Constructor5.UI.AutoGeneratedEditors;
using Constructor5.Core;
using System.Collections.ObjectModel;

namespace Constructor5.SituationTemplates.SimpleSituation
{
    [XmlSerializerExtraType]
    public class SimpleSituationJobItem : ReferenceListItem
    {
        [AutoEditorReference("RoleState", ResetTo = 99710, ResetToLabel = "Generic", Label = "RoleState", HasPadding = false)]
        public Reference RoleState { get; set; } = new Reference(99710, "Generic");

        public ObservableCollection<RoleStateChange> RoleStateChanges { get; set; } = new ObservableCollection<RoleStateChange>();
    }
}