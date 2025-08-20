using Constructor5.Base.ProjectSystem;
using Constructor5.Base.Python;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructor5.Elements.WhimSetExtensions
{
    public class WhimSetExtensionPythonStep : PythonBuildStep
    {
        public static WhimSetExtensionPythonStep Current { get; } = new WhimSetExtensionPythonStep();

        public void AddWhimSet(ulong mergeTo, ulong toMerge)
        {
            if (!SetsToMerge.ContainsKey(mergeTo))
            {
                SetsToMerge.Add(mergeTo, new List<ulong>());
            }

            if (!SetsToMerge[mergeTo].Contains(toMerge))
            {
                SetsToMerge[mergeTo].Add(toMerge);
            }
        }

        public override string GetContent()
        {
            var result = new StringBuilder();

            if (SetsToMerge.Count > 0)
            {
                result.AppendLine("@inject_to(InstanceManager, 'load_data_into_class_instances')");
                result.AppendLine($"def {Project.Id}_AddWhimSet(original, self, packs_to_load=None):");

                result.AppendLine($"    original(self, packs_to_load)");
                result.AppendLine($"    if self.TYPE == Types.ASPIRATION:");

                foreach (var merger in SetsToMerge)
                {
                    foreach (var value in merger.Value)
                    {
                        result.AppendLine($"        {Project.Id}_AddWhimSetInjector(self, {value}, {merger.Key})");
                    }
                }

                result.AppendLine("");
                result.AppendLine($"def {Project.Id}_AddWhimSetInjector(self, to_merge_key, merge_to_key):");
                result.AppendLine($"    manager = services.get_instance_manager(sims4.resources.Types.ASPIRATION)");
                result.AppendLine($"    merge_to = self._tuned_classes.get(sims4.resources.get_resource_key(merge_to_key, Types.ASPIRATION))");
                result.AppendLine($"    if merge_to is None:");
                result.AppendLine($"        return");
                result.AppendLine($"    to_merge = manager.get(sims4.resources.get_resource_key(to_merge_key, Types.ASPIRATION))");
                result.AppendLine($"    if to_merge is None:");
                result.AppendLine($"        return");
                result.AppendLine($"    merge_to.whims = merge_to.whims + to_merge.whims");
            }

            return result.ToString();
        }

        public override IEnumerable<string> GetHeaders() => new[] {"import sims4.resources",
                "from sims4.tuning.instance_manager import InstanceManager",
                "from sims4.resources import Types",
                "import services"};

        protected override void Cleanup() => SetsToMerge.Clear();

        protected Dictionary<ulong, List<ulong>> SetsToMerge { get; } = new Dictionary<ulong, List<ulong>>();
    }
}
