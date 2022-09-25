using Constructor5.UI.Dialogs;
using Constructor5.UI.Shared;
using System.Windows;
using System.Windows.Controls;

namespace Constructor5.Elements.InteractionBasicExtras
{
    /// <summary>
    /// Interaction logic for BasicExtrasControl.xaml
    /// </summary>
    public partial class BasicExtrasControl : UserControl
    {
        public BasicExtrasControl()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var condition = (BasicExtrasConditionGroup)((Constructor5.UI.Shared.MenuItem)sender).Tag;
            condition.IsExpanded = true;
        }

        private void SelectableObjectControl_DeleteButtonClicked(SelectableObjectControl control)
        {
            if (!FancyMessageBox.ShowOKCancel("AreYouSureConditionGroup"))
            {
                return;
            }

            var group = (BasicExtrasConditionGroup)VisualTreeUtility.GetParentOfType<ItemsControl>(control).Tag;
            group.Items.Remove((BasicExtrasConditionGroupItem)control.Tag);
        }

        private void TestConditionControl_DeleteButtonClicked(SelectableObjectControl control)
        {
            if (!FancyMessageBox.ShowOKCancel("AreYouSureConditionGroup"))
            {
                return;
            }

            var group = (BasicExtrasConditionGroup)VisualTreeUtility.GetParentOfType<ItemsControl>(control).Tag;
            if (group != null)
            {
                group.Items.Remove((BasicExtrasConditionGroupItem)control.Tag);
                return;
            }

    ((BasicExtrasList)DataContext).ConditionGroups.Remove((BasicExtrasConditionGroup)control.Tag);
        }
    }
}