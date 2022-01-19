using Constructor5.Base.ElementSystem;
using Constructor5.Core;
using Constructor5.UI.Bases;
using Constructor5.UI.Dialogs.PresetSelect;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Constructor5.UI.Shared
{
    public class SimpleBrowsePresetsCommand : CommandBase
    {
        public event Action<Preset[]> PresetsSelectedCallback;

        public bool AllowMultiple { get; set; }
        public bool CustomOnly { get; set; }
        public string ExcludeTag { get; set; }
        public string PresetsFolder { get; set; }
        public Type Type { get; set; }
        public Window OwnerWindow { get; set; }

        public string TypeName
        {
            get => Type.Name;
            set => Type = Reflection.GetTypeByName(value);
        }

        public override void Execute(object parameter)
        {
            var window = (PresetSelectWindow)null;
            if (Type != null)
            {
                window = new PresetSelectWindow(ElementTypeData.Get(Type), CustomOnly) { Owner = OwnerWindow, AllowMultiple = AllowMultiple, ExcludeTag = ExcludeTag };
            }
            else
            {
                window = new PresetSelectWindow(null, new List<string> { PresetsFolder }) { Owner = OwnerWindow, AllowMultiple = AllowMultiple, ExcludeTag = ExcludeTag };
            }

            window.PresetsSelectedCallback += (presets) => PresetsSelectedCallback.Invoke(presets);
            window.ShowDialog();
        }
    }
}