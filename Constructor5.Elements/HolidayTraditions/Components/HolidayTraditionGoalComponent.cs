using Constructor5.Base.ElementSystem;
using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Core;
using Constructor5.Elements.SituationGoals;
using Constructor5.Elements.SituationGoals.Components;

namespace Constructor5.Elements.HolidayTraditions.Components
{
    [XmlSerializerExtraType]
    public class HolidayTraditionGoalComponent : HolidayTraditionComponent
    {
        public override int ComponentDisplayOrder => 1;
        public override string ComponentLabel => "Goal";

        public Reference Goal { get; set; } = new Reference();

        protected internal override void OnExport(HolidayTraditionExportContext context)
        {
            var goalElement = (SituationGoal)Goal.Element;
            var goalInfo = goalElement.GetComponent<SituationGoalInfoComponent>();

            var tunableVariant1 = context.Tuning.Set<TunableVariant>("_display_data", "optional_display_mixin");
            var tunableTuple1 = tunableVariant1.Get<TunableTuple>("optional_display_mixin");
            var tunableVariant2 = tunableTuple1.Set<TunableVariant>("instance_display_description", "enabled_display_description");
            tunableVariant2.Set<TunableBasic>("enabled_display_description", goalInfo.Description);
            var tunableVariant3 = tunableTuple1.Set<TunableVariant>("instance_display_icon", "enabled_display_icon");
            tunableVariant3.Set<TunableBasic>("enabled_display_icon", goalInfo.Icon);
            var tunableVariant4 = tunableTuple1.Set<TunableVariant>("instance_display_name", "enabled_display_name");
            tunableVariant4.Set<TunableBasic>("enabled_display_name", goalInfo.Name);
            var tunableVariant5 = tunableTuple1.Set<TunableVariant>("instance_display_tooltip", "disabled");
            context.Tuning.Set<TunableBasic>("selectable", "True");
            context.Tuning.Set<TunableBasic>("situation_goal", Goal);

            var header = (TuningHeader)context.Tuning;
            header.SimDataHandler.WriteText(228, Exporter.Current.STBLBuilder.GetKey(goalInfo.Name) ?? 0);
            header.SimDataHandler.WriteText(224, Exporter.Current.STBLBuilder.GetKey(goalInfo.Description) ?? 0);
            header.SimDataHandler.WriteTGI(240, goalInfo.Icon.GetUncommentedText(), Element);
        }
    }
}