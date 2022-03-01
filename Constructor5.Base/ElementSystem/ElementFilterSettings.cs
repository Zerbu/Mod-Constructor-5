using Constructor5.Base.ProjectSystem;
using Constructor5.Core;
using System.ComponentModel;
using System.IO;

namespace Constructor5.Base.ElementSystem
{
    public class ElementFilterSettings : INotifyPropertyChanged
    {
        private static ElementFilterSettings _current;

        public event PropertyChangedEventHandler PropertyChanged;

        public static ElementFilterSettings Current
        {
            get
            {
                if (_current == null)
                {
                    // this must come first otherwise there will be a StackOverflowException
                    _current = new ElementFilterSettings();

                    var file = $"{Project.GetProjectDirectory()}/ElementFilterSettings.xml";
                    if (File.Exists(file))
                    {
                        _current = XmlLoader.LoadFile<ElementFilterSettings>(file);
                    }
                }

                return _current;
            }
        }

        public bool IncludeIDInSearch { get; set; } = true;
        public bool IncludeLabelInSearch { get; set; } = true;
        public bool IncludeTagInSearch { get; set; } = true;
        public bool IncludeTypeNameInSearch { get; set; } = true;
        public string SearchText { get; set; }
        public bool ShowContextSpecific { get; set; }
        public bool SortByTag { get; set; }
        public bool SortByType { get; set; }

        public void Save() => XmlSaver.SaveFile(this, $"{Project.GetProjectDirectory()}/ElementFilterSettings.xml");

        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
            Hooks.Location<IOnElementFilterSettingChanged>(x => x.OnElementFilterSettingChanged());
        }
    }
}