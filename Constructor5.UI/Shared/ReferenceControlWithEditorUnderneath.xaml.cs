using Constructor5.Base.ElementSystem;
using Constructor5.Core;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Constructor5.UI.Shared
{
    /// <summary>
    /// Interaction logic for ReferenceControlWithEditorUnderneath.xaml
    /// </summary>
    public partial class ReferenceControlWithEditorUnderneath : UserControl
    {
        public static readonly DependencyProperty EditorCategoryProperty =
            DependencyProperty.Register("EditorCategory", typeof(string), typeof(ReferenceControlWithEditorUnderneath), new PropertyMetadata("ElementMini"));

        public static readonly DependencyProperty EditorTagProperty =
            DependencyProperty.Register("EditorTag", typeof(string), typeof(ReferenceControlWithEditorUnderneath), new PropertyMetadata(null));

        public static readonly DependencyProperty ElementTypeProperty =
                            DependencyProperty.Register("ElementType", typeof(Type), typeof(ReferenceControlWithEditorUnderneath), new PropertyMetadata(null));

        public static readonly DependencyProperty ReferenceProperty =
            DependencyProperty.Register("Reference", typeof(Reference), typeof(ReferenceControlWithEditorUnderneath), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public static readonly DependencyProperty ShowBrowseButtonProperty =
            DependencyProperty.Register("ShowBrowseButton", typeof(bool), typeof(ReferenceControlWithEditorUnderneath), new PropertyMetadata(true));

        public static readonly DependencyProperty ShowCreateButtonProperty =
            DependencyProperty.Register("ShowCreateButton", typeof(bool), typeof(ReferenceControlWithEditorUnderneath), new PropertyMetadata(true));

        public static readonly DependencyProperty ShowResetButtonProperty =
            DependencyProperty.Register("ShowResetButton", typeof(bool), typeof(ReferenceControlWithEditorUnderneath), new PropertyMetadata(true));

        public ReferenceControlWithEditorUnderneath() => InitializeComponent();

        public Func<Element> CreateElementFunction { get; set; }

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

        public Reference Reference
        {
            get => (Reference)GetValue(ReferenceProperty);
            set => SetValue(ReferenceProperty, value);
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

        private Element ReferenceControl_CreateElementFunction() => CreateElementFunction?.Invoke();
    }
}