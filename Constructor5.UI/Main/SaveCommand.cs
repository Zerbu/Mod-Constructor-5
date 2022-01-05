using Constructor5.Base.ElementSystem;
using Constructor5.UI.Bases;

namespace Constructor5.UI.Main
{
    public class SaveCommand : CommandBase
    {
        public override void Execute(object parameter) => ElementSaver.SaveScheduled();
    }
}
