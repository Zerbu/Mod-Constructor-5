using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.LocalizationSystem;
using System.IO;
using System.Linq;
using System.Xml;

namespace Constructor5.Base.CustomTuning
{
    public class CustomTuningExporter
    {
        public static TuningHeader Header { get; set; }

        public static void Export(Element element, TuningHeader header, CustomTuningInfo customTuning)
        {
            Element = element;
            Header = header;
            new CustomTuningExporter().Export(header, customTuning.Text);
        }

        private static Element Element { get; set; }

        private int NumberOfCustomTextStrings { get; set; }

        private void Export(TuningHeader header, string content) => Read(header, content);

        private string Parse(string content)
        {
            if (content.StartsWith("#"))
            {
                var split = content.Split('#');
                var element = ElementManager.GetAll(true).FirstOrDefault(x => x.UserFacingId == split[1]);
                if (element == null)
                {
                    Exporter.Current.AddError(Element, TextStringManager.Get("CustomTuningCannotFindElement").Replace("{id}", split[1]));
                    return "ELEMENT NOT FOUND";
                }
                return ElementTuning.GetSingleInstanceKey(element).ToString();
            }

            if (content.StartsWith("$"))
            {
                var split = content.Split('$');

                if (Exporter.Current.STBLBuilder == null)
                {
                    return "0x0";
                }
                NumberOfCustomTextStrings++;
                var key = Exporter.Current.STBLBuilder.GetKey(split[1], $"{Element.Guid}_Auto_{NumberOfCustomTextStrings}");
                return $"0x{key:X}";
            }

            return content;
        }

        private void Read(TuningBase tuningPart, string content)
        {
            using (var reader = XmlReader.Create(new StringReader($"<root>{content}</root>"), new XmlReaderSettings { IgnoreComments = true }))
            {
                while (reader.Read())
                {
                    switch (reader.Name)
                    {
                        case "I":
                        case "M":
                            ReadHeader(tuningPart, reader, reader.Name == "M");
                            break;

                        case "T":
                            ReadBasic(tuningPart, reader);
                            break;

                        case "E":
                            ReadEnum(tuningPart, reader);
                            break;

                        case "L":
                            ReadList(tuningPart, reader);
                            break;

                        case "U":
                            ReadTuple(tuningPart, reader);
                            break;

                        case "V":
                            ReadVariant(tuningPart, reader);
                            break;

                        case "G":
                            Header.GroupKey = ulong.Parse(reader.GetAttribute("v"));
                            break;

                        case "C":
                            ReadClass(tuningPart, reader);
                            break;
                    }
                }
            }
        }

        private void ReadBasic(TuningBase tuningPart, XmlReader reader)
        {
            if (tuningPart is TunableList list)
            {
                list.Set<TunableBasic>(null, Parse(reader.ReadInnerXml()));
                return;
            }

            tuningPart.Set<TunableBasic>(reader.GetAttribute("n"), Parse(reader.ReadInnerXml()));
        }

        private void ReadClass(TuningBase tuningPart, XmlReader reader)
        {
            var tunable = tuningPart.Get<TunableClass>(reader.GetAttribute("n"));
            Read(tunable, reader.ReadInnerXml());
        }

        private void ReadEnum(TuningBase tuningPart, XmlReader reader)
        {
            if (tuningPart is TunableList list)
            {
                list.Set<TunableEnum>(null, reader.ReadInnerXml());
                return;
            }

            tuningPart.Set<TunableEnum>(reader.GetAttribute("n"), reader.ReadInnerXml());
        }

        private void ReadHeader(TuningBase tuningPart, XmlReader reader, bool isModule)
        {
            var classAttribute = reader.GetAttribute("c");
            if (classAttribute != null)
            {
                Header.Class = classAttribute;
            }

            var instanceAttribute = reader.GetAttribute("i");
            if (instanceAttribute != null)
            {
                Header.InstanceType = instanceAttribute;
            }

            var moduleAttribute = reader.GetAttribute("m");
            if (moduleAttribute != null)
            {
                Header.Module = moduleAttribute;
            }

            if (isModule)
            {
                var nameAttribute = reader.GetAttribute("n");
                if (nameAttribute != null)
                {
                    Header.Name = nameAttribute;
                }

                var keyAttribute = reader.GetAttribute("s");
                if (keyAttribute != null)
                {
                    Header.InstanceKey = ulong.Parse(keyAttribute);
                }
            }

            Read(tuningPart, reader.ReadInnerXml());
        }

        private void ReadList(TuningBase tuningPart, XmlReader reader)
        {
            if (tuningPart is TunableList list)
            {
                var newTunable = list.Get<TunableList>(null);
                Read(newTunable, reader.ReadInnerXml());
                return;
            }

            var tunable = tuningPart.Get<TunableList>(reader.GetAttribute("n"));
            Read(tunable, reader.ReadInnerXml());
        }

        private void ReadTuple(TuningBase tuningPart, XmlReader reader)
        {
            if (tuningPart is TunableList list)
            {
                var newTunable = list.Get<TunableTuple>(null);
                Read(newTunable, reader.ReadInnerXml());
                return;
            }

            var tunable = tuningPart.Get<TunableTuple>(reader.GetAttribute("n"));
            Read(tunable, reader.ReadInnerXml());
        }

        private void ReadVariant(TuningBase tuningPart, XmlReader reader)
        {
            if (tuningPart is TunableList list)
            {
                var newTunable = list.Set<TunableVariant>(null, reader.GetAttribute("t"));
                Read(newTunable, reader.ReadInnerXml());
                return;
            }

            var tunable = tuningPart.Set<TunableVariant>(reader.GetAttribute("n"), reader.GetAttribute("t"));
            Read(tunable, reader.ReadInnerXml());
        }
    }
}