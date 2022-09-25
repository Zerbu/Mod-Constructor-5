using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Constructor5.Elements.InteractionBasicExtras
{
    public class BasicExtrasEditorTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var frameworkElement = container as FrameworkElement;

            var groupItem = item as BasicExtrasConditionGroupItem;

            if (groupItem is BasicExtrasConditionGroupAction)
            {
                return (DataTemplate)frameworkElement.FindResource("ActionTemplate");
            }

            if (groupItem is BasicExtrasConditionGroup)
            {
                return (DataTemplate)frameworkElement.FindResource("ConditionGroupTemplate");
            }

            throw new ArgumentOutOfRangeException("Invalid type");
        }
    }
}
