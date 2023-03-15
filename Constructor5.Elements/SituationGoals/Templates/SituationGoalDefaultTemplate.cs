using Constructor5.Base.SelectableObjects;
using Constructor5.Core;

namespace Constructor5.Elements.SituationGoals.Templates
{
    [XmlSerializerExtraType]
    [SelectableObjectType("SituationGoalTemplates", "No Goal Type Set")]
    public class SituationGoalDefaultTemplate : SituationGoalTemplate
    {
        public override string Label => "No Goal Type Set";

        protected internal override void OnExport(SituationGoalExportContext context)
        {
        }
    }
}