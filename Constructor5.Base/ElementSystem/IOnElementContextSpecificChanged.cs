using Constructor5.Core;

namespace Constructor5.Base.ElementSystem
{
    public interface IOnElementContextSpecificChanged : IHook
    {
        void OnElementContextSpecificChanged(Element element);
    }
}