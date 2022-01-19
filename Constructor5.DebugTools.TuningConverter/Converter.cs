using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace Constructor5.DebugTools.TuningConverter
{
    public class Converter
    {
        public int ListIndex { get; set; }

        public StringBuilder Outcome { get; } = new StringBuilder();

        public string Text { get; set; }
        public int TupleIndex { get; set; }
        public int VariantIndex { get; set; }

        public void Convert(string text = null, string name = "tuning", bool parentIsList = false)
        {
            if (text == null)
            {
                text = this.Text;
            }

            text = Regex.Replace(text, "<!--.*?-->", string.Empty, RegexOptions.Multiline);

            using (var reader = XmlReader.Create(new StringReader($"<root>{text}</root>")))
            {
                while (reader.Read())
                {
                    switch (reader.Name)
                    {
                        case "T":
                        case "Tunable":
                            this.ReadBasic(reader, name, parentIsList);
                            break;
                        case "E":
                        case "TunableEnum":
                            this.ReadEnum(reader, name, parentIsList);
                            break;
                        case "L":
                        case "TunableList":
                            this.ReadList(reader, name, parentIsList);
                            break;
                        case "U":
                        case "TunableTuple":
                            this.ReadTuple(reader, name, parentIsList);
                            break;
                        case "V":
                        case "TunableVariant":
                            this.ReadVariant(reader, name, parentIsList);
                            break;
                    }
                }
            }
        }

        private void ReadBasic(XmlReader reader, string parentName = "Tuning", bool parentIsList = false)
        {
            var name = reader.GetAttribute("n") ?? reader.GetAttribute("name");
            var value = reader.ReadInnerXml();

            if (parentIsList)
            {
                this.Outcome.AppendLine($"{parentName}.Set<TunableBasic>(null, \"{value}\");");
            }
            else
            {
                this.Outcome.AppendLine($"{parentName}.Set<TunableBasic>(\"{name}\", \"{value}\");");
            }
        }

        private void ReadEnum(XmlReader reader, string parentName = "Tuning", bool parentIsList = false)
        {
            var name = reader.GetAttribute("n") ?? reader.GetAttribute("name");
            var value = reader.ReadInnerXml();

            if (parentIsList)
            {
                this.Outcome.AppendLine($"{parentName}.Set<TunableEnum>(null, \"{value}\");");
            }
            else
            {
                this.Outcome.AppendLine($"{parentName}.Set<TunableEnum>(\"{name}\", \"{value}\");");
            }
        }

        private void ReadList(XmlReader reader, string parentName = "tuning", bool parentIsList = false)
        {
            this.ListIndex++;
            var name = reader.GetAttribute("n") ?? reader.GetAttribute("name");
            var varName = $"tunableList{this.ListIndex}";

            if (parentIsList)
            {
                this.Outcome.AppendLine($"var {varName} = {parentName}.Get<TunableList>(null);");
            }
            else
            {
                this.Outcome.AppendLine($"var {varName} = {parentName}.Get<TunableList>(\"{name}\");");
            }

            this.Convert(reader.ReadInnerXml(), varName, true);
        }

        private void ReadTuple(XmlReader reader, string parentName = "Tuning", bool parentIsList = false)
        {
            this.TupleIndex++;
            var name = reader.GetAttribute("n") ?? reader.GetAttribute("name");
            var varName = $"tunableTuple{this.TupleIndex}";

            if (parentIsList)
            {
                this.Outcome.AppendLine($"var {varName} = {parentName}.Get<TunableTuple>(null);");
            }
            else
            {
                this.Outcome.AppendLine($"var {varName} = {parentName}.Get<TunableTuple>(\"{name}\");");
            }

            this.Convert(reader.ReadInnerXml(), varName);
        }

        private void ReadVariant(XmlReader reader, string parentName = "tuning", bool parentIsList = false)
        {
            this.VariantIndex++;
            var name = reader.GetAttribute("n") ?? reader.GetAttribute("Name");
            var variant = reader.GetAttribute("t");
            var varName = $"tunableVariant{this.VariantIndex}";

            if (parentIsList)
            {
                this.Outcome.AppendLine($"var {varName} = {parentName}.Set<TunableVariant>(null, \"{variant}\");");
            }
            else
            {
                this.Outcome.AppendLine($"var {varName} = {parentName}.Set<TunableVariant>(\"{name}\", \"{variant}\");");
            }

            this.Convert(reader.ReadInnerXml(), varName);
        }
    }
}
