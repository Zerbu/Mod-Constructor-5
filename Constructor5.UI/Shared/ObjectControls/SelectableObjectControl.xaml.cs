using Constructor5.Base.PropertyTypes;
using Constructor5.UI.Dialogs;
using Constructor5.UI.Dialogs.ObjectTypeSelector;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Constructor5.UI.Shared
{
    public partial class SelectableObjectControl : UserControl
    {
        public static readonly DependencyProperty DeleteCommandParameterProperty =
            DependencyProperty.Register("DeleteCommandParameter", typeof(object), typeof(SelectableObjectControl), new PropertyMetadata(null));

        public static readonly DependencyProperty DeleteCommandProperty =
            DependencyProperty.Register("DeleteCommand", typeof(ICommand), typeof(SelectableObjectControl), new PropertyMetadata(null));

        public static readonly DependencyProperty EditorCategoryProperty =
                            DependencyProperty.Register("EditorCategory", typeof(string), typeof(SelectableObjectControl), new PropertyMetadata("Default"));

        public static readonly DependencyProperty EditorTagProperty =
            DependencyProperty.Register("EditorTag", typeof(string), typeof(SelectableObjectControl), new PropertyMetadata(null));

        public static readonly DependencyProperty ExtraButtonsProperty =
            DependencyProperty.Register("ExtraButtons", typeof(object), typeof(SelectableObjectControl), new PropertyMetadata(null));

        public static readonly DependencyProperty ObjectProperty =
            DependencyProperty.Register("Object", typeof(object), typeof(SelectableObjectControl),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, (dp, e) =>
                {
                    var control = (SelectableObjectControl)dp;
                    control.ObjectChanged?.Invoke(control.Object);
                }));

        public static readonly DependencyProperty OwnerWindowProperty =
            DependencyProperty.Register("OwnerWindow", typeof(Window), typeof(SelectableObjectControl), new PropertyMetadata(null));

        public static readonly DependencyProperty TypeRegistryCategoryProperty =
            DependencyProperty.Register("TypeRegistryCategory", typeof(string), typeof(SelectableObjectControl), new PropertyMetadata(null));

        public SelectableObjectControl() => InitializeComponent();

        public event Action<SelectableObjectControl> DeleteButtonClicked;

        public ICommand DeleteCommand
        {
            get => (ICommand)GetValue(DeleteCommandProperty);
            set => SetValue(DeleteCommandProperty, value);
        }

        public object DeleteCommandParameter
        {
            get => (object)GetValue(DeleteCommandParameterProperty);
            set => SetValue(DeleteCommandParameterProperty, value);
        }

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
            get => (object)GetValue(ExtraButtonsProperty);
            set => SetValue(ExtraButtonsProperty, value);
        }

        public object Object
        {
            get => GetValue(ObjectProperty);
            set => SetValue(ObjectProperty, value);
        }

        public Action<object> ObjectChanged { get; set; }

        public Window OwnerWindow
        {
            get => (Window)GetValue(OwnerWindowProperty);
            set => SetValue(OwnerWindowProperty, value);
        }

        public bool ShowDeleteButton
        {
            get => DeleteButton.Visibility == Visibility.Visible;
            set => DeleteButton.Visibility = value ? Visibility.Visible : Visibility.Collapsed;
        }

        public bool ShowSetLabelButton
        {
            get => LabelButton.Visibility == Visibility.Visible;
            set => LabelButton.Visibility = value ? Visibility.Visible : Visibility.Collapsed;
        }

        public string TypeRegistryCategory
        {
            get => (string)GetValue(TypeRegistryCategoryProperty);
            set => SetValue(TypeRegistryCategoryProperty, value);
        }

        private void ChangeObjectButton_Click(object sender, RoutedEventArgs e)
        {
            if (InlineEditor.HasEditor())
            {
                InlineEditor.IsEditorOpen = !InlineEditor.IsEditorOpen;
                return;
            }

            OpenReplaceWindow();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e) => DeleteButtonClicked?.Invoke(this);

        private void InlineEditor_ReplaceButtonClicked() => OpenReplaceWindow();

        private void LabelButton_Click(object sender, RoutedEventArgs e)
        {
            var settableObject = (IHasSettableLabel)Object;

            var input = FancyInputBox.Show("EnterLabelForObject", settableObject.SettableLabel);
            if (input == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(input))
            {
                settableObject.SettableLabel = null;
            }
            else
            {
                settableObject.SettableLabel = input;
            }
        }

        private void OpenReplaceWindow()
        {
            var window = new ObjectTypeSelectorWindow(TypeRegistryCategory)
            {
                Owner = Window.GetWindow(this)
            };
            window.ObjectChangedCallback += (obj) =>
            {
                Object = obj;
                InlineEditor.OpenEditorIfItExists();
            };
            window.ShowDialog();
        }
    }
}