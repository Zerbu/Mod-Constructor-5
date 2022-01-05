using Constructor5.Base.SelectableObjects;
using Constructor5.Elements.SituationGoals.Templates;
using Constructor5.Core;

namespace Constructor5.Elements.SituationGoals.Components
{
    [XmlSerializerExtraType]
    public class SituationGoalTemplateComponent : SituationGoalComponent
    {
        public override int ComponentDisplayOrder => 2;
        public override string ComponentLabel => "Main Content";

        public SituationGoalTemplate Template { get; set; } = new SituationGoalDefaultTemplate();

        protected internal override void OnExport(SituationGoalExportContext context)
        {
            Template.OnExport(context);
        }
    }
}