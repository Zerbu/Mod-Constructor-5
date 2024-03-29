﻿using Constructor5.Base.ElementSystem;
using Constructor5.Core;
using Constructor5.UI.AutoGeneratedEditors;

namespace Constructor5.Elements.WeeklyScheduleSituationDataSnippets
{
    [XmlSerializerExtraType]
    public class WeeklyScheduleSituationDataItem : ReferenceListItem
    {
        public ReferenceList RequireJobInOtherSituation { get; set; } = new ReferenceList();

        [AutoEditorReference("RoleState", ResetTo = 99710, ResetToLabel = "Generic", Label = "RoleState", HasPadding = false)]
        public Reference RoleState { get; set; } = new Reference(99710, "Generic");

        public int SimCountMin { get; set; } = 1;
        public int SimCountMax { get; set; } = 1;
    }
}
