using Constructor5.Base.ExportSystem.Tuning;
using System;

namespace Constructor5.Elements.LootActionSets
{
    public static class LootTuning
    {
        public static TunableTuple GetActionTuple(TuningBase tunable, string name) => tunable.GetVariant<TunableTuple>(null, name);
    }
}
