using Constructor5.UI.Dialogs;
using Constructor5.UI.Shared;
using System.Windows;
using System.Windows.Controls;

namespace Constructor5.Elements.Buffs.References
{
    [ObjectEditor(typeof(BuffWithReasonReferenceListItem))]
    public partial class BuffWithReasonItemEditor : UserControl, IObjectEditor
    {
        public BuffWithReasonItemEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;

        private void HelpButton_Click(object sender, RoutedEventArgs e)
            => FancyMessageBox.Show("BuffReasonHelp");
    }
}