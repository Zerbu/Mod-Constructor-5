using System;
using System.IO;
using System.Text;
using System.Xml;

namespace Constructor5.DebugTools.ObjectFromTDescConverter
{
    public class Converter
    {
        public StringBuilder Outcome { get; } = new StringBuilder();
        public string Text { get; set; }

        public void Convert()
        {
            using (var reader = XmlReader.Create(new StringReader($"<root>{Text}</root>")))
            {
                while (reader.Read())
                {
                    switch (reader.Name)
                    {
                        case "Tunable":
                            ReadBasic(reader);
                            break;

                        case "TunableEnum":
                            ReadEnum(reader);
                            break;

                        /*case "TunableList":
                            ReadList(reader);
                            break;*/
                        case "TunableTuple":
                            ReadTuple(reader);
                            break;
                            /*case "TunableVariant":
                                ReadVariant(reader);
                                break;*/
                    }
                }
            }
        }

        private void AppendObject(string typeName, string varName, bool newTag = false)
        {
            Outcome.Append($"public {typeName} {varName} {{ get; }} {{ set; }}");
            if (newTag)
            {
                Outcome.Append($" = new {typeName}();");
            }
            Outcome.Append(Environment.NewLine);
        }

        private void ReadBasic(XmlReader reader)
        {
            switch (reader.GetAttribute("class"))
            {
                case "TunableLocalizedString":
                    AppendObject("STBLString", reader.GetAttribute("display").Replace(" ", ""), true);
                    break;

                case "TunableRange":
                    AppendObject("int", reader.GetAttribute("display").Replace(" ", ""));
                    break;

                case "Tunable":
                    AppendObject(reader.GetAttribute("type"), reader.GetAttribute("display").Replace(" ", ""));
                    break;
            }
        }

        private void ReadEnum(XmlReader reader)
        {
            switch (reader.GetAttribute("ParticipantType"))
            {
                case "TunableThreshold":
                    AppendObject("string", "Participant");
                    break;
            }
        }

        private void ReadTuple(XmlReader reader)
        {
            switch (reader.GetAttribute("class"))
            {
                case "TunableThreshold":
                    AppendObject("Threshold", reader.GetAttribute("display").Replace(" ", ""), true);
                    break;
                case "TunableInterval":
                    AppendObject("IntBounds", reader.GetAttribute("display").Replace(" ", ""), true);
                    break;
            }
        }
    }
}