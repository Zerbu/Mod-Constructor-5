using Constructor5.Base.ProjectSystem;
using System.Collections.Generic;
using System.Text;

namespace Constructor5.Base.Python
{
    public class ObjectInteractionsPythonStep : PythonBuildStep
    {
        public static ObjectInteractionsPythonStep Current { get; } = new ObjectInteractionsPythonStep();

        public void AddInteractionToInteraction(ulong original, ulong toAdd)
        {
            var objectListString = string.Empty;
            objectListString += original;

            if (!InteractionToInteraction.ContainsKey(objectListString))
            {
                InteractionToInteraction.Add(objectListString, new List<ulong>());
            }

            InteractionToInteraction[objectListString].Add(toAdd);
        }

        public void AddObjectInteraction(IEnumerable<ulong> objectList, ulong interaction)
        {
            var objectListString = string.Empty;
            foreach (var obj in objectList)
            {
                objectListString += $"{obj},";
            }

            if (!ObjectToInteraction.ContainsKey(objectListString))
            {
                ObjectToInteraction.Add(objectListString, new List<ulong>());
            }

            ObjectToInteraction[objectListString].Add(interaction);
        }

        public void AddPhoneInteraction(ulong interaction)
        {
            var objectList = new List<ulong>() { 14965 };

            var objectListString = string.Empty;
            foreach (var obj in objectList)
            {
                objectListString += $"{obj},";
            }

            if (!PhoneObjectToInteraction.ContainsKey(objectListString))
            {
                PhoneObjectToInteraction.Add(objectListString, new List<ulong>());
            }

            PhoneObjectToInteraction[objectListString].Add(interaction);
        }

        public override string GetContent()
        {
            var result = new StringBuilder();

            if (ObjectToInteraction.Count > 0)
            {
                var index = 0;

                foreach (var interactionList in ObjectToInteraction)
                {
                    index++;

                    var interactionString = string.Empty;
                    foreach (var interaction in interactionList.Value)
                    {
                        interactionString += $"{interaction},";
                    }

                    result.AppendLine($"{Project.Id}_ObjectIds_{index} = ({interactionList.Key})");
                    result.AppendLine($"{Project.Id}_InteractionIds_{index} = ({interactionString})");

                    result.AppendLine("@inject_to(InstanceManager, 'load_data_into_class_instances')");
                    result.AppendLine($"def {Project.Id}_AddSuperAffordances_{index}(original, self, packs_to_load=None):");

                    result.AppendLine($"    original(self, packs_to_load)");
                    result.AppendLine($"    if self.TYPE == Types.OBJECT:");
                    result.AppendLine($"        affordance_manager = services.affordance_manager()");
                    result.AppendLine($"        sa_list = []");
                    result.AppendLine($"        for sa_id in {Project.Id}_InteractionIds_{index}:");
                    result.AppendLine($"            key = sims4.resources.get_resource_key(sa_id, Types.INTERACTION)");
                    result.AppendLine($"            sa_tuning = affordance_manager.get(key)");
                    result.AppendLine($"            if not sa_tuning is None:");
                    result.AppendLine($"                sa_list.append(sa_tuning)");
                    result.AppendLine($"        sa_tuple = tuple(sa_list)");
                    result.AppendLine($"        for obj_id in {Project.Id}_ObjectIds_{index}:");
                    result.AppendLine($"            key = sims4.resources.get_resource_key(obj_id, Types.OBJECT)");
                    result.AppendLine($"            obj_tuning = self._tuned_classes.get(key)");
                    result.AppendLine($"            if not obj_tuning is None:");
                    result.AppendLine($"                obj_tuning._super_affordances = obj_tuning._super_affordances + sa_tuple");
                }
            }

            if (InteractionToInteraction.Count > 0)
            {
                var index = 0;

                foreach (var interactionList in InteractionToInteraction)
                {
                    index++;

                    var interactionString = string.Empty;
                    foreach (var interaction in interactionList.Value)
                    {
                        interactionString += $"{interaction},";
                    }

                    result.AppendLine($"{Project.Id}_TargetInteractionIds_{index} = ({interactionString})");

                    result.AppendLine("@inject_to(InstanceManager, 'load_data_into_class_instances')");
                    result.AppendLine($"def {Project.Id}_AddSuperAffordances_BasedOnInteraction_{index}(original, self, packs_to_load=None):");

                    result.AppendLine($"    original(self, packs_to_load)");
                    result.AppendLine($"    if self.TYPE == Types.OBJECT:");
                    result.AppendLine($"        affordance_manager = services.affordance_manager()");
                    result.AppendLine($"        sa_list = []");
                    result.AppendLine($"        for sa_id in {Project.Id}_TargetInteractionIds_{index}:");
                    result.AppendLine($"            sa_tuning = affordance_manager.get(sims4.resources.get_resource_key(sa_id, Types.INTERACTION))");
                    result.AppendLine($"            if not sa_tuning is None:");
                    result.AppendLine($"                sa_list.append(sa_tuning)");
                    result.AppendLine($"        sa_tuple = tuple(sa_list)");

                    result.AppendLine($"        object_manager = services.get_instance_manager(Types.OBJECT)");
                    result.AppendLine($"        for obj_tuning in object_manager.types.values():");
                    result.AppendLine($"            if obj_tuning is None:");
                    result.AppendLine($"                continue");
                    result.AppendLine($"            if affordance_manager.get(sims4.resources.get_resource_key({interactionList.Key}, Types.INTERACTION)) in obj_tuning._super_affordances:");
                    result.AppendLine($"                obj_tuning._super_affordances = obj_tuning._super_affordances + sa_tuple");
                }
            }

            if (PhoneObjectToInteraction.Count > 0)
            {
                var index = 0;

                foreach (var interactionList in PhoneObjectToInteraction)
                {
                    index++;

                    var interactionString = string.Empty;
                    foreach (var interaction in interactionList.Value)
                    {
                        interactionString += $"{interaction},";
                    }

                    result.AppendLine($"{Project.Id}_ObjectIds_Phone = ({interactionList.Key})");
                    result.AppendLine($"{Project.Id}_InteractionIds_Phone = ({interactionString})");

                    result.AppendLine("@inject_to(InstanceManager, 'load_data_into_class_instances')");
                    result.AppendLine($"def {Project.Id}_AddSuperAffordances_Phone(original, self, packs_to_load=None):");

                    result.AppendLine($"    original(self, packs_to_load)");
                    result.AppendLine($"    if self.TYPE == Types.OBJECT:");
                    result.AppendLine($"        affordance_manager = services.affordance_manager()");
                    result.AppendLine($"        sa_list = []");
                    result.AppendLine($"        for sa_id in {Project.Id}_InteractionIds_Phone:");
                    result.AppendLine($"            key = sims4.resources.get_resource_key(sa_id, Types.INTERACTION)");
                    result.AppendLine($"            sa_tuning = affordance_manager.get(key)");
                    result.AppendLine($"            if not sa_tuning is None:");
                    result.AppendLine($"                sa_list.append(sa_tuning)");
                    result.AppendLine($"        sa_tuple = tuple(sa_list)");
                    result.AppendLine($"        for obj_id in {Project.Id}_ObjectIds_Phone:");
                    result.AppendLine($"            key = sims4.resources.get_resource_key(obj_id, Types.OBJECT)");
                    result.AppendLine($"            obj_tuning = self._tuned_classes.get(key)");
                    result.AppendLine($"            if not obj_tuning is None:");
                    result.AppendLine($"                obj_tuning._phone_affordances = obj_tuning._phone_affordances + sa_tuple");
                }
            }

            return result.ToString();
        }

        public override IEnumerable<string> GetHeaders() =>
            new[] { "import services", "import sims4.resources", "from sims4.tuning.instance_manager import InstanceManager", "from sims4.resources import Types" };

        protected internal override void Cleanup()
        {
            InteractionToInteraction.Clear();
            ObjectToInteraction.Clear();
            PhoneObjectToInteraction.Clear();
        }

        protected Dictionary<string, List<ulong>> InteractionToInteraction { get; } = new Dictionary<string, List<ulong>>();
        protected Dictionary<string, List<ulong>> ObjectToInteraction { get; } = new Dictionary<string, List<ulong>>();
        protected Dictionary<string, List<ulong>> PhoneObjectToInteraction { get; } = new Dictionary<string, List<ulong>>();

        private ObjectInteractionsPythonStep()
        {
        }
    }
}