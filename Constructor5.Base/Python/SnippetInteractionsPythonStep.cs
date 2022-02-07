using Constructor5.Base.ProjectSystem;
using System.Collections.Generic;
using System.Text;

namespace Constructor5.Base.Python
{
    public class SnippetInteractionsPythonStep : PythonBuildStep
    {
        public static SnippetInteractionsPythonStep Current { get; } = new SnippetInteractionsPythonStep();

        public void AddSnippetInteraction(ulong snippetInstanceKey, ulong interactionInstanceKey)
        {
            if (!SnippetToMixer.ContainsKey(snippetInstanceKey))
            {
                SnippetToMixer.Add(snippetInstanceKey, new List<ulong>());
            }

            SnippetToMixer[snippetInstanceKey].Add(interactionInstanceKey);
        }

        public override string GetContent()
        {
            var result = new StringBuilder();

            if (SnippetToMixer.Count > 0)
            {
                foreach (var snippet in SnippetToMixer)
                {
                    var mixerString = string.Empty;
                    foreach (var mixer in snippet.Value)
                    {
                        mixerString += $"{mixer},";
                    }

                    result.AppendLine($"{Project.Id}_{snippet.Key}_SnippetId = {snippet.Key}");
                    result.AppendLine($"{Project.Id}_{snippet.Key}_MixerId = ({mixerString})");

                    result.AppendLine("@inject_to(InstanceManager, 'load_data_into_class_instances')");
                    result.AppendLine($"def {Project.Id}_AddMixer_{snippet.Key}(original, self):");
                    result.AppendLine($"    original(self)");
                    result.AppendLine($"    if self.TYPE == Types.SNIPPET:");
                    result.AppendLine($"        key = sims4.resources.get_resource_key({Project.Id}_{snippet.Key}_SnippetId, Types.SNIPPET)");
                    result.AppendLine($"        snippet_tuning = self._tuned_classes.get(key)");
                    result.AppendLine($"        if snippet_tuning is None:");
                    result.AppendLine($"            return");
                    result.AppendLine($"        for m_id in {Project.Id}_{snippet.Key}_MixerId:");
                    result.AppendLine($"            affordance_manager = services.affordance_manager()");
                    result.AppendLine($"            key = sims4.resources.get_resource_key(m_id, Types.INTERACTION)");
                    result.AppendLine($"            mixer_tuning = affordance_manager.get(key)");
                    result.AppendLine($"            if mixer_tuning is None:");
                    result.AppendLine($"                return");
                    result.AppendLine($"            if mixer_tuning in snippet_tuning.value:");
                    result.AppendLine($"                return");
                    result.AppendLine($"            snippet_tuning.value = snippet_tuning.value + (mixer_tuning, )");
                }
            }

            return result.ToString();
        }

        public override IEnumerable<string> GetHeaders() => new[] { "import services", "import sims4.resources", "from sims4.tuning.instance_manager import InstanceManager", "from sims4.resources import Types" };

        protected internal override void Cleanup() { }

        protected Dictionary<ulong, List<ulong>> SnippetToMixer { get; } = new Dictionary<ulong, List<ulong>>();
    }
}