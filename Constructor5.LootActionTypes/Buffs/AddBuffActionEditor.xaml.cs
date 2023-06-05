using Constructor5.UI.Shared;
using System.ComponentModel;
using System.Text;
using System.Windows.Controls;

namespace Constructor5.LootActionTypes.Buffs
{
    [ObjectEditor(typeof(AddBuffAction))]
    public partial class AddBuffActionEditor : UserControl, IObjectEditor
    {
        public AddBuffActionEditor() => InitializeComponent();

        public void SetObject(object obj, string tag) => DataContext = obj;

        protected void UpdateLabel()
        {
            var condition = (AddBuffAction)DataContext;

            var sb = new StringBuilder();

            sb.Append("Add Buff");
            if (!string.IsNullOrEmpty(condition.Participant))
            {
                sb.Append($" to {condition.Participant}");
            }

            sb.Append($": {condition.Buff?.Buff?.GetSimpleLabel()}");

            condition.GeneratedLabel = sb.ToString();
        }

        private void OnPropertyChangedEx(object sender, PropertyChangedEventArgs e) => UpdateLabel();

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            var condition = (AddBuffAction)DataContext;
            condition.PropertyChanged += OnPropertyChangedEx;
            condition.Buff.PropertyChanged += OnPropertyChangedEx;
            condition.Buff.Buff.PropertyChanged += OnPropertyChangedEx;
        }

        private void UserControl_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            var condition = (AddBuffAction)DataContext;
            condition.PropertyChanged -= OnPropertyChangedEx;
            condition.Buff.PropertyChanged -= OnPropertyChangedEx;
            condition.Buff.Buff.PropertyChanged -= OnPropertyChangedEx;
        }
    }
}
