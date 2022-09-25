using Constructor5.Base.ExportSystem.Tuning;

namespace Constructor5.Elements.InteractionBasicExtras
{
    public static class BasicExtrasTuning
    {
        public static TunableTuple GetActionTuple(TuningBase tunable, string name) => tunable.GetVariant<TunableTuple>(null, name);

        public static void TuneBasicExtras(BasicExtrasList list, TunableList listTunable)
        {
            var context = new BasicExtraExportContext()
            {
                BasicExtrasListTunable = listTunable
            };

            foreach (var group in list.ConditionGroups)
            {
                list.ExportConditionGroup(group, context);
            }
        }
    }
}
