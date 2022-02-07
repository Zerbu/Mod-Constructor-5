using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.TuningActions;
using Constructor5.Base.Icons;
using Constructor5.Base.PropertyTypes;
using Constructor5.Core;
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

        public bool AllowChild { get; set; }
        public bool AllowTeen { get; set; }
        public bool AllowYoungAdult { get; set; } = true;
        public bool AllowAdult { get; set; } = true;
        public bool AllowElder { get; set; } = true;

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

            TuningActionInvoker.InvokeFromFile("Career Type Work", new TuningActionContext
            {
                Tuning = context.Tuning,
                DataContext = this,
            });
        }
    }
}