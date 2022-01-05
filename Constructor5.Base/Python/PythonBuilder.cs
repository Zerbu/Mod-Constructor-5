using System.Collections.Generic;
using System.Text;

namespace Constructor5.Base.Python
{
    public class PythonBuilder
    {
        public static PythonBuilder Current { get; private set; }

        public static void AddStep(PythonBuildStep step)
        {
            if (GetPythonBuilder().Steps.Contains(step))
            {
                return;
            }

            Current.Steps.Add(step);
        }

        public static void Clear() => Current = null;

        public static PythonBuilder GetPythonBuilder()
        {
            if (Current == null)
            {
                Current = new PythonBuilder();
            }
            return Current;
        }

        public string GetContent()
        {
            var result = new StringBuilder();

            var headers = new HashSet<string> { "from functools import wraps" };

            foreach (var step in Steps)
            {
                foreach (var header in step.GetHeaders())
                {
                    headers.Add(header);
                }
            }

            foreach (var header in headers)
            {
                result.AppendLine(header);
            }

            result.AppendLine("\ndef inject(target_function, new_function):");
            result.AppendLine("    @wraps(target_function)");
            result.AppendLine("    def _inject(*args, **kwargs):");
            result.AppendLine("        return new_function(target_function, *args, **kwargs)");
            result.AppendLine("    return _inject\n");

            result.AppendLine("def inject_to(target_object, target_function_name):");
            result.AppendLine("    def _inject_to(new_function):");
            result.AppendLine("        target_function = getattr(target_object, target_function_name)");
            result.AppendLine("        setattr(target_object, target_function_name, inject(target_function, new_function))");
            result.AppendLine("        return new_function");
            result.AppendLine("    return _inject_to\n");

            foreach (var step in Steps)
            {
                result.AppendLine(step.GetContent());
            }

            return result.ToString();
        }

        private PythonBuilder()
        {
        }

        private List<PythonBuildStep> Steps { get; } = new List<PythonBuildStep>();
    }
}