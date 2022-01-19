using Constructor5.Base.LocalizationSystem;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Constructor5.UI.Dialogs.UnlocalizableStringFinder
{
    /// <summary>
    /// Interaction logic for UnlocalizableStringFinderWindow.xaml
    /// </summary>
    public partial class UnlocalizableStringFinderWindow : Window
    {
        public UnlocalizableStringFinderWindow()
        {
            InitializeComponent();

            var sb = new StringBuilder();
            foreach (var str in UnlocalizableStringFinderProcess.Current.FoundStrings)
            {
                var newKey = str.Replace(" ", "");
                if (TextStringManager.HasKey(newKey))
                {
                    continue;
                }
                sb.AppendLine($"<String Key=\"{newKey}\">{str}</String>");
            }
            TextBox.Text = sb.ToString();
        }

        private void XMLReplaceButton_Click(object sender, RoutedEventArgs e)
        {
            if (!FancyMessageBox.ShowOKCancel("THIS IS DANGEROUS! CONTINUE???"))
            {
                return;
            }

            var strings = TextStringManager.GetAll();
            foreach (var xamlFile in Directory.GetFiles("D:\\Program Sources\\Constructor5\\Constructor5", "*.xaml", SearchOption.AllDirectories))
            {
                var text = File.ReadAllText(xamlFile);
                foreach (var str in strings)
                {
                    var valueToUse = str.Value.Replace("\"", "&quot;");
                    text = text.Replace($"Content=\"{valueToUse}\"", $"Content=\"{str.Key}\"");
                    text = text.Replace($"Header=\"{valueToUse}\"", $"Header=\"{str.Key}\"");
                    text = text.Replace($"Label=\"{valueToUse}\"", $"Label=\"{str.Key}\"");
                    text = text.Replace($"Text=\"{valueToUse}\"", $"Text=\"{str.Key}\"");
                    text = text.Replace($">{valueToUse}<", $">{str.Key}<");
                    text = text.Replace($">{valueToUse}</system:String>", $">{str.Key}</system:String>");
                }
                File.WriteAllText(xamlFile, text);
            }

            string ReplaceSelectableObject(string text, string registryCategory, KeyValuePair<string, string> keyValuePair)
            {
                return text.Replace($"SelectableObjectType(\"{registryCategory}\", \"{keyValuePair.Value}\"", $"SelectableObjectType(\"{registryCategory}\", \"{keyValuePair.Key}\"");
            }

            foreach (var csFile in Directory.GetFiles("D:\\Program Sources\\Constructor5\\Constructor5", "*.cs", SearchOption.AllDirectories))
            {
                var text = File.ReadAllText(csFile);
                foreach (var str in strings)
                {
                    var valueToUse = str.Value.Replace("\"", "\\" + "\"");

                    text = text.Replace($"public override string ComponentLabel => \"{str.Value}\";", $"public override string ComponentLabel => \"{str.Key}\";");
                    text = text.Replace($"HasAutoEditor(\"{valueToUse}\");", $"HasAutoEditor(\"{str.Key}\");");
                    text = text.Replace($"HasAutoEditor(\"{valueToUse}\");", $"HasAutoEditor(\"{str.Key}\");");

                    text = text.Replace($"ElementTypeData(\"{valueToUse}\"", $"ElementTypeData(\"{str.Key}\"");

                    text = text.Replace($"Show(\"{valueToUse}", $"Show(\"{str.Key}");
                    text = text.Replace($"ShowOKCancel(\"{valueToUse}", $"ShowOKCancel(\"{str.Key}");

                    text = ReplaceSelectableObject(text, "SituationGoalTemplates", str);
                    text = ReplaceSelectableObject(text, "LootActionTypes", str);
                    text = ReplaceSelectableObject(text, "TestConditionTypes", str);
                    text = ReplaceSelectableObject(text, "ObjectiveConditionTypes", str);
                    text = ReplaceSelectableObject(text, "HolidayTraditionConditionTypes", str);
                    text = ReplaceSelectableObject(text, "SituationGoalConditionTypes", str);
                    text = text.Replace($"Description = \"{str.Value}\"", $"Description = \"{str.Key}\"");
                    //[SelectableObjectType("SituationGoalTemplates", "SimConditionGoal")]
                }
                File.WriteAllText(csFile, text);
            }
        }
    }
}