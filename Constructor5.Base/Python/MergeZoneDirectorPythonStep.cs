using Constructor5.Base.ProjectSystem;
using System.Collections.Generic;
using System.Text;

namespace Constructor5.Base.Python
{
    public class MergeZoneDirectorPythonStep : PythonBuildStep
    {
        public static MergeZoneDirectorPythonStep Current { get; } = new MergeZoneDirectorPythonStep();

        public void Add(ulong mergeTo, ulong toMerge)
        {
            if (!ToMerge.ContainsKey(mergeTo))
            {
                ToMerge.Add(mergeTo, new List<ulong>());
            }

            if (!ToMerge[mergeTo].Contains(toMerge))
            {
                ToMerge[mergeTo].Add(toMerge);
            }
        }

        public override string GetContent()
        {
            var result = new StringBuilder();

            if (ToMerge.Count > 0)
            {
                result.AppendLine("@inject_to(InstanceManager, 'load_data_into_class_instances')");
                result.AppendLine($"def {Project.Id}_AddZoneDirector(original, self, packs_to_load=None):");

                result.AppendLine($"    original(self, packs_to_load)");
                result.AppendLine($"    if self.TYPE == Types.ZONE_DIRECTOR:");

                foreach (var merger in ToMerge)
                {
                    foreach (var value in merger.Value)
                    {
                        result.AppendLine($"        {Project.Id}_AddZoneDirectorInjector(self, {value}, {merger.Key})");
                    }
                }

                result.AppendLine("");
                result.AppendLine($"def {Project.Id}_AddZoneDirectorInjector(self, to_merge_key, value):");
                result.AppendLine($"    manager = services.get_instance_manager(sims4.resources.Types.ZONE_DIRECTOR)");
                result.AppendLine($"    merge_to = self._tuned_classes.get(sims4.resources.get_resource_key(value, Types.ZONE_DIRECTOR))");
                result.AppendLine($"    if merge_to is None:");
                result.AppendLine($"        return");
                result.AppendLine($"    to_merge = manager.get(sims4.resources.get_resource_key(to_merge_key, Types.ZONE_DIRECTOR))");
                result.AppendLine($"    if to_merge is None:");
                result.AppendLine($"        return");
                result.AppendLine($"    merge_to.situation_shifts = merge_to.situation_shifts + to_merge.situation_shifts");
            }

            return result.ToString();
        }

        public override IEnumerable<string> GetHeaders() => new[] {"import sims4.resources",
                "from sims4.tuning.instance_manager import InstanceManager",
                "from sims4.resources import Types",
                "import services"};

        protected internal override void Cleanup() => ToMerge.Clear();

        protected Dictionary<ulong, List<ulong>> ToMerge { get; } = new Dictionary<ulong, List<ulong>>();
    }
}
