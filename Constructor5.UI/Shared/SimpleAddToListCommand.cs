using Constructor5.Core;
using Constructor5.UI.Bases;
using System;
using System.Collections;

namespace Constructor5.UI.Shared
{
    public class SimpleAddToListCommand : CommandBase
    {
        public Type Type { get; set; }

        public string TypeName
        {
            get => Type.Name;
            set => Type = Reflection.GetTypeByName(value);
        }

        public override void Execute(object parameter)
        {
            var list = (IList)parameter;
            var obj = Reflection.CreateObject(Type);
            list.Add(obj);
        }
    }
}
