using System.ComponentModel;

namespace Constructor5.Base.PropertyTypes
{
    public class ComplexChance : INotifyPropertyChanged
    {
        public int BaseChance { get; set; } = 100;

#pragma warning disable CS0067
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore CS0067
    }
}