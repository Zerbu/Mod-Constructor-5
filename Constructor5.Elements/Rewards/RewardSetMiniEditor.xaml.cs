using Constructor5.UI.Dialogs;
using Constructor5.UI.Shared;
using System.Linq;
using System.Windows.Controls;

namespace Constructor5.Elements.Rewards
{
    [ObjectEditor(typeof(RewardSet), "ElementMini")]
    public partial class RewardSetMiniEditor : UserControl, IObjectEditor
    {
        public RewardSetMiniEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
            if (tag == "NoUI")
            {
                UIInfoTab.Visibility = System.Windows.Visibility.Collapsed;
            }
            if (tag == "DescriptionAtTop")
            {
                UIInfoTab.Visibility = System.Windows.Visibility.Collapsed;
                UIInfoStackPanel.Children.Remove(DescriptionField);
                DescriptionAtTopPresenter.Content = DescriptionField;
            }
        }

        private void SelectableObjectControl_DeleteButtonClicked(SelectableObjectControl control)
        {
            if (!FancyMessageBox.ShowOKCancel($"Are you sure you want to delete the reward?"))
            {
                return;
            }

            var rewardSet = (RewardSet)DataContext;
            rewardSet.Rewards.Remove(rewardSet.Rewards.First(x => x.Reward == control.Object));
        }
    }
}