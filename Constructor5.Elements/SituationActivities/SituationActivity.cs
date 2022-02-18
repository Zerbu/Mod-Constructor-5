using Constructor5.Base.CustomTuning;
using Constructor5.Base.ElementSystem;
using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.SimData;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.PropertyTypes;
using Constructor5.Elements.SituationGoals;
using Constructor5.Elements.SituationGoals.Components;

namespace Constructor5.Elements.SituationActivities
{
    [ElementTypeData("SituationActivity", false, ElementTypes = new[] { typeof(SituationActivity) }, PresetFolders = new[] { "SituationActivity" }, IsRootType = false)]
    public class SituationActivity : Element, IExportableElement, ISupportsCustomTuning
    {
        public CustomTuningInfo CustomTuning { get; set; } = new CustomTuningInfo();
        public Reference Goal { get; set; } // do not add = new Reference();
        public STBLString Name { get; set; } = new STBLString();

        void IExportableElement.OnExport()
        {
            var tuning = ElementTuning.Create(this);
            tuning.Class = "SituationActivity";
            tuning.InstanceType = "holiday_tradition";
            tuning.Module = "situations.situation_activity";

            tuning.SimDataHandler = new SimDataHandler($"SimData/HolidayTradition.data");

            var goalElement = (SituationGoal)Goal.Element;
            var goalInfo = goalElement.GetComponent<SituationGoalInfoComponent>();

            var tunableVariant1 = tuning.Set<TunableVariant>("_display_data", "optional_display_mixin");
            var tunableTuple1 = tunableVariant1.Get<TunableTuple>("optional_display_mixin");
            var tunableVariant2 = tunableTuple1.Set<TunableVariant>("instance_display_description", "enabled_display_description");
            tunableVariant2.Set<TunableBasic>("enabled_display_description", goalInfo.Description);
            var tunableVariant3 = tunableTuple1.Set<TunableVariant>("instance_display_icon", "enabled_display_icon");
            tunableVariant3.Set<TunableBasic>("enabled_display_icon", goalInfo.Icon);
            var tunableVariant4 = tunableTuple1.Set<TunableVariant>("instance_display_name", "enabled_display_name");
            tunableVariant4.Set<TunableBasic>("enabled_display_name", Name);
            var tunableVariant5 = tunableTuple1.Set<TunableVariant>("instance_display_tooltip", "disabled");
            tuning.Set<TunableBasic>("selectable", "True");
            tuning.Set<TunableBasic>("situation_goal", Goal);

            if (Exporter.Current.STBLBuilder != null)
            {
                tuning.SimDataHandler.WriteText(228, Exporter.Current.STBLBuilder.GetKey(Name) ?? 0);
                tuning.SimDataHandler.WriteText(224, Exporter.Current.STBLBuilder.GetKey(goalInfo.Description) ?? 0);
                tuning.SimDataHandler.WriteTGI(240, goalInfo.Icon.GetUncommentedText(), this);
            }

            CustomTuningExporter.Export(this, tuning, CustomTuning);

            TuningExport.AddToQueue(tuning);
        }

        protected override void OnElementCreatedOrLoaded()
        {
            base.OnElementCreatedOrLoaded();
            if (Goal == null)
            {
                Goal = new Reference(ElementManager.Create(typeof(SituationGoal), null, true));
            }
        }

        protected override void OnUserCreated(string label)
        {
            GeneratedLabel = label;
            Name = new STBLString() { CustomText = label };
        }
    }
}