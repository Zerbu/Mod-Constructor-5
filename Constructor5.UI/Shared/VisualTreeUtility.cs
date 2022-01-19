using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Constructor5.UI.Shared
{
    public static class VisualTreeUtility
    {
        public static T GetParentOfType<T>(DependencyObject obj) where T : DependencyObject
        {
            var current = obj;

            do
            {
                current = VisualTreeHelper.GetParent(current);
                if (current is T)
                {
                    return (T)current;
                }
            } while (current != null);

            return null;
        }
    }
}
