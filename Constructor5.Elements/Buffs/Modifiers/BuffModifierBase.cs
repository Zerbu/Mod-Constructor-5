using System.ComponentModel;

namespace Constructor5.Elements.Buffs.Modifiers
{
    public abstract class BuffModifierBase : INotifyPropertyChanged
    {
#pragma warning disable CS0067
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore CS0067
    }
}
