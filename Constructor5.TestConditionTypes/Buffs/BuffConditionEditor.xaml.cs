using Constructor5.UI.Shared;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;
using System.Windows.Controls;

namespace Constructor5.TestConditionTypes.Buffs
{
    [ObjectEditor(typeof(BuffCondition))]
    public partial class BuffConditionEditor : UserControl, IObjectEditor
    {
        public BuffConditionEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
            if (tag == "NoParticipant")
            {
                ParticipantField.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        protected void UpdateLabel()
        {
            var condition = (BuffCondition)DataContext;

            var sb = new StringBuilder();

            if (!string.IsNullOrEmpty(condition.Participant))
            {
                sb.Append($"{condition.Participant} ");
            }

            if (condition.Whitelist.Items.Count == 1 && condition.Blacklist.Items.Count == 0)
            {
                sb.Append($"Has Buff: {condition.Whitelist.Items[0]}");
            }
            else if (condition.Blacklist.Items.Count == 1 && condition.Whitelist.Items.Count == 0)
            {
                sb.Append($"Does Not Have Buff: {condition.Blacklist.Items[0]}");
            }
            else if (condition.Whitelist.Items.Count > 1 && condition.Blacklist.Items.Count == 0)
            {
                sb.Append($"Has Buff (Multiple)");
            }
            else if (condition.Whitelist.Items.Count == 0 && condition.Blacklist.Items.Count > 1)
            {
                sb.Append($"Does Not Have Buff (Multiple)");
            }
            else if (condition.Whitelist.Items.Count == 0 && condition.Blacklist.Items.Count == 0)
            {
                sb.Append("(Undefined Buff Condition)");
            }
            else
            {
                sb.Append("Complex Buff Condition");
            }

            condition.GeneratedLabel = sb.ToString();
        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e) => UpdateLabel();

        private void OnPropertyChangedEx(object sender, PropertyChangedEventArgs e) => UpdateLabel();

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            var condition = (BuffCondition)DataContext;
            condition.Whitelist.Items.CollectionChanged += OnCollectionChanged;
            condition.Blacklist.Items.CollectionChanged += OnCollectionChanged;
            condition.PropertyChanged += OnPropertyChangedEx;
        }

        private void UserControl_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            var condition = (BuffCondition)DataContext;
            condition.Whitelist.Items.CollectionChanged -= OnCollectionChanged;
            condition.Blacklist.Items.CollectionChanged += OnCollectionChanged;
            condition.PropertyChanged -= OnPropertyChangedEx;
        }
    }
}