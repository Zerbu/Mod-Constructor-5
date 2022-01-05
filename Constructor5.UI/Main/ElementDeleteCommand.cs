using Constructor5.Base.ElementSystem;
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

            if (!FancyMessageBox.ShowOKCancel($"Are you sure you want to delete the element: {element.Label}?"))
            {
                return;
            }

            ElementManager.Delete(element);
        }
    }
}
