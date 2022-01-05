using System.ComponentModel;

namespace Constructor5.Elements.Broadcasters
{
    public abstract class BroadcasterConditionGroupItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    }
}