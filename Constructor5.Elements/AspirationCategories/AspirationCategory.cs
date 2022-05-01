using Constructor5.Base.CustomTuning;
using Constructor5.Base.ElementSystem;
using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.SimData;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.Icons;
using Constructor5.Base.PropertyTypes;

namespace Constructor5.Elements.AspirationCategories
{
    [ElementTypeData("AspirationCategory", true, ElementTypes = new[] { typeof(AspirationCategory) }, PresetFolders = new[] { "AspirationCategory" }, IsRootType = true)]
    public class AspirationCategory : Element, IExportableElement, ISupportsCustomTuning
    {
        public CustomTuningInfo CustomTuning { get; set; } = new CustomTuningInfo();
        public ElementIcon Icon { get; set; } = new ElementIcon();
        public STBLString Name { get; set; } = new STBLString();

        void IExportableElement.OnExport()
        {
            var tuning = ElementTuning.Create(this);
            tuning.Class = "AspirationCategory";
            tuning.InstanceType = "aspiration_category";
            tuning.Module = "aspirations.aspiration_tuning";

            tuning.SimDataHandler = new SimDataHandler($"SimData/AspirationCategory.data");

            tuning.Set<TunableBasic>("display_text", Name);
            tuning.Set<TunableBasic>("icon", Icon);

            tuning.SimDataHandler.WriteText(64, Exporter.Current.STBLBuilder.GetKey(Name) ?? 0);
            tuning.SimDataHandler.WriteTGI(72, Icon.GetUncommentedText(), this);

            CustomTuningExporter.Export(this, tuning, CustomTuning);

            TuningExport.AddToQueue(tuning);
        }

        protected override void OnUserCreated(string label)
        {
            GeneratedLabel = label;
            Name = new STBLString() { CustomText = label };
        }
    }
}