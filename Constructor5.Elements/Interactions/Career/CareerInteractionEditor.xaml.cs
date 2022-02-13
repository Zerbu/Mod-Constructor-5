using Constructor5.Base.ElementSystem;
using Constructor5.Elements.BalloonSets;
using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Interactions.Career
{
    [ObjectEditor(typeof(CareerInteraction))]
    [ObjectEditor(typeof(CareerInteraction), "ElementMini")]
    public partial class CareerInteractionEditor : UserControl, IObjectEditor
    {
        public CareerInteractionEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;

        private Element CreateBalloonSetFunction()
        {
            var result = (BalloonSet)ElementManager.Create(typeof(BalloonSet), null, true);
            result.IsSpeech = false;
            return result;
        }
    }
}