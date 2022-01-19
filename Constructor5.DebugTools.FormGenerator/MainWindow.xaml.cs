using Constructor5.Base.ElementSystem;
using Constructor5.Base.Icons;
using Constructor5.Base.PropertyTypes;
using Constructor5.Core;
using System;
using System.Text;
using System.Windows;

namespace Constructor5.DebugTools.FormGenerator
{
    public partial class MainWindow : Window
    {
        public MainWindow() => InitializeComponent();

        protected string GenerateType(Type type)
        {
            var sb = new StringBuilder();

            foreach (var prop in type.GetProperties())
            {
                if (prop.PropertyType == typeof(STBLString))
                {
                    AddSTBLString(sb, prop);
                }
                else if (prop.PropertyType == typeof(string))
                {
                    if (prop.Name.Contains("Participant"))
                    {
                        AddParticipant(sb, prop);
                        continue;
                    }
                    /*else if (prop.Name.Contains())
                    {
                    }*/
                    AddString(sb, prop);
                }
                else if (prop.PropertyType == typeof(bool))
                {
                    AddBool(sb, prop);
                }
                else if (prop.PropertyType == typeof(Reference))
                {
                    AddReference(sb, prop);
                }
                else if (prop.PropertyType == typeof(ReferenceList))
                {
                    AddReferenceList(sb, prop);
                }
                else if (prop.PropertyType == typeof(int))
                {
                    AddInt(sb, prop);
                }
                else if (prop.PropertyType == typeof(double))
                {
                    AddDouble(sb, prop);
                }
                else if (prop.PropertyType == typeof(ElementIcon))
                {
                    AddIcon(sb, prop);
                }
                else if (prop.PropertyType == typeof(DoubleBounds))
                {
                    AddDoubleBounds(sb, prop);
                }
                else if (prop.PropertyType == typeof(IntBounds))
                {
                    AddIntBounds(sb, prop);
                }
                else if (prop.PropertyType == typeof(Threshold))
                {
                    AddThreshold(sb, prop);
                }
            }

            return sb.ToString();
        }

        private void AddBool(StringBuilder sb, System.Reflection.PropertyInfo prop)
        {
            WriteTagStart(sb, "CheckBox");
            WriteAttribute(sb, "IsChecked", $"{{Binding {prop.Name}}}");
            WriteAttribute(sb, "Content", prop.Name);
            WriteTagEnd(sb);
        }

        private void AddDouble(StringBuilder sb, System.Reflection.PropertyInfo prop)
        {
            AddFieldStart(sb, prop);

            WriteTagStart(sb, "xctk:DoubleUpDown");
            WriteAttribute(sb, "Text", $"{{Binding {prop.Name}}}");
            WriteTagEnd(sb);

            AddFieldEnd(sb, prop);
        }

        private void AddDoubleBounds(StringBuilder sb, System.Reflection.PropertyInfo prop)
        {
            AddFieldStart(sb, prop);

            WriteTagStart(sb, "c:DoubleBoundsControl");
            WriteAttribute(sb, "Bounds", $"{{Binding {prop.Name}}}");
            WriteTagEnd(sb);

            AddFieldEnd(sb, prop);
        }

        private void AddFieldEnd(StringBuilder sb, System.Reflection.PropertyInfo prop) =>
            sb.AppendLine($"        </c:Field>");

        private void AddFieldStart(StringBuilder sb, System.Reflection.PropertyInfo prop) =>
            sb.AppendLine($"        <c:Field Label=\"{prop.Name}\" LabelWidth=\"100\">");

        private void AddIcon(StringBuilder sb, System.Reflection.PropertyInfo prop)
        {
            AddFieldStart(sb, prop);

            WriteTagStart(sb, "c:IconControl");
            WriteAttribute(sb, "Text", $"{{Binding {prop.Name}}}");
            WriteTagEnd(sb);

            AddFieldEnd(sb, prop);
        }

        private void AddInt(StringBuilder sb, System.Reflection.PropertyInfo prop)
        {
            AddFieldStart(sb, prop);

            WriteTagStart(sb, "xctk:IntegerUpDown");
            WriteAttribute(sb, "Text", $"{{Binding {prop.Name}}}");
            WriteTagEnd(sb);

            AddFieldEnd(sb, prop);
        }

        private void AddIntBounds(StringBuilder sb, System.Reflection.PropertyInfo prop)
        {
            AddFieldStart(sb, prop);

            WriteTagStart(sb, "c:IntBoundsControl");
            WriteAttribute(sb, "Bounds", $"{{Binding {prop.Name}}}");
            WriteTagEnd(sb);

            AddFieldEnd(sb, prop);
        }

        private void AddParticipant(StringBuilder sb, System.Reflection.PropertyInfo prop)
        {
            AddFieldStart(sb, prop);

            WriteTagStart(sb, "c:ParticipantControl");
            WriteAttribute(sb, "Text", $"{{Binding {prop.Name}}}");
            WriteTagEnd(sb);

            AddFieldEnd(sb, prop);
        }

        private void AddReference(StringBuilder sb, System.Reflection.PropertyInfo prop)
        {
            AddFieldStart(sb, prop);

            WriteTagStart(sb, "c:ReferenceControl");
            WriteAttribute(sb, "Reference", $"{{Binding {prop.Name}}}");
            WriteAttribute(sb, "ElementTypeName", prop.Name);
            WriteTagEnd(sb);

            AddFieldEnd(sb, prop);
        }

        private void AddReferenceList(StringBuilder sb, System.Reflection.PropertyInfo prop)
        {
            AddFieldStart(sb, prop);

            WriteTagStart(sb, "c:ReferenceListControl");
            WriteAttribute(sb, "ElementReferenceList", $"{{Binding {prop.Name}}}");
            WriteAttribute(sb, "ElementTypeName", prop.Name);
            WriteTagEnd(sb);

            AddFieldEnd(sb, prop);
        }

        private void AddSTBLString(StringBuilder sb, System.Reflection.PropertyInfo prop)
        {
            AddFieldStart(sb, prop);

            WriteTagStart(sb, "c:STBLStringControl");
            WriteAttribute(sb, "Text", $"{{Binding {prop.Name}}}");
            WriteTagEnd(sb);

            AddFieldEnd(sb, prop);
        }

        private void AddString(StringBuilder sb, System.Reflection.PropertyInfo prop)
        {
            AddFieldStart(sb, prop);

            WriteTagStart(sb, "c:TextBoxWithPresetsControl");
            WriteAttribute(sb, "Text", $"{{Binding {prop.Name}}}");
            WriteAttribute(sb, "ElementTypeName", prop.Name);
            WriteTagEnd(sb);

            AddFieldEnd(sb, prop);
        }

        private void AddThreshold(StringBuilder sb, System.Reflection.PropertyInfo prop)
        {
            AddFieldStart(sb, prop);

            WriteTagStart(sb, "c:ThresholdControl");
            WriteAttribute(sb, "Threshold", $"{{Binding {prop.Name}}}");
            WriteTagEnd(sb);

            AddFieldEnd(sb, prop);
        }

        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            var type = Reflection.GetTypeByName(TypeNameTextBox.Text);
            ResultTextBox.Text = GenerateType(type);
        }

        private void WriteAttribute(StringBuilder sb, string attributeName, string text)
            => sb.Append($" {attributeName}=\"{text}\"");

        private void WriteTagEnd(StringBuilder sb)
            => sb.AppendLine(" />");

        private void WriteTagStart(StringBuilder sb, string text)
            => sb.Append($"            <{text}");
    }
}