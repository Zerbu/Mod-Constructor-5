using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.ExportSystem.TuningActions;
using Constructor5.Base.Icons;
using Constructor5.Base.PropertyTypes;
using Constructor5.Base.Python;
using Constructor5.Core;
using Constructor5.Elements.Interactions.Career;
using System;
using System.Collections.ObjectModel;

namespace Constructor5.Elements.Careers.Components
{
    //[SelectableObjectType("LootActionTypes", "LABEL")]
    [XmlSerializerExtraType]
    public class CareerInfoComponent : CareerComponent
    {
        public ObservableCollection<CareerCompanyName> CompanyNames { get; set; } = new ObservableCollection<CareerCompanyName>();

        public override int ComponentDisplayOrder => 1;
        public override string ComponentLabel => "CareerInfo";

        public STBLString Description { get; set; } = new STBLString();
        public bool EnablePaidTimeOff { get; set; } = true;
        public ElementIcon Icon { get; set; } = new ElementIcon();
        public ElementIcon Image { get; set; } = new ElementIcon();
        public int InitialPaidTimeOff { get; set; } = 3;
        public STBLString Name { get; set; } = new STBLString();
        public STBLString PTOInteractionName { get; set; } = new STBLString();

        public bool AllowChild { get; set; }
        public bool AllowTeen { get; set; }
        public bool AllowYoungAdult { get; set; } = true;
        public bool AllowAdult { get; set; } = true;
        public bool AllowElder { get; set; } = true;

        public Reference PerformanceStatistic { get; set; } // do not add = new Reference();

        protected internal override void OnExport(CareerExportContext context)
        {
            var tunableList1 = context.Tuning.Get<TunableList>("career_availablity_tests");
            var tunableList2 = tunableList1.Get<TunableList>(null);
            var tunableVariant1 = tunableList2.Set<TunableVariant>(null, "sim_info");
            var tunableTuple1 = tunableVariant1.Get<TunableTuple>("sim_info");
            var tunableVariant2 = tunableTuple1.Set<TunableVariant>("ages", "specified");
            var tunableList3 = tunableVariant2.Get<TunableList>("specified");

            if (AllowChild)
            {
                tunableList3.Set<TunableEnum>(null, "CHILD");
            }
            if (AllowTeen)
            {
                tunableList3.Set<TunableEnum>(null, "TEEN");
            }
            if (AllowYoungAdult)
            {
                tunableList3.Set<TunableEnum>(null, "YOUNGADULT");
            }
            if (AllowAdult)
            {
                tunableList3.Set<TunableEnum>(null, "ADULT");
            }
            if (AllowElder)
            {
                tunableList3.Set<TunableEnum>(null, "ELDER");
            }

            if (EnablePaidTimeOff)
            {
                TunePaidTimeOff(context);
            }

            TuneCompanyNames(context);
        }

        private void TuneCompanyNames(CareerExportContext context)
        {
            var tunableVariant1 = context.Tuning.Set<TunableVariant>("career_location", "company");
            var tunableTuple1 = tunableVariant1.Get<TunableTuple>("company");
            var tunableList1 = tunableTuple1.Get<TunableList>("company_names");
            foreach (var companyName in CompanyNames)
            {
                tunableList1.Set<TunableBasic>(null, companyName.CompanyName);
            }
        }

        private void TunePaidTimeOff(CareerExportContext context)
        {
            var career = (Career)Element;
            var interactionComponent = career.GetComponent<CareerInteractionComponent>();

            var lootTuning = ElementTuning.Create(Element, "PTOLoot");
            {
                lootTuning.Class = "LootActions";
                lootTuning.InstanceType = "action";
                lootTuning.Module = "interactions.utils.loot";

                var tunableList1 = lootTuning.Get<TunableList>("loot_actions");
                var tunableVariant1 = tunableList1.Set<TunableVariant>(null, "career_loot");
                var tunableTuple1 = tunableVariant1.Get<TunableTuple>("career_loot");
                var tunableVariant2 = tunableTuple1.Set<TunableVariant>("career", "career_reference");
                var tunableTuple2 = tunableVariant2.Get<TunableTuple>("career_reference");
                tunableTuple2.Set<TunableBasic>("reference", ElementTuning.GetSingleInstanceKey(Element));
                var tunableList2 = tunableTuple1.Get<TunableList>("operations");
                var tunableVariant3 = tunableList2.Set<TunableVariant>(null, "take_day_off");
                var tunableTuple3 = tunableVariant3.Get<TunableTuple>("take_day_off");
                tunableTuple3.Set<TunableEnum>("reason", "PTO");
                var tunableVariant4 = tunableList2.Set<TunableVariant>(null, "pto");
                var tunableTuple4 = tunableVariant4.Get<TunableTuple>("pto");
                tunableTuple4.Set<TunableBasic>("amount", "-1");

                TuningExport.AddToQueue(lootTuning);
            }

            {
                var tuning = ElementTuning.Create(Element, "PTOInteraction");
                tuning.Class = "SuperInteraction";
                tuning.InstanceType = "interaction";
                tuning.Module = "interactions.base.super_interaction";

                var actionContext = new TuningActionContext
                {
                    DataContext = this,
                    Tuning = tuning
                };
                var interaction = (CareerInteraction)interactionComponent.Interaction.Element;

                actionContext.SetVariable("balloons", ElementTuning.GetSingleInstanceKey(interaction.BalloonSet).ToString());
                actionContext.SetVariable("career", ElementTuning.GetSingleInstanceKey(Element).ToString());
                actionContext.SetVariable("loot", lootTuning.InstanceKey.ToString());

                TuningActionInvoker.InvokeFromFile("Career PTO Interaction", actionContext);

                TuningExport.AddToQueue(tuning);

                ObjectInteractionsPythonStep.Current.AddPhoneInteraction(tuning.InstanceKey);
            }
        }
    }
}