using System.ComponentModel;

namespace Constructor5.Elements.Broadcasters
{
    public abstract class BroadcasterConditionGroupItem : INotifyPropertyChanged
    {
#pragma warning disable CS0067
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore CS0067
    }
}