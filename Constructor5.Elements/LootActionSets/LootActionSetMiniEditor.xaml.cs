using Constructor5.UI.Dialogs;
using Constructor5.UI.Shared;
using System.Windows;
using System.Windows.Controls;
using MenuItem = Constructor5.UI.Shared.MenuItem;

namespace Constructor5.Elements.LootActionSets
{
    [ObjectEditor(typeof(LootActionSet), "ElementMini")]
    public partial class LootActionSetMiniEditor : UserControl, IObjectEditor
    {
        public LootActionSetMiniEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;

        private void TestConditionControl_DeleteButtonClicked(SelectableObjectControl control)
        {
            if (!FancyMessageBox.ShowOKCancel($"Are you sure you want to delete the condition group? This cannot be undone!"))
            {
                return;
            }

            var group = (LASConditionGroup)VisualTreeUtility.GetParentOfType<ItemsControl>(control).Tag;
            if (group != null)
            {
                group.Items.Remove((LASConditionGroupItem)control.Tag);
                return;
            }

            ((LootActionSet)DataContext).ConditionGroups.Remove((LASConditionGroup)control.Tag);
        }

        private void SelectableObjectControl_DeleteButtonClicked(SelectableObjectControl control)
        {
            if (!FancyMessageBox.ShowOKCancel($"Are you sure you want to delete the action? This cannot be undone!"))
            {
                return;
            }

            var group = (LASConditionGroup)VisualTreeUtility.GetParentOfType<ItemsControl>(control).Tag;
            group.Items.Remove((LASConditionGroupItem)control.Tag);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var condition = (LASConditionGroup)((MenuItem)sender).Tag;
            condition.IsExpanded = true;
        }
    }
}