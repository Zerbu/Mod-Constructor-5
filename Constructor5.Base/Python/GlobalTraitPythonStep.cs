using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructor5.Base.Python
{
    public class GlobalTraitPythonStep : PythonBuildStep
    {
        public static GlobalTraitPythonStep Current { get; } = new GlobalTraitPythonStep();

        public void AddTrait(ulong traitKey) => GlobalTraits.Add(traitKey);

        public override string GetContent()
        {
            var result = new StringBuilder();

            if (GlobalTraits.Count > 0)
            {
                result.AppendLine("@inject_to(Sim, 'on_add')");
                result.AppendLine("def add_traits_after_sim_spawned(original, self, *args, **kwargs):");
                result.AppendLine("    result = original(self, *args, **kwargs)");
                result.AppendLine("    add_traits_to_sim(self.sim_info)");
                result.AppendLine("    return result");

                result.AppendLine("def add_traits_to_sim(sim_info):");
                result.AppendLine("    trait_manager = services.trait_manager()");
                result.AppendLine("    if sim_info is None:");
                result.AppendLine("        return");
                foreach(var trait in GlobalTraits)
                {
                    result.AppendLine($"    sim_info.add_trait(trait_manager.get({trait}))");
                }
            }

            return result.ToString();
        }

        public override IEnumerable<string> GetHeaders() => new[] { "import services", "from sims.sim import Sim" };

        protected internal override void Cleanup() => GlobalTraits.Clear();

        protected List<ulong> GlobalTraits { get; } = new List<ulong>();
    }
}
