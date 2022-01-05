using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem.Tuning;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Constructor5.Base.PropertyTypes
{
    public class STBLString : INotifyPropertyChanged, IXmlSerializable, ITunableValueObject
    {
        public STBLString() => SetGuid();

        public event PropertyChangedEventHandler PropertyChanged;

        public string CustomText { get; set; }
        public string Guid { get; set; }

        XmlSchema IXmlSerializable.GetSchema() => null;

        string ITunableValueObject.GetTunableValue()
        {
            if (Exporter.Current.STBLBuilder == null)
            {
                return "0x0";
            }

            var key = Exporter.Current.STBLBuilder.GetKey(this);
            if (key.HasValue)
            {
                return $"0x{key.Value:X}";
            }
            return null;
        }

        void IXmlSerializable.ReadXml(XmlReader reader)
        {
            CustomText = reader.GetAttribute("CustomText");
            Guid = reader.GetAttribute("Guid");
            SetGuid();
        }

        void IXmlSerializable.WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("CustomText", CustomText);
            writer.WriteAttributeString("Guid", Guid);
        }

        private static HashSet<string> UsedGuids { get; } = new HashSet<string>();

        private void SetGuid()
        {
            if (!string.IsNullOrEmpty(Guid))
            {
                UsedGuids.Add(Guid);
                return;
            }

            var guid = (string)null;
            var random = new Random();
            do
            {
                guid = new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", 10).Select(s => s[random.Next(s.Length)]).ToArray());
            } while (UsedGuids.Contains(guid));
            Guid = guid;
            UsedGuids.Add(guid);
        }
    }
}