using System;
using System.Windows;
using System.Windows.Controls;

namespace Constructor5.Elements.LootActionSets
{
    public class LASEditorTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var frameworkElement = container as FrameworkElement;

            var groupItem = item as LASConditionGroupItem;

            if (groupItem is LASConditionGroupAction)
            {
                return (DataTemplate)frameworkElement.FindResource("ActionTemplate");
            }

            if (groupItem is LASConditionGroup)
            {
                return (DataTemplate)frameworkElement.FindResource("ConditionGroupTemplate");
            }

            throw new ArgumentOutOfRangeException("Invalid type");
        }
    }
}
