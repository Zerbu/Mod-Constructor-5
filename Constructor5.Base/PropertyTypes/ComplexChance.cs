using System.ComponentModel;

namespace Constructor5.Base.PropertyTypes
{
    public class ComplexChance : INotifyPropertyChanged
    {
        public int BaseChance { get; set; } = 100;

        public event PropertyChangedEventHandler PropertyChanged;
    }
}