using Constructor5.Base.ComponentSystem;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Constructor5.UI.Shared
{
    /// <summary>
    /// Interaction logic for ComponentViewer.xaml
    /// </summary>
    public partial class ComponentViewer : UserControl
    {
        public ComponentViewer() => InitializeComponent();

        public IHasComponents Element
        {
            get => (IHasComponents)GetValue(ElementProperty);
            set => SetValue(ElementProperty, value);
        }

        public static readonly DependencyProperty ElementProperty =
            DependencyProperty.Register("Element", typeof(IHasComponents), typeof(ComponentViewer),
                new PropertyMetadata(new PropertyChangedCallback((dp, e) =>
            {
                var viewer = (ComponentViewer)dp;
                viewer.ComponentsControl.ItemsSource = viewer.Element.GetSortedUserFacingComponents();
                viewer.ComponentsControl.SelectedIndex = 0;
            })));

        private void ComponentsControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Cache.ContainsKey(ComponentsControl.SelectedItem))
            {
                ComponentContentPresenter.Content = Cache[ComponentsControl.SelectedItem];
                return;
            }

            ComponentContentPresenter.Content = new ObjectEditorControl
            {
                EditorCategory = "Default",
                Object = ComponentsControl.SelectedItem
            };
            Cache.Add(ComponentsControl.SelectedItem, ComponentContentPresenter.Content);
        }

        private Dictionary<object, object> Cache { get; } = new Dictionary<object, object>();
    }
}
