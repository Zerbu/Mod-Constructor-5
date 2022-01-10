using Constructor5.Base.ElementSystem;
using Constructor5.Elements.Rewards;
using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Situations.Components
{
    [ObjectEditor(typeof(SituationGoaledEventComponent))]
    public partial class SituationGoaledEventEditor : UserControl, IObjectEditor
    {
        public SituationGoaledEventEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;

        private Element CreateElementFunction()
        {
            var result = (RewardSet)ElementManager.Create(typeof(RewardSet), null, true);
            result.IsHouseholdReward = true;
            return result;
        }
    }
}