using Constructor5.Core;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;

namespace Constructor5.Base.ElementSystem
{
    public abstract class Element : INotifyPropertyChanged, IAutosavableObject
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<ContextModifier> ContextModifiers { get; } = new ObservableCollection<ContextModifier>();

        [XmlAttribute]
        public string CustomLabel { get; set; }

        public string GeneratedLabel
        {
            get
            {
                if (_generatedLabel == null)
                {
                    _generatedLabel = GetDefaultLabel();
                }

                return _generatedLabel;
            }
            set => _generatedLabel = value;
        }

        [XmlAttribute]
        public string Guid
        {
            get => _guid;
            set
            {
                if (_guid != null)
                {
                    ElementManager.UsedUserFacingIds.Remove(_guid);
                }

                _guid = value;
                ElementManager.UsedUserFacingIds.Add(Guid);
            }
        }

        public ulong? InstanceKeyOverride { get; set; }

        [XmlAttribute]
        public bool IsContextSpecific
        {
            get => _isContextSpecific;
            set
            {
                _isContextSpecific = value;
                Hooks.Location<IOnElementContextSpecificChanged>(x => x.OnElementContextSpecificChanged(this));
            }
        }

        [XmlIgnore]
        public bool IsDeleted { get; internal set; }

        public bool IsTemporary { get; set; }

        [XmlIgnore]
        public string Label
        {
            get => CustomLabel ?? GeneratedLabel ?? UserFacingId;
            set => CustomLabel = value;
        }

        [XmlAttribute]
        public int SaveVersion { get; set; } = 1;

        [XmlAttribute]
        public bool ShowPreset { get; set; } = true;

        [XmlAttribute]
        public string UserFacingId
        {
            get => _userFacingId;
            set
            {
                if (_userFacingId != null)
                {
                    ElementManager.UsedUserFacingIds.Remove(_userFacingId);
                }

                _userFacingId = value;
                ElementManager.UsedUserFacingIds.Add(UserFacingId);
            }
        }

        public void AddContextModifier(ContextModifier modifier)
        {
            IsContextSpecific = true;
            ContextModifiers.Add(modifier);
        }

        public T GetContextModifier<T>() where T : ContextModifier => ContextModifiers.FirstOrDefault(x => x is T) as T;

        public virtual string GetDefaultLabel() => $"New {ElementTypeData.Get(GetType()).Label}";

        void IAutosavableObject.OnAutosave()
        {
            if (IsDeleted)
            {
                return;
            }

            ElementSaver.Save(this);
        }

        protected internal virtual void OnElementCreatedOrLoaded()
        { }

        protected internal virtual void OnUserCreated(string label) => CustomLabel = label;

        private string _generatedLabel;
        private string _guid;
        private bool _isContextSpecific;
        private string _userFacingId;
    }
}