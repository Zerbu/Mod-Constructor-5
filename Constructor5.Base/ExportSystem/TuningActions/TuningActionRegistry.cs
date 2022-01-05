using System;
using System.Collections.Generic;

namespace Constructor5.Base.ExportSystem.TuningActions
{
    public static class TuningActionRegistry
    {
        public static Dictionary<string, Type> Content { get; } = new Dictionary<string, Type>();
    }
}
