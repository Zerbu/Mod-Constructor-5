using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.BalloonSets
{
    [ObjectEditor(typeof(BalloonSet), "ElementMini")]
    public partial class BalloonSetMiniEditor : UserControl, IObjectEditor
    {
        public BalloonSetMiniEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;

        private void DeleteButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var element = (BalloonSet)DataContext;
            element.Balloons.Remove((Balloon)((Button)sender).Tag);
        }
    }
}