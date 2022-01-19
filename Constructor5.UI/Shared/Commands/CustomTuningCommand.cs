using Constructor5.Base.CustomTuning;
using Constructor5.Base.ElementSystem;
using Constructor5.UI.Bases;
using Constructor5.UI.Dialogs;
using Constructor5.UI.Dialogs.CustomTuningDialog;

namespace Constructor5.UI.Shared
{
    public class CustomTuningCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            var element = (ISupportsCustomTuning)parameter;
            new CustomTuningWindow(element) { Owner = DialogUtility.GetOwner() }.ShowDialog();
        }
    }
}
