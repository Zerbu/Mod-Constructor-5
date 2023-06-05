using System.ComponentModel;

namespace Constructor5.Base.ElementSystem
{
    public class ReferenceListItem : INotifyPropertyChanged
    {
        public Reference Reference { get; set; } = new Reference();

#pragma warning disable CS0067
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore CS0067

        public override string ToString() => Reference?.GetSimpleLabel();
    }
}
