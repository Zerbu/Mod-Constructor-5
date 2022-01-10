using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Rewards.RewardTypes
{
    [ObjectEditor(typeof(BuffReward))]
    public partial class BuffRewardEditor : UserControl, IObjectEditor
    {
        public BuffRewardEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}