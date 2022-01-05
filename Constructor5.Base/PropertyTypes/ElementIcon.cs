using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem.Tuning;
using System.ComponentModel;
using System.Xml.Serialization;
using Constructor5.Base.ExportSystem;

namespace Constructor5.Base.Icons
{
    public class ElementIcon : INotifyPropertyChanged, ITunableValueObject
    {
        public ElementIcon() { }

        public ElementIcon(string text) => Text = text;

        public ElementIcon(string path, string text)
        {
            Path = path;
            Text = text;
        }

        [XmlAttribute]
        public string Path { get; set; } = "Icons/BG Misc/missing_image 30f0846c783606f9.png";

        [XmlAttribute]
        public string Text { get; set; } = "2f7d0004:00000000:30f0846c783606f9 <<<Default Image";

        public string GetUncommentedText() => CommentUtility.StripComment(Text);

        public event PropertyChangedEventHandler PropertyChanged;

        string ITunableValueObject.GetTunableValue() => GetUncommentedText();
    }
}
