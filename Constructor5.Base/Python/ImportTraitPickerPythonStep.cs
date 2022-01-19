using Constructor5.Base.ProjectSystem;
using System.Collections.Generic;
using System.Text;

namespace Constructor5.Base.Python
{
    public class ImportTraitPickerPythonStep : PythonBuildStep
    {
        public static ImportTraitPickerPythonStep Current { get; } = new ImportTraitPickerPythonStep();

        public override string GetContent()
        {
            var result = new StringBuilder();

            result.AppendLine($"class {Project.Id}_TraitPickerSuperInteraction(TraitPickerSuperInteraction):");
            result.AppendLine($"    INSTANCE_TUNABLES = {{");
            result.AppendLine($"        'traits': TunableList(tunable=TunablePackSafeReference(manager=services.trait_manager()), allow_none=True),");
            result.AppendLine($"        'only_one_allowed': Tunable(tunable_type=bool, default=False)");
            result.AppendLine($"    }}");
            result.AppendLine("    @classmethod");
            result.AppendLine("    def _trait_selection_gen(cls, target):");
            result.AppendLine("        trait_tracker = target.sim_info.trait_tracker");
            result.AppendLine("        if cls.is_add:");
            result.AppendLine("            for trait in cls.traits:");
            result.AppendLine("                if trait_tracker.can_add_trait(trait):");
            result.AppendLine("                    yield trait");
            result.AppendLine("        else:");
            result.AppendLine("            for trait in trait_tracker.equipped_traits:");
            result.AppendLine("                yield trait");
            result.AppendLine($"    def on_choice_selected(self, choice_tag, **kwargs):");
            result.AppendLine($"        if self.only_one_allowed:");
            result.AppendLine($"            for trait in self.traits:");
            result.AppendLine($"                self.target.sim_info.remove_trait(trait)");
            result.AppendLine($"        super().on_choice_selected(choice_tag, **kwargs)");

            return result.ToString();
        }

        public override IEnumerable<string> GetHeaders() => new[] { "import services", "import sims4.resources", "from sims4.tuning.instance_manager import InstanceManager", "from sims4.resources import Types" };

        private ImportTraitPickerPythonStep()
        {
        }
    }
}
