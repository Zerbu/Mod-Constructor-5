using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.LootActionTypes.Notifications
{
    [ObjectEditor(typeof(NotificationAction))]
    public partial class NotificationActionEditor : UserControl, IObjectEditor
    {
        public NotificationActionEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}
