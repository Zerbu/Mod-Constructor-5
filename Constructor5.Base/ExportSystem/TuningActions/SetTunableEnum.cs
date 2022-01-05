using Constructor5.ActionSystem.TuningActions;
using Constructor5.Base.ExportSystem.Tuning;
using System;

namespace Constructor5.Base.ExportSystem.TuningActions
{

    [RegisterTuningAction("E")]
    public class SetTunableEnum : SetTunableAction
    {
        protected override void SetTunable(TuningActionContext context, string name, string value)
            => context.Tuning.Set<TunableEnum>(name, value);
    }
}
