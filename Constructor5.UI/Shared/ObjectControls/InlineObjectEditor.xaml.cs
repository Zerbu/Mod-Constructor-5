using System;
using System.Windows;
using System.Windows.Controls;

namespace Constructor5.UI.Shared
{
    /// <summary>
    /// Interaction logic for InlineObjectEditor.xaml
    /// </summary>
    public partial class InlineObjectEditor : UserControl
    {
        public static readonly DependencyProperty EditorCategoryProperty =
            DependencyProperty.Register("EditorCategory", typeof(string), typeof(InlineObjectEditor), new PropertyMetadata("Default"));

        public static readonly DependencyProperty EditorTagProperty =
            DependencyProperty.Register("EditorTag", typeof(string), typeof(InlineObjectEditor), new PropertyMetadata(null));

        public static readonly DependencyProperty ExtraButtonsProperty =
                    DependencyProperty.Register("ExtraButtons", typeof(object), typeof(InlineObjectEditor), new PropertyMetadata(null));

        public static readonly DependencyProperty ObjectProperty =
            DependencyProperty.Register("Object", typeof(object), typeof(InlineObjectEditor),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
                {
                    PropertyChangedCallback = (dp, e) => ((InlineObjectEditor)dp).OnObjectChanged()
                });

        public InlineObjectEditor() => InitializeComponent();

        public event Action ReplaceButtonClicked;

        public string EditorCategory
        {
            get => (string)GetValue(EditorCategoryProperty);
            set => SetValue(EditorCategoryProperty, value);
        }

        public string EditorTag
        {
            get => (string)GetValue(EditorTagProperty);
            set => SetValue(EditorTagProperty, value);
        }

        public object ExtraButtons
        {
            get => GetValue(ExtraButtonsProperty);
            set => SetValue(ExtraButtonsProperty, value);
        }

        public bool IsEditorOpen
        {
            get => EditorContainer.Visibility == Visibility.Visible;
            set => EditorContainer.Visibility = value ? Visibility.Visible : Visibility.Collapsed;
        }

        public object Object
        {
            get => GetValue(ObjectProperty);
            set => SetValue(ObjectProperty, value);
        }

        public bool HasEditor() => Object != null && ObjectEditorManager.HasEditor(Object, EditorCategory);

        public void OpenEditorIfItExists()
        {
            if (Object != null && ObjectEditorManager.HasEditor(Object, EditorCategory))
            {
                IsEditorOpen = true;
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e) => IsEditorOpen = false;

        private void OnObjectChanged()
        {
            if (Object == null || !ObjectEditorManager.HasEditor(Object, EditorCategory))
            {
                IsEditorOpen = false;
                return;
            }
        }

        private void ReplaceButton_Click(object sender, RoutedEventArgs e) => ReplaceButtonClicked.Invoke();
    }
}