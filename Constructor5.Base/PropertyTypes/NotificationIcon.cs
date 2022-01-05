using Constructor5.Base.Icons;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Constructor5.Base.PropertyTypes
{
    public class NotificationIcon : INotifyPropertyChanged
    {
        public NotificationIconTypes IconType { get; set; } = NotificationIconTypes.None;
        public string SelectedParticipant { get; set; } = "Actor";
        public ElementIcon SelectedStandardIcon { get; set; } = new ElementIcon();

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
