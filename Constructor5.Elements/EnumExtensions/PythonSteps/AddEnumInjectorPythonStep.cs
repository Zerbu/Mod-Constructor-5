using Constructor5.Base.Python;
using System.Collections.Generic;
using System.Text;

namespace Constructor5.Elements.EnumExtensions.PythonSteps
{
    public class AddEnumInjectorPythonStep : PythonBuildStep
    {
        public static AddEnumInjectorPythonStep Current { get; } = new AddEnumInjectorPythonStep();

        public override string GetContent()
        {
            var result = new StringBuilder();

            result.AppendLine($"def inject_to_enum(kvp, enum_class):");
            result.AppendLine($"    with enum_class.make_mutable():");
            result.AppendLine($"        for (k, v) in kvp.items():");
            result.AppendLine($"            enum_class._add_new_enum_value(k, v)");

            return result.ToString();
        }

        public override IEnumerable<string> GetHeaders() => new HashSet<string> { };

        protected override void Cleanup()
        { }

        private AddEnumInjectorPythonStep()
        {
        }
    }
}