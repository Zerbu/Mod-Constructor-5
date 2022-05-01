using Constructor5.Base.ElementSystem;
using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.SimData;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.Icons;
using Constructor5.Base.PropertyTypes;

namespace Constructor5.Elements.CASPreferenceCategories
{
    [ElementTypeData("CASPreferenceCategory", true, ElementTypes = new[] { typeof(CASPreferenceCategory) }, IsRootType = true)]
    public class CASPreferenceCategory : Element, IExportableElement
    {
        public STBLString CASName { get; set; } = new STBLString();
        public ElementIcon Icon { get; set; } = new ElementIcon();
        public STBLString Name { get; set; } = new STBLString();
        public STBLString ToolTip { get; set; } = new STBLString();

        void IExportableElement.OnExport()
        {
            var tuning = ElementTuning.Create(this);
            tuning.Class = "CasPreferenceCategory";
            tuning.InstanceType = "cas_preference_category";
            tuning.Module = "cas.cas_preference_category";

            var tunableVariant1 = tuning.Set<TunableVariant>("_display_data", "optional_display_mixin");
            var tunableTuple1 = tunableVariant1.Get<TunableTuple>("optional_display_mixin");
            var tunableVariant2 = tunableTuple1.Set<TunableVariant>("instance_display_description", "enabled_display_description");
            tunableVariant2.Set<TunableBasic>("enabled_display_description", CASName);
            var tunableVariant3 = tunableTuple1.Set<TunableVariant>("instance_display_icon", "enabled_display_icon");
            tunableVariant3.Set<TunableBasic>("enabled_display_icon", Icon);
            var tunableVariant4 = tunableTuple1.Set<TunableVariant>("instance_display_name", "enabled_display_name");
            tunableVariant4.Set<TunableBasic>("enabled_display_name", Name);
            var tunableVariant5 = tunableTuple1.Set<TunableVariant>("instance_display_tooltip", "enabled_display_tooltip");
            tunableVariant5.Set<TunableBasic>("enabled_display_tooltip", ToolTip);

            tuning.SimDataHandler = new SimDataHandler("SimData/CASPreferenceCategory.data");
            tuning.SimDataHandler.WriteText(192, Exporter.Current.STBLBuilder.GetKey(Name) ?? 0);
            tuning.SimDataHandler.WriteText(196, Exporter.Current.STBLBuilder.GetKey(CASName) ?? 0);
            tuning.SimDataHandler.WriteText(200, Exporter.Current.STBLBuilder.GetKey(ToolTip) ?? 0);
            tuning.SimDataHandler.WriteTGI(208, Icon.GetUncommentedText(), this);

            TuningExport.AddToQueue(tuning);
        }

        protected override void OnUserCreated(string label)
        {
            GeneratedLabel = label;
            Name.CustomText = label;
        }
    }
}