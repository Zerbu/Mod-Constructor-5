using Constructor5.Base.ExportSystem.Tuning;

namespace Constructor5.Elements.SituationGoals
{
    public class SituationGoalExportContext
    {
        public SituationGoalExportContext()
        {
        }

        public SituationGoalExportContext(SituationGoalExportContext existing)
        {
            Element = existing.Element;
            MultiGeneratorSubTuningName = existing.MultiGeneratorSubTuningName;
            Tuning = existing.Tuning;
        }

        public SituationGoal Element { get; set; }
        public string MultiGeneratorSubTuningName { get; set; }
        public TuningBase Tuning { get; set; }
    }
}