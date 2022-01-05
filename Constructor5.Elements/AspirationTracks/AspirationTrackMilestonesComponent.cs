using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Xml;
using System.Collections.Generic;

namespace Constructor5.Elements.AspirationTracks
{
    [XmlSerializerExtraType]
    public class AspirationTrackMilestonesComponent : AspirationTrackComponent
    {
        public override string ComponentLabel => "Milestones";

        public ReferenceList Milestones { get; set; } = new ReferenceList();

        protected internal override void OnExport(AspirationTrackExportContext context)
        {
            var tunableList1 = context.Tuning.Get<TunableList>("aspirations");

            var level = 1;
            foreach (var milestone in ElementTuning.GetInstanceKeys(Milestones))
            {
                var tunableTuple1 = tunableList1.Get<TunableTuple>(null);
                tunableTuple1.Set<TunableEnum>("key", $"LEVEL_{level}");
                tunableTuple1.Set<TunableBasic>("value", milestone);
                level++;
            }

            var list = new List<ulong>();
            foreach(var key in ElementTuning.GetInstanceKeys(Milestones))
            {
                list.Add(key);
            }
            ((TuningHeader)context.Tuning).SimDataHandler.WriteList(232, list, 4, true, 8);
        }
    }
}