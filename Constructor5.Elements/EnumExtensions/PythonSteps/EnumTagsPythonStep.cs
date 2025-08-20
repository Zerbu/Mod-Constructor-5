using Constructor5.Base.ProjectSystem;
using Constructor5.Base.Python;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Constructor5.Elements.EnumExtensions.PythonSteps
{
    public class EnumTagsPythonStep : PythonBuildStep
    {
        public static EnumTagsPythonStep Current { get; } = new EnumTagsPythonStep();

        public override string GetContent()
        {
            var result = new StringBuilder();

            result.AppendLine($"TAGS = {{");
            foreach(var tag in Tags)
            {
                result.AppendLine($"    '{tag.Key}': {tag.Value},");
            }
            result.AppendLine($"}}");

            result.AppendLine("inject_to_enum(TAGS, Tag)");
            result.AppendLine("inject_to_enum(TAGS, TagCategory)");

            if (TagInteractionInjections.Count() > 0)
            {
                result.AppendLine("@inject_to(InstanceManager, 'load_data_into_class_instances')");
                result.AppendLine($"def {Project.Id}_AddInteractionTags(original, self, packs_to_load=None):");

                result.AppendLine($"    original(self, packs_to_load)");
                result.AppendLine($"    if self.TYPE == Types.INTERACTION:");

                foreach (var injection in TagInteractionInjections)
                {
                    foreach (var value in injection.Value)
                    {
                        result.AppendLine($"        {Project.Id}_AddInteractionTag(self, {value}, \"{injection.Key}\")");
                    }
                }

                result.AppendLine("");
                result.AppendLine($"def {Project.Id}_AddInteractionTag(self, interaction_key, tag_name):");
                result.AppendLine($"    manager = services.get_instance_manager(sims4.resources.Types.INTERACTION)");
                result.AppendLine($"    inject_to = self._tuned_classes.get(sims4.resources.get_resource_key(interaction_key, Types.INTERACTION))");
                result.AppendLine($"    if inject_to is None:");
                result.AppendLine($"        return");
                result.AppendLine($"    if TAGS[tag_name] in inject_to.interaction_category_tags:");
                result.AppendLine($"        return");
                result.AppendLine($"    result = list(inject_to.interaction_category_tags)");
                result.AppendLine($"    result.append(TAGS[tag_name])");
                result.AppendLine($"    inject_to.interaction_category_tags = frozenset(result)");
            }

            return result.ToString();
        }

        public override IEnumerable<string> GetHeaders() => new HashSet<string> { "from tag import Tag, TagCategory", "import sims4.resources",
                "from sims4.tuning.instance_manager import InstanceManager",
                "from sims4.resources import Types",
                "import services" };

        protected override void Cleanup()
        {
            Tags.Clear();
            TagInteractionInjections.Clear();
        }

        public void AddTag(string itemName, ulong hash, IEnumerable<ulong> interactionInjections)
        {
            Tags.Add(itemName, hash);
            if (interactionInjections.Count() > 0)
            {
                TagInteractionInjections.Add(itemName, interactionInjections.ToArray());
            }
        }

        protected Dictionary<string, ulong> Tags { get; } = new Dictionary<string, ulong>();
        protected Dictionary<string, ulong[]> TagInteractionInjections { get; } = new Dictionary<string, ulong[]>();

        private EnumTagsPythonStep()
        {
        }
    }
}