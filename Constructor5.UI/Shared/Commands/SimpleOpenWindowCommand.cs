using Constructor5.Core;
using Constructor5.UI.Bases;
using System;
using System.Windows;

namespace Constructor5.UI.Shared
{
    public class SimpleOpenWindowCommand : CommandBase
    {
        public bool IsDialog { get; set; }
        public string TypeName { get; set; }
        public Window OwnerWindow { get; set; }

        public override void Execute(object parameter)
        {
            var window = (Window)Reflection.CreateObject(Reflection.GetTypeByName(TypeName));
            window.Owner = OwnerWindow;

            if (IsDialog)
            {
                window.ShowDialog();
                return;
            }

            window.Show();
        }
    }
}
