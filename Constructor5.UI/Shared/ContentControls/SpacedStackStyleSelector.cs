using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Constructor5.UI.Shared
{
    public class SpacedStackStyleSelector : StyleSelector
    {
        public override Style SelectStyle(object item, DependencyObject container)
            => (Style)Application.Current.FindResource("SpacedStackMarginAtBottom");
    }
}
