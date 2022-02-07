using Constructor5.Base.ElementSystem;
using Constructor5.Core;
using Constructor5.UI.Dialogs;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;

namespace Constructor5.UI.Shared
{
    public partial class ReferenceListControl : UserControl
    {
        public static readonly DependencyProperty BrowseWarningProperty =
            DependencyProperty.Register("BrowseWarning", typeof(string), typeof(ReferenceListControl), new PropertyMetadata(null));

        public static readonly DependencyProperty EditorCategoryProperty =
                    DependencyProperty.Register("EditorCategory", typeof(string), typeof(ReferenceListControl), new PropertyMetadata("ElementMini"));

        public static readonly DependencyProperty EditorTagProperty =
            DependencyProperty.Register("EditorTag", typeof(string), typeof(ReferenceListControl), new PropertyMetadata(null));

        public static readonly DependencyProperty ElementReferenceListProperty =
            DependencyProperty.Register("ElementReferenceList", typeof(ReferenceList), typeof(ReferenceListControl),
                new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty ExcludeTagProperty =
            DependencyProperty.Register("ExcludeTag", typeof(string), typeof(ReferenceListControl), new PropertyMetadata(null));

        public static readonly DependencyProperty LimitProperty =
            DependencyProperty.Register("Limit", typeof(int), typeof(ReferenceListControl), new PropertyMetadata(null));

        public static readonly DependencyProperty ShowBrowseButtonProperty =
                    DependencyProperty.Register("ShowBrowseButton", typeof(bool), typeof(ReferenceListControl), new PropertyMetadata(true));

        public static readonly DependencyProperty ShowCreateButtonProperty =
            DependencyProperty.Register("ShowCreateButton", typeof(bool), typeof(ReferenceListControl), new PropertyMetadata(null));

        public ReferenceListControl()
        {
            InitializeComponent();
            Loaded += (e, args) =>
            {
                ((SimpleBrowsePresetsCommand)Resources["AddReferenceCommand"]).OwnerWindow = Window.GetWindow(this);
                ((SimpleBrowsePresetsCommand)Resources["AddReferenceCommand"]).ExcludeTag = ExcludeTag;
            };
        }

        public event Func<Element> CreateElementFunction;

        public string BrowseWarning
        {
            get => (string)GetValue(BrowseWarningProperty);
            set => SetValue(BrowseWarningProperty, value);
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

        public ReferenceList ElementReferenceList
        {
            get => (ReferenceList)GetValue(ElementReferenceListProperty);
            set => SetValue(ElementReferenceListProperty, value);
        }

        public Type ElementType
        {
            get => ((SimpleBrowsePresetsCommand)Resources["AddReferenceCommand"]).Type;
            set => ((SimpleBrowsePresetsCommand)Resources["AddReferenceCommand"]).Type = value;
        }

        public string ElementTypeName
        {
            get => ElementType.Name;
            set => ElementType = Reflection.GetTypeByName(value);
        }

        public string ExcludeTag
        {
            get => (string)GetValue(ExcludeTagProperty);
            set => SetValue(ExcludeTagProperty, value);
        }

        public string ItemTypeName { get; set; } = "ReferenceListItem";

        public int Limit
        {
            get => (int)GetValue(LimitProperty);
            set => SetValue(LimitProperty, value);
        }

        public Element SelectedModElement { get; set; }

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

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            if (Limit > 0 && ElementReferenceList.Items.Count >= Limit)
            {
                FancyMessageBox.Show($"For technical reasons, this list can only have up to {Limit} items.");
                return;
            }

            var element = (Element)null;

            element = CreateElementFunction?.Invoke();
            if (element == null)
            {
                element = ElementManager.Create(ElementType, null, true);
            }

            var item = CreateItem();
            item.Reference = new Reference(element);
            ElementReferenceList.Items.Add(item);
        }

        private ReferenceListItem CreateItem() => (ReferenceListItem)Reflection.CreateObject(Reflection.GetTypeByName(ItemTypeName));

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (!FancyMessageBox.ShowOKCancel($"Are you sure you want to remove the selected references?", true))
            {
                return;
            }

            var selectedItems = new ReferenceListItem[ReferencesListView.SelectedItems.Count];
            ReferencesListView.SelectedItems.CopyTo(selectedItems, 0);

            ElementReferenceList.Items.SuspendCollectionChangeNotification();
            foreach (var item in selectedItems)
            {
                ElementReferenceList.Items.Remove(item);
            }
            ElementReferenceList.Items.ResumeCollectionChangeNotification();
            ElementReferenceList.Items.NotifyChanges();
        }

        private void OpenElementButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = ReferencesListView.SelectedItem as ReferenceListItem;
            Hooks.Location<IOnCallOpenElement>(x => x.OnCallOpenElement(selectedItem.Reference.Element));
        }

        private void ReferencesListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ReferencesListView.SelectedItem == null)
            {
                ElementEditor.Object = null;
            }

            var selectedItem = ReferencesListView.SelectedItem as ReferenceListItem;
            ItemEditor.Object = selectedItem;
            ElementEditor.Object = selectedItem?.Reference.Element;
        }

        [SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "<Pending>")]
        private void SimpleBrowseElementsCommand_PresetsSelectedCallback(Preset[] presets)
        {
            foreach (var preset in presets)
            {
                var item = CreateItem();
                item.Reference = new Reference(preset);
                ElementReferenceList.Items.Add(item);
            }
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            if (BrowseWarning != null && !FancyMessageBox.ShowOKCancel(BrowseWarning))
            {
                return;
            }

            ((SimpleBrowsePresetsCommand)Resources["AddReferenceCommand"]).Execute(null);
        }
    }
}