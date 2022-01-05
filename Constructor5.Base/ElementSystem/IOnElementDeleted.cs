using Constructor5.Core;

namespace Constructor5.Base.ElementSystem
{

    public interface IOnElementDeleted : IHook
    {
        void OnElementDeleted(Element element);
    }
}
