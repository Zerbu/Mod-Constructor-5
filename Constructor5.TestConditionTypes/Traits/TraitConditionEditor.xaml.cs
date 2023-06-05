using Constructor5.UI.Shared;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;
using System.Windows.Controls;

namespace Constructor5.TestConditionTypes.Traits
{
    [ObjectEditor(typeof(TraitCondition))]
    public partial class TraitConditionEditor : UserControl, IObjectEditor
    {
        public TraitConditionEditor() => InitializeComponent();

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
            var condition = (TraitCondition)DataContext;

            var sb = new StringBuilder();

            if (!string.IsNullOrEmpty(condition.Participant))
            {
                sb.Append($"{condition.Participant} ");
            }

            if (condition.Whitelist.Items.Count == 1 && condition.Blacklist.Items.Count == 0)
            {
                sb.Append($"Has Trait: {condition.Whitelist.Items[0]}");
            }
            else if (condition.Blacklist.Items.Count == 1 && condition.Whitelist.Items.Count == 0)
            {
                sb.Append($"Does Not Have Trait: {condition.Blacklist.Items[0]}");
            }
            else if (condition.Whitelist.Items.Count > 1 && condition.Blacklist.Items.Count == 0)
            {
                sb.Append($"Has Trait (Multiple)");
            }
            else if (condition.Whitelist.Items.Count == 0 && condition.Blacklist.Items.Count > 1)
            {
                sb.Append($"Does Not Have Trait (Multiple)");
            }
            else if (condition.Whitelist.Items.Count == 0 && condition.Blacklist.Items.Count == 0)
            {
                sb.Append("(Undefined Trait Condition)");
            }
            else
            {
                sb.Append("Complex Trait Condition");
            }

            condition.GeneratedLabel = sb.ToString();
        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e) => UpdateLabel();

        private void OnPropertyChangedEx(object sender, PropertyChangedEventArgs e) => UpdateLabel();

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            var condition = (TraitCondition)DataContext;
            condition.Whitelist.Items.CollectionChanged += OnCollectionChanged;
            condition.Blacklist.Items.CollectionChanged += OnCollectionChanged;
            condition.PropertyChanged += OnPropertyChangedEx;
        }

        private void UserControl_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            var condition = (TraitCondition)DataContext;
            condition.Whitelist.Items.CollectionChanged -= OnCollectionChanged;
            condition.Blacklist.Items.CollectionChanged += OnCollectionChanged;
            condition.PropertyChanged -= OnPropertyChangedEx;
        }
    }
}