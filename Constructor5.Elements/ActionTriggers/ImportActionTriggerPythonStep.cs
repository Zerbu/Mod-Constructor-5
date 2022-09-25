using Constructor5.Base.ProjectSystem;
using Constructor5.Base.Python;
using System.Collections.Generic;
using System.Text;

namespace Constructor5.Elements.ActionTriggers
{
    public class ImportActionTriggerPythonStep : PythonBuildStep
    {
        public static ImportActionTriggerPythonStep Current { get; } = new ImportActionTriggerPythonStep();

        public override string GetContent()
        {
            var result = new StringBuilder();

            result.AppendLine($"class ActionTriggerMetaclass(HashedTunedInstanceMetaclass):");
            result.AppendLine($"    pass");

            result.AppendLine($"class ActionTrigger(Objective, metaclass=ActionTriggerMetaclass, manager=services.objective_manager()):");
            result.AppendLine($"    @classmethod");
            result.AppendLine($"    def activate_action_trigger(cls):");
            result.AppendLine($"        services.get_event_manager().register_tests(cls, (cls.objective_test,))");

            result.AppendLine($"    @classmethod");
            result.AppendLine($"    def handle_event(cls, sim_info, event, resolver):");
            result.AppendLine($"        if sim_info is None:");
            result.AppendLine($"            return");
            result.AppendLine($"        for loot_action in cls.completion_loot:");
            result.AppendLine($"            loot_action.apply_to_resolver(resolver)");

            result.AppendLine($"@inject_to(SimInfoManager, 'on_loading_screen_animation_finished')");
            result.AppendLine($"def {Project.Id}_activate_action_triggers(original, self, *args, **kwargs):");
            result.AppendLine($"    for objective in services.objective_manager().types.values():");
            result.AppendLine($"        if isinstance(objective, ActionTriggerMetaclass):");
            result.AppendLine($"            objective.activate_action_trigger()");

            return result.ToString();
        }

        public override IEnumerable<string> GetHeaders() => new HashSet<string> { "from event_testing.objective_tuning import Objective", "from sims.sim_info_manager import SimInfoManager", "from sims4.tuning.instances import HashedTunedInstanceMetaclass", "import services", "import sims4.log", "import sims4.tuning.tunable" };

        protected override void Cleanup()
        { }

        private ImportActionTriggerPythonStep()
        {
        }
    }
}