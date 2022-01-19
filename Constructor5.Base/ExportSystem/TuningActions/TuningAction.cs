using Constructor5.Base.ExportSystem.TuningActions;

namespace Constructor5.ActionSystem.TuningActions
{
    public abstract class TuningAction
    {
        public abstract void Invoke(TuningActionContext context);
    }
}
