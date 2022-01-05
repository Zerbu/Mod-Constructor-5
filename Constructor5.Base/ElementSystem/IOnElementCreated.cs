using Constructor5.Core;

namespace Constructor5.Base.ElementSystem
{
    public interface IOnElementCreated : IHook
    {
        void OnElementCreated(Element element);
    }
}
