using Constructor5.Base.ComponentSystem;
using Constructor5.Base.ElementSystem;
using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem.Tuning.SimData;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Core;
using Constructor5.Elements.HolidayTraditions.Components;
using Constructor5.Elements.SituationGoals;

namespace Constructor5.Elements.HolidayTraditions
{
    [ElementTypeData("HolidayTradition", true, ElementTypes = new[] { typeof(HolidayTradition) }, PresetFolders = new[] { "HolidayTradition" }, IsRootType = true)]
    public class HolidayTradition : SimpleComponentElement<HolidayTraditionComponent>, IExportableElement
    {
        protected override void OnElementCreatedOrLoaded()
        {
            base.OnElementCreatedOrLoaded();
            foreach (var type in Reflection.GetSubtypes(typeof(HolidayTraditionComponent)))
            {
                AddComponent(type);
            }

            var goalComponent = GetComponent<HolidayTraditionGoalComponent>();
            if (goalComponent.Goal != null)
            {
                return;
            }

            var newGoal = ElementManager.Create(typeof(SituationGoal), null, true);
            newGoal.AddContextModifier(new HolidayTraditionContextModifier() { HolidayTradition = new Reference(this) });
            goalComponent.Goal = new Reference(newGoal);
        }

        protected override void OnUserCreated(string label)
        {
            base.OnUserCreated(label);

            var preferencesComponent = GetComponent<HolidayTraditionPreferencesComponent>();

            var preference = new HolidayTraditionPreference
            {
                Type = HolidayTraditionPreferenceType.DOES_NOT_CARE
            };
            preferencesComponent.SetToddlerPreferencePreset(preference);
            preferencesComponent.Preferences.Add(preference);
        }

        void IExportableElement.OnExport()
        {
            var tuning = ElementTuning.Create(this);
            tuning.Class = "HolidayTradition";
            tuning.InstanceType = "holiday_tradition";
            tuning.Module = "holidays.holiday_tradition";

            tuning.SimDataHandler = new SimDataHandler($"SimData/HolidayTradition.data");

            var context = new HolidayTraditionExportContext
            {
                Element = this,
                Tuning = tuning
            };

            foreach (var component in Components)
            {
                component.OnExport(context);
            }

            TuningExport.AddToQueue(tuning);
        }
    }
}