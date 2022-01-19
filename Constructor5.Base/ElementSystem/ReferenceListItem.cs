using System.ComponentModel;

namespace Constructor5.Base.ElementSystem
{
    public class ReferenceListItem : INotifyPropertyChanged
    {
        public Reference Reference { get; set; } = new Reference();

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
