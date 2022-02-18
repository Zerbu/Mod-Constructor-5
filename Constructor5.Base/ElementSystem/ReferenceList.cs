using System.ComponentModel;
using System.Linq;

namespace Constructor5.Base.ElementSystem
{
    public class ReferenceList : INotifyPropertyChanged
    {
#pragma warning disable CS0067
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore CS0067

        public FastObservableCollection<ReferenceListItem> Items { get; } = new FastObservableCollection<ReferenceListItem>();

        public T[] GetOfType<T>() where T : ReferenceListItem => Items.OfType<T>().ToArray();

        public bool HasItems() => Items.Count > 0;
    }
}