using Constructor5.Base.ElementSystem;
using Constructor5.Base.PropertyTypes;
using System.ComponentModel;

namespace Constructor5.Elements.Buffs.References
{
    public class BuffWithReason : INotifyPropertyChanged
    {
        public Reference Buff { get; set; } = new Reference();
        public STBLString Reason { get; set; } = new STBLString();

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
