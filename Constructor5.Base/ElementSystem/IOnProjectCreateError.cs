using Constructor5.Base.ProjectSystem;
using Constructor5.Core;

namespace Constructor5.Base.ElementSystem
{
    public interface IOnProjectCreateError : IHook
    {
        void OnProjectCreateError(ProjectCreateErrorType errorType);
    }
}