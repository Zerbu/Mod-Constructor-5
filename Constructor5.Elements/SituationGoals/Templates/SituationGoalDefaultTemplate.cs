using Constructor5.Core;

namespace Constructor5.Elements.SituationGoals.Templates
{
    [XmlSerializerExtraType]
    public class SituationGoalDefaultTemplate : SituationGoalTemplate
    {
        public override string Label => "No Goal Type Set";

        protected internal override void OnExport(SituationGoalExportContext context)
        {
        }
    }
}