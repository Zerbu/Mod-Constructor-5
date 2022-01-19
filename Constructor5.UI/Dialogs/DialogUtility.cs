using System.Linq;
using System.Windows;

namespace Constructor5.UI.Dialogs
{
    public static class DialogUtility
    {
        public static Window GetOwner(DependencyObject control = null)
        {
            if (control != null)
            {
                return Window.GetWindow(control);
            }

            return Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
        }
    }
}
