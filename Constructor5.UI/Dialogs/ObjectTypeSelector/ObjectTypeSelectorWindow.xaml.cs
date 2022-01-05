using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Constructor5.UI.Dialogs.ObjectTypeSelector
{
    /// <summary>
    /// Interaction logic for TestConditionWindow.xaml
    /// </summary>
    public partial class ObjectTypeSelectorWindow : Window
    {
        public ObjectTypeSelectorWindow() => InitializeComponent();

        public ObjectTypeSelectorWindow(string registryCategory)
        {
            InitializeComponent();
            TestConditionSelector.ItemsSource = ContentRegistry.GetAll<SelectableObjectType>(registryCategory).OrderBy(x => x.DisplayName);
            AddExtraTabs(registryCategory);
        }

        public event Action<object> ObjectChangedCallback;

        public void NotifyObjectChanged(object obj)
        {
            ObjectChangedCallback.Invoke(obj);
            Close();
        }

        private void AddExtraTabs(string registryCategory)
        {
            foreach (var tabType in ObjectTypeExtraTabManager.GetExtraTabs(registryCategory))
            {
                var tabContent = (IObjectTypeSelectorExtraTab)Activator.CreateInstance(tabType);
                tabContent.Initialize(this);
                TabControl.Items.Add(new TabItem
                {
                    Header = tabContent.TabName,
                    Content = tabContent
                });
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var conditionType = (SelectableObjectType)((Button)sender).Tag;
            NotifyObjectChanged(Reflection.CreateObject(conditionType.Type));
        }
    }
}