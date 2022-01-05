using Constructor5.Elements.TestConditions;
using Constructor5.UI.Dialogs;
using Constructor5.UI.Shared;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Constructor5.Elements.Interactions.Shared
{
    [ObjectEditor(typeof(InteractionConditionsComponent))]
    public partial class InteractionConditionsEditor : UserControl, IObjectEditor
    {
        public InteractionConditionsEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;

        private void SelectableObjectControl_DeleteButtonClicked(SelectableObjectControl control)
        {
            if (!FancyMessageBox.ShowOKCancel($"Are you sure you want to delete the condition group? This cannot be undone!"))
            {
                return;
            }

            var list = (IList<TestConditionListItem>)VisualTreeUtility.GetParentOfType<ItemsControl>(control).ItemsSource;
            list.Remove((TestConditionListItem)control.Tag);
        }
    }
}