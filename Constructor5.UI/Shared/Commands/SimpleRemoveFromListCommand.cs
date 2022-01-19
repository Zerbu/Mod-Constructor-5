using Constructor5.Core;
using Constructor5.UI.Bases;
using Constructor5.UI.Dialogs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Constructor5.UI.Shared
{
    public class SimpleRemoveFromListCommand : CommandBase
    {
        public string DeleteMessage { get; set; }
        public Type Type { get; set; }

        public string TypeName
        {
            get => Type.Name;
            set => Type = Reflection.GetTypeByName(value);
        }

        public override void Execute(object parameter)
        {
            if (!string.IsNullOrEmpty(DeleteMessage))
            {
                if (!FancyMessageBox.ShowOKCancel(DeleteMessage))
                {
                    return;
                }
            }

            var values = (object[])parameter;
            var obj = values[0];
            var list = (IList)values[1];

            if (obj != null)
            {
                list.Remove(obj);
                return;
            }
        }
    }
}
