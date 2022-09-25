using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.ExportSystem.TuningActions;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using Constructor5.Elements.CareerLevels;
using Constructor5.Elements.CareerTracks;
using System.Linq;

namespace Constructor5.Elements.Careers.Templates
{
    //[SelectableObjectType("CareerTypeTemplates", "CareerTemplateOddJobs")]
    [XmlSerializerExtraType]
    public class CareerTemplateOddJobs : CareerTemplateBase
    {
        public Reference CancelGigInteraction { get; set; } = new Reference();

        public override string Label => "Odd Jobs Career";

        public override int GetBasePerformance(int level)
        {
            var arr = new[] { 60, 50, 40, 30, 20, 15, 10, 8, 7, 6, 5 };
            return level >= arr.Length ? arr.Last() : arr[level];
        }

        public override string GetInteractionTuningActionsFile() => "Career Interaction Odd Jobs";

        public override string GetLevelSimDataFileName() => "CareerLevelNoSchedule";

        public override CareerLevelSimDataPositions GetLevelSimDataPositions() => new CareerLevelSimDataPositions
        {
            ObjectiveSet = 136,
            PerformanceStat = 160,
            Name = 172,
            Description = 176
        };

        public override string GetLevelTuningActionsFile() => "Career Level Odd Jobs";

        public override int GetNegativeEmotionModifier(int level) => -4;

        public override string GetSimDataFileName() => "CareerOddJobs";

        public override int GetSimDataTrackBytePosition() => 176;

        public override int GetStandardEmotionModifier(int level)
        {
            var arr = new[] { 10, 10, 10, 5, 5, 4, 4, 4, 3, 3, 3 };
            return level >= arr.Length ? arr.Last() : arr[level];
        }

        public override bool IgnorePay() => true;

        public override bool IgnorePerformance() => true;

        public override bool IgnoreSchedule() => true;

        protected internal override void OnExport(CareerExportContext context)
        {
            TuningActionInvoker.InvokeFromFile("Career Type Odd Jobs", new TuningActionContext
            {
                Tuning = context.Tuning,
                DataContext = this,
            });

            ((TuningHeader)context.Tuning).SimDataHandler.Write(192, ElementTuning.GetSingleInstanceKey(CancelGigInteraction).GetValueOrDefault());
            // cancel gig interaction: 192
        }

        protected internal override void TuneOvermax(TuningBase tuning, CareerTrack track)
        {
        }
    }
}