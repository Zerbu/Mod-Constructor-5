using Constructor5.UI.Dialogs;
using Constructor5.UI.Shared;
using System.Windows;
using System.Windows.Controls;
using MenuItem = Constructor5.UI.Shared.MenuItem;

namespace Constructor5.Elements.Broadcasters
{
    [ObjectEditor(typeof(Broadcaster), "ElementMini")]
    public partial class BroadcasterMiniEditor : UserControl, IObjectEditor
    {
        public BroadcasterMiniEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var condition = (BroadcasterConditionGroup)((MenuItem)sender).Tag;
            condition.IsExpanded = true;
        }

        private void SelectableObjectControl_DeleteButtonClicked(SelectableObjectControl control)
        {
            if (!FancyMessageBox.ShowOKCancel($"AreYouSureAction"))
            {
                return;
            }

            var group = (BroadcasterConditionGroup)VisualTreeUtility.GetParentOfType<ItemsControl>(control).Tag;
            group.Items.Remove((BroadcasterConditionGroupItem)control.Tag);
        }

        private void TestConditionControl_DeleteButtonClicked(SelectableObjectControl control)
        {
            if (!FancyMessageBox.ShowOKCancel($"AreYouSureConditionGroup"))
            {
                return;
            }

            var group = (BroadcasterConditionGroup)VisualTreeUtility.GetParentOfType<ItemsControl>(control).Tag;
            if (group != null)
            {
                group.Items.Remove((BroadcasterConditionGroupItem)control.Tag);
                return;
            }

            ((Broadcaster)DataContext).ConditionGroups.Remove((BroadcasterConditionGroup)control.Tag);
        }
    }
}