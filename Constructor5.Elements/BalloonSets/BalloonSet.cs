using Constructor5.Base.CustomTuning;
using Constructor5.Base.ElementSystem;
using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using System.Collections.ObjectModel;

namespace Constructor5.Elements.BalloonSets
{
    [ElementTypeData("BalloonSet", true, ElementTypes = new[] { typeof(BalloonSet) }, PresetFolders = new[] { "Balloon" })]
    public class BalloonSet : Element, IExportableElement, ISupportsCustomTuning
    {
        public ObservableCollection<Balloon> Balloons { get; } = new ObservableCollection<Balloon>();

        public CustomTuningInfo CustomTuning { get; set; } = new CustomTuningInfo();
        public bool IsSpeech { get; set; } = true;

        void IExportableElement.OnExport()
        {
            var tuning = ElementTuning.Create(this);
            tuning.Class = "BalloonCategory";
            tuning.InstanceType = "balloon";
            tuning.Module = "balloon.balloon_category";

            tuning.Set<TunableBasic>("balloon_chance", "100");

            if (IsSpeech)
            {
                tuning.Set<TunableEnum>("balloon_type", "SPEECH");
            }

            var tunableList1 = tuning.Get<TunableList>("balloons");

            foreach (var balloon in Balloons)
            {
                var tunableTuple1 = tunableList1.Get<TunableTuple>(null);
                var tunableVariant1 = tunableTuple1.Set<TunableVariant>("item", "balloon_icon");
                var tunableTuple2 = tunableVariant1.Get<TunableTuple>("balloon_icon");

                var tunableVariant2 = tunableTuple2.Set<TunableVariant>("icon", "resource_key");
                var tunableTuple3 = tunableVariant2.Get<TunableTuple>("resource_key");

                if (balloon.HasOverlay)
                {
                    tunableTuple2.Set<TunableBasic>("overlay", "2f7d0004:00000000:ab4a67c934164fb1");
                }

                if (balloon.Weight > 1)
                {
                    tunableTuple2.Set<TunableBasic>("weight", balloon.Weight);
                }

                tunableTuple3.Set<TunableBasic>("key", balloon.Icon);
            }

            CustomTuningExporter.Export(this, tuning, CustomTuning);

            TuningExport.AddToQueue(tuning);
        }
    }
}