using Constructor5.Base.ElementSystem;
using Constructor5.Core;
using Constructor5.UI.Dialogs;
using Constructor5.UI.Dialogs.ElementSettings;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Constructor5.UI.Shared
{
    /// <summary>
    /// Interaction logic for ElementReferenceControl.xaml
    /// </summary>
    public partial class ReferenceControl : UserControl
    {
        public static readonly DependencyProperty EditorCategoryProperty =
            DependencyProperty.Register("EditorCategory", typeof(string), typeof(ReferenceControl), new PropertyMetadata("ElementMini"));

        public static readonly DependencyProperty EditorTagProperty =
            DependencyProperty.Register("EditorTag", typeof(string), typeof(ReferenceControl), new PropertyMetadata(null));

        public static readonly DependencyProperty ElementTypeProperty =
                            DependencyProperty.Register("ElementType", typeof(Type), typeof(ReferenceControl),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
                {
                    PropertyChangedCallback = (dp, e) =>
                    {
                        var control = (ReferenceControl)dp;
                        ((SimpleBrowsePresetsCommand)control.Resources["BrowsePresetsCommand"]).Type = control.ElementType;
                    }
                });

        public static readonly DependencyProperty ReferenceProperty =
            DependencyProperty.Register("Reference", typeof(Reference), typeof(ReferenceControl),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
                {
                    PropertyChangedCallback = (dp, e) =>
                    {
                        var control = (ReferenceControl)dp;
                        control.InlineEditor.Object = control.Reference?.Element;
                        control.ReferenceChanged?.Invoke(control.Reference);
                    }
                });

        public static readonly DependencyProperty ResetToLabelProperty =
            DependencyProperty.Register("ResetToLabel", typeof(string), typeof(ReferenceControl), new PropertyMetadata(null));

        public static readonly DependencyProperty ResetToProperty =
            DependencyProperty.Register("ResetTo", typeof(ulong), typeof(ReferenceControl), new PropertyMetadata(null));

        public static readonly DependencyProperty ShowBrowseButtonProperty =
            DependencyProperty.Register("ShowBrowseButton", typeof(bool), typeof(ReferenceControl), new PropertyMetadata(true));

        public static readonly DependencyProperty ShowCreateButtonProperty =
            DependencyProperty.Register("ShowCreateButton", typeof(bool), typeof(ReferenceControl), new PropertyMetadata(false));

        public static readonly DependencyProperty ShowResetButtonProperty =
            DependencyProperty.Register("ShowResetButton", typeof(bool), typeof(ReferenceControl), new PropertyMetadata(true));

        public ReferenceControl()
        {
            InitializeComponent();
            Loaded += (e, args) =>
            {
                ((SimpleBrowsePresetsCommand)Resources["BrowsePresetsCommand"]).OwnerWindow = Window.GetWindow(this);
            };
        }

        public event Func<Element> CreateElementFunction;

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

        public Type ElementType
        {
            get => (Type)GetValue(ElementTypeProperty);
            set => SetValue(ElementTypeProperty, value);
        }

        public string ElementTypeName
        {
            get => ElementType.Name;
            set => ElementType = Reflection.GetTypeByName(value);
        }

        public string NewElementName
        {
            get => _newElementName;
            set
            {
                _newElementName = value;
                ShowCreateButton = true;
            }
        }

        public Reference Reference
        {
            get => (Reference)GetValue(ReferenceProperty);
            set => SetValue(ReferenceProperty, value);
        }

        public Action<Reference> ReferenceChanged { get; set; }

        public ulong ResetTo
        {
            get => (ulong)GetValue(ResetToProperty);
            set => SetValue(ResetToProperty, value);
        }

        public string ResetToLabel
        {
            get => (string)GetValue(ResetToLabelProperty);
            set => SetValue(ResetToLabelProperty, value);
        }

        public bool ShowBrowseButton
        {
            get => (bool)GetValue(ShowBrowseButtonProperty);
            set => SetValue(ShowBrowseButtonProperty, value);
        }

        public bool ShowCreateButton
        {
            get => (bool)GetValue(ShowCreateButtonProperty);
            set => SetValue(ShowCreateButtonProperty, value);
        }

        public bool ShowResetButton
        {
            get => (bool)GetValue(ShowResetButtonProperty);
            set => SetValue(ShowResetButtonProperty, value);
        }

        private string _newElementName;

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            if (InlineEditor.HasEditor())
            {
                InlineEditor.IsEditorOpen = !InlineEditor.IsEditorOpen;
                return;
            }

            ((ICommand)Resources["BrowsePresetsCommand"]).Execute(null);
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            var element = (Element)null;

            if (CreateElementFunction != null && CreateElementFunction.GetInvocationList().Length > 0)
            {
                element = CreateElementFunction.Invoke();
                if (element == null)
                {
                    element = ElementManager.Create(ElementType, NewElementName, true);
                }
            }
            else
            {
                element = ElementManager.Create(ElementType, NewElementName, true);
            }

            Reference = new Reference(element);

            if (InlineEditor.HasEditor())
            {
                InlineEditor.IsEditorOpen = true;
            }
        }

        private void ElementSettingsMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (Reference.Element == null)
            {
                return;
            }

            new ElementSettingsWindow(Reference.Element) { Owner = DialogUtility.GetOwner(this) }.ShowDialog();
        }

        [SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "<Pending>")]
        private void InlineEditor_ReplaceButtonClicked() => ((ICommand)Resources["BrowsePresetsCommand"]).Execute(null);

        private void OpenElementButton_Click(object sender, RoutedEventArgs e)
            => Hooks.Location<IOnCallOpenElement>(x => x.OnCallOpenElement(Reference.Element));

        private void OpenTabMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (Reference.Element == null)
            {
                return;
            }

            Hooks.Location<IOnCallOpenElement>(x => x.OnCallOpenElement(Reference.Element));
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            Reference = new Reference(ResetTo, ResetToLabel);
            InlineEditor.Object = null;
        }

        [SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "<Pending>")]
        private void SimpleBrowseElementsCommand_PresetsSelectedCallback(Preset[] presets)
        {
            Reference = new Reference(presets[0]);
            InlineEditor.Object = Reference.Element;
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            Hooks.Location<IOnCallOpenElement>(x => x.OnCallOpenElement(Reference.Element));
        }
    }
}