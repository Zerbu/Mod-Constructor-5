using System;
using System.Windows;
using System.Windows.Controls;

namespace Constructor5.Elements.Broadcasters
{
    public class BroadcasterEditorTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var frameworkElement = container as FrameworkElement;

            var groupItem = item as BroadcasterConditionGroupItem;

            if (groupItem is BroadcasterConditionGroupEffect)
            {
                return (DataTemplate)frameworkElement.FindResource("ActionTemplate");
            }

            if (groupItem is BroadcasterConditionGroup)
            {
                return (DataTemplate)frameworkElement.FindResource("ConditionGroupTemplate");
            }

            throw new ArgumentOutOfRangeException("Invalid type");
        }
    }
}
