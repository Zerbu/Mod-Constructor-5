using Constructor5.Core;

namespace Constructor5.Base.ElementSystem
{
    public interface IOnProjectCreatedOrLoaded : IHook
    {
        void OnProjectCreatedOrLoaded();
    }
}