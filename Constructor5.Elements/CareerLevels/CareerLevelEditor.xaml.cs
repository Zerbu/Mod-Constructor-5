using Constructor5.Base.ElementSystem;
using Constructor5.Elements.CareerTracks;
using Constructor5.Elements.ObjectiveSets;
using Constructor5.Elements.Rewards;
using Constructor5.Elements.Rewards.RewardTypes;
using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.CareerLevels
{
    [ObjectEditor(typeof(CareerLevel))]
    public partial class CareerLevelEditor : UserControl, IObjectEditor
    {
        public CareerLevelEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;

        private Element CreateObjectiveSetFunction()
        {
            var element = (Element)DataContext;

            var result = ElementManager.Create(typeof(ObjectiveSet), null, true);
            result.AddContextModifier(new CareerObjectiveSetContextModifier
            {
                CareerLevel = new Reference(element)
            });

            return result;
        }

        private Element CreateRewardFunction()
        {
            var result = (RewardSet)ElementManager.Create(typeof(RewardSet), null, true);
            result.Rewards.Add(new RewardItem() { Reward = new MoneyFixedReward() { Amount = 100 } } );
            return result;
        }
    }
}