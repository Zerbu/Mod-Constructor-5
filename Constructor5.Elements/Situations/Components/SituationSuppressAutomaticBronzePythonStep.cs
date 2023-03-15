using Constructor5.Base.ProjectSystem;
using Constructor5.Base.Python;
using System.Collections.Generic;
using System.Text;

namespace Constructor5.Elements.Situations.Components
{
    public class SituationSuppressAutomaticBronzePythonStep : PythonBuildStep
    {
        public static SituationSuppressAutomaticBronzePythonStep Current { get; } = new SituationSuppressAutomaticBronzePythonStep();

        public static void AddSituation(ulong key) => Current.SituationKeys.Add(key);

        public override string GetContent()
        {
            var result = new StringBuilder();

            result.AppendLine($"@inject_to(situations.base_situation.BaseSituation, '_handle_automatic_bronze_promotion')");
            result.AppendLine($"def {Project.Id}_handle_automatic_bronze_promotion(original, self):");
            foreach (var key in SituationKeys)
            {
                result.AppendLine($"  if self.guid64 == {key}:");
            }
            result.AppendLine($"    return");
            result.AppendLine($"  return original(self)");

            return result.ToString();
        }

        public override IEnumerable<string> GetHeaders() => new HashSet<string> { "import situations" };

        protected List<ulong> SituationKeys { get; } = new List<ulong>();

        protected override void Cleanup()
        {
            SituationKeys.Clear();
        }

        private SituationSuppressAutomaticBronzePythonStep()
        {
        }
    }
}