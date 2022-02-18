using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Constructor5.Base.ElementSystem
{
    public sealed class Reference : IXmlSerializable, INotifyPropertyChanged, IOnElementDeleted, ITunableValueObject
    {
        public Reference()
        { Hooks.RegisterClass(this); }

        public Reference(Element element) : base() => Element = element;

        public Reference(ulong gameReference, string gameReferenceLabel = null) : base()
        {
            GameReference = gameReference;
            GameReferenceLabel = gameReferenceLabel;
        }

        public Reference(Preset preset)
        {
            if (preset.CustomElement != null)
            {
                Element = preset.CustomElement;
                return;
            }

            GameReference = ulong.Parse(preset.Value);
            GameReferenceLabel = preset.Label;
        }

#pragma warning disable CS0067
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore CS0067

        public Element Element
        {
            get
            {
                if (_element == null && SavedGuid != null)
                {
                    Element = ElementManager.Get(SavedGuid);
                    if (_element == null) // assume the element has been deleted
                    {
                        SavedGuid = null;
                    }
                }

                return _element;
            }
            set
            {
                _element = value;
            }
        }

        public ulong GameReference { get; set; }

        public string GameReferenceLabel { get; set; }

        [Obsolete("For tooltip only")]
        public string Label
        {
            get
            {
                if (Element != null && !Element.IsDeleted)
                {
                    return $"{Element.Label} (Mod Reference)";
                }

                if (GameReference != 0)
                {
                    return $"{GameReference} ({GameReferenceLabel}) (Game Reference)";
                }

                return "Nothing Selected";
            }
        }

        XmlSchema IXmlSerializable.GetSchema() => null;

        string ITunableValueObject.GetTunableValue()
        {
            if (Element != null)
            {
                return ElementTuning.GetSingleInstanceKey(Element)?.ToString();
            }

            if (GameReference != 0)
            {
                return GameReference.ToString();
            }

            return null;
        }

        void IOnElementDeleted.OnElementDeleted(Element element)
        {
            if (element != null && element == Element)
            {
                Element = null;
            }
        }

        void IXmlSerializable.ReadXml(XmlReader reader)
        {
            var typeName = reader.GetAttribute("TypeName");
            if (typeName != null)
            {
                SavedGuid = reader.GetAttribute("Guid");
            }

            GameReference = ulong.TryParse(reader.GetAttribute("GameReference"), out var value) ? value : 0;
            GameReferenceLabel = reader.GetAttribute("GameReferenceLabel");
        }

        void IXmlSerializable.WriteXml(XmlWriter writer)
        {
            if (Element != null)
            {
                writer.WriteAttributeString("TypeName", Element.GetType().Name);
                writer.WriteAttributeString("Guid", Element.Guid);
            }

            if (GameReference != 0)
            {
                writer.WriteAttributeString("GameReference", GameReference.ToString());
                writer.WriteAttributeString("GameReferenceLabel", GameReferenceLabel);
            }
        }

        private Element _element;

        private string SavedGuid { get; set; }
    }
}