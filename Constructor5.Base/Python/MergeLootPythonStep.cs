using Constructor5.Base.ProjectSystem;
using System.Collections.Generic;
using System.Text;

namespace Constructor5.Base.Python
{
    public class MergeLootPythonStep : PythonBuildStep
    {
        public static MergeLootPythonStep Current { get; } = new MergeLootPythonStep();

        public void AddLootActionSet(ulong mergeTo, ulong toMerge)
        {
            if (!LootsToMerge.ContainsKey(mergeTo))
            {
                LootsToMerge.Add(mergeTo, new List<ulong>());
            }

            if (!LootsToMerge[mergeTo].Contains(toMerge))
            {
                LootsToMerge[mergeTo].Add(toMerge);
            }
        }

        public override string GetContent()
        {
            var result = new StringBuilder();

            if (LootsToMerge.Count > 0)
            {
                result.AppendLine("@inject_to(InstanceManager, 'load_data_into_class_instances')");
                result.AppendLine($"def {Project.Id}_AddLoot(original, self):");

                result.AppendLine($"    original(self)");
                result.AppendLine($"    if self.TYPE == Types.ACTION:");

                foreach (var merger in LootsToMerge)
                {
                    foreach(var value in merger.Value)
                    {
                        result.AppendLine($"        {Project.Id}_AddLootInjector(self, {value}, {merger.Key})");
                    }
                }

                result.AppendLine("");
                result.AppendLine($"def {Project.Id}_AddLootInjector(self, to_merge_key, value):");
                result.AppendLine($"    manager = services.get_instance_manager(sims4.resources.Types.ACTION)");
                result.AppendLine($"    merge_to = self._tuned_classes.get(sims4.resources.get_resource_key(value, Types.ACTION))");
                result.AppendLine($"    if merge_to is None:");
                result.AppendLine($"        return");
                result.AppendLine($"    to_merge = manager.get(sims4.resources.get_resource_key(to_merge_key, Types.ACTION))");
                result.AppendLine($"    if to_merge is None:");
                result.AppendLine($"        return");
                result.AppendLine($"    merge_to.loot_actions = merge_to.loot_actions + to_merge.loot_actions");
            }

            return result.ToString();
        }

        public override IEnumerable<string> GetHeaders() => new[] {"import sims4.resources",
                "from sims4.tuning.instance_manager import InstanceManager",
                "from sims4.resources import Types",
                "import services"};

        protected internal override void Cleanup() => LootsToMerge.Clear();

        protected Dictionary<ulong, List<ulong>> LootsToMerge { get; } = new Dictionary<ulong, List<ulong>>();
    }
}
