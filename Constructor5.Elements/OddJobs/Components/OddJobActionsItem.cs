using Constructor5.Base.ElementSystem;
using Constructor5.Core;

namespace Constructor5.Elements.OddJobs.Components
{
    [XmlSerializerExtraType]
    public class OddJobActionsItem : ReferenceListItem
    {
        public bool RunOnGreatSuccess { get; set; } = true;
        public bool RunOnNormalSuccess { get; set; } = true;
        public bool RunOnNormalFailure { get; set; } = true;
        public bool RunOnCriticalFailure { get; set; } = true;
    }
}
