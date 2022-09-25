using Constructor5.Base.CustomTuning;
using Constructor5.Base.ElementSystem;
using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
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
        [AutoTuneBasic("_collapsible")]
        public bool Collapsible { get; set; }
        public STBLString Name { get; set; } = new STBLString();
        public Reference Parent { get; set; } = new Reference();
        [AutoTuneBasic("_display_priority", IgnoreIf = "0")]
        public int DisplayPriority { get; set; }

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

            if (Exporter.Current.STBLBuilder != null)
            {
                tuning.SimDataHandler = new SimDataHandler("SimData/PieMenuCategory.data");

                tuning.SimDataHandler.Write(64, Collapsible);

                tuning.SimDataHandler.WriteText(68, (uint)Exporter.Current.STBLBuilder.GetKey(Name));

                tuning.SimDataHandler.Write(72, DisplayPriority);

                tuning.SimDataHandler.WriteTGI(80, Icon.GetUncommentedText(), this);
                tuning.SimDataHandler.Write(96, ElementTuning.GetSingleInstanceKey(Parent) ?? 0);
                // todo: collapsible + display priority
            }

            TuningExport.AddToQueue(tuning);
        }

        protected override void OnUserCreated(string label)
        {
            GeneratedLabel = label;
            Name.CustomText = label;
        }
    }
}
