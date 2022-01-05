using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Rewards.RewardTypes
{
    [ObjectEditor(typeof(TraitReward))]
    public partial class TraitRewardEditor : UserControl, IObjectEditor
    {
        public TraitRewardEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}