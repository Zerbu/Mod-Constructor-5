using System.Collections.Generic;

namespace Constructor5.Base.Python
{
    public abstract class PythonBuildStep
    {
        public abstract IEnumerable<string> GetHeaders();
        public abstract string GetContent();
    }
}
