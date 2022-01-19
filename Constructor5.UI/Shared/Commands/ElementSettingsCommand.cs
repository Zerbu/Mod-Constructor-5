using Constructor5.Base.ElementSystem;
using Constructor5.UI.Bases;
using Constructor5.UI.Dialogs;
using Constructor5.UI.Dialogs.ElementSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Constructor5.UI.Shared
{
    public class ElementSettingsCommand : CommandBase
    {
        public override bool CanExecute(object parameter) => parameter is Element;

        public override void Execute(object parameter)
        {
            var dialog = new ElementSettingsWindow((Element)parameter) { Owner = DialogUtility.GetOwner() };
            dialog.ShowDialog();
        }
    }
}
