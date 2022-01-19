using Constructor5.Core;

namespace Constructor5.Base.LocalizationSystem
{
    public interface IOnUnlocalizableStringDetected : IHook
    {
        void OnUnlocalizableStringDetected(string text);
    }
}
