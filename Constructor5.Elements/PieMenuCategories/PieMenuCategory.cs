using Constructor5.Base.CustomTuning;
using Constructor5.Base.ElementSystem;
using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.SimData;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.Icons;
using Constructor5.Base.PropertyTypes;

namespace Constructor5.Elements.PieMenuCategories
{
    [ElementTypeData("PieMenuCategory", true, ElementTypes = new[] { typeof(PieMenuCategory) }, PresetFolders = new[] { "PieMenuCategory" }, IsRootType = true)]
    public class PieMenuCategory : Element, IExportableElement, ISupportsCustomTuning
    {
        public CustomTuningInfo CustomTuning { get; set; } = new CustomTuningInfo();
        public bool HasIcon { get; set; }
        public ElementIcon Icon { get; set; } = new ElementIcon();
        public STBLString Name { get; set; } = new STBLString();
        public Reference Parent { get; set; } = new Reference();

        void IExportableElement.OnExport()
        {
            var tuning = ElementTuning.Create(this);
            tuning.Class = "PieMenuCategory";
            tuning.InstanceType = "pie_menu_category";
            tuning.Module = "interactions.pie_menu_category";

            tuning.Set<TunableBasic>("_display_name", Name);
            if (HasIcon)
            {
                tuning.Set<TunableBasic>("_icon", Icon);
            }
            tuning.Set<TunableBasic>("_parent", Parent);

            tuning.SimDataHandler = new SimDataHandler("SimData/PieMenuCategory.data");
            tuning.SimDataHandler.WriteText(68, (uint)Exporter.Current.STBLBuilder.GetKey(Name));
            tuning.SimDataHandler.WriteTGI(80, Icon.GetUncommentedText(), this);
            tuning.SimDataHandler.Write(96, ElementTuning.GetSingleInstanceKey(Parent) ?? 0);

            TuningExport.AddToQueue(tuning);
        }

        protected override void OnUserCreated(string label)
        {
            GeneratedLabel = label;
            Name.CustomText = label;
        }
    }
}
