using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Elements.SituationGoals.Components;

namespace Constructor5.Elements.SituationGoals
{
    public static class SituationGoalTuner
    {
        public static TuningHeader CreateTuning(SituationGoal element, SituationGoalExportContext existingContext = null)
        {
            var tuning = ElementTuning.Create(element, existingContext?.MultiGeneratorSubTuningName);
            tuning.InstanceType = "situation_goal";

            var newContext = new SituationGoalExportContext(existingContext)
            {
                Tuning = tuning
            };

            foreach (var component in element.Components)
            {
                if (existingContext.MultiGeneratorSubTuningName != null && component is SituationGoalTemplateComponent)
                {
                    continue;
                }

                component.OnExport(newContext);
            }

            return tuning;
        }
    }
}
