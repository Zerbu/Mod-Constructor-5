using Constructor5.Base.ElementSystem;
using Constructor5.Base.LocalizationSystem;
using Constructor5.UI.Bases;
using Constructor5.UI.Dialogs;
using System.Windows;

namespace Constructor5.UI.Main
{
    public class ElementDeleteCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            var element = (Element)parameter;

            if (!FancyMessageBox.ShowOKCancel(TextStringManager.Get("DeleteElementAreYouSure").Replace("{label}", element.Label), true))
            {
                return;
            }

            ElementManager.Delete(element);
        }
    }
}
