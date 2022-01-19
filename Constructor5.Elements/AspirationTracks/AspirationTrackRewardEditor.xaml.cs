using Constructor5.Base.ElementSystem;
using Constructor5.Elements.Rewards;
using Constructor5.Elements.Rewards.RewardTypes;
using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.AspirationTracks
{
    [ObjectEditor(typeof(AspirationTrackReward))]
    public partial class AspirationTrackRewardEditor : UserControl, IObjectEditor
    {
        public AspirationTrackRewardEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;

        private Element CreateElementFunction()
        {
            var result = (RewardSet)ElementManager.Create(typeof(RewardSet), null, true);
            result.GenerateUIInfo = true;
            result.Rewards.Add(new RewardItem() { Reward = new TraitReward() });
            return result;
        }
    }
}