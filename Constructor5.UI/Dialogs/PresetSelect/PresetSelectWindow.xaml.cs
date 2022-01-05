using Constructor5.Base.CustomTuning;
using Constructor5.Base.ElementSystem;
using Constructor5.Core;
using Constructor5.Xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Constructor5.UI.Dialogs.PresetSelect
{
    public partial class PresetSelectWindow : Window
    {
        public PresetSelectWindow() => InitializeComponent();

        public PresetSelectWindow(ElementTypeData typeData, bool customOnly = false)
        {
            InitializeComponent();

            var types = new List<Type>();
            if (typeData.ElementTypes != null)
            {
                types.AddRange(typeData.ElementTypes);
            }
            types.Add(typeof(CustomTuningElement));
            Initialize(types, !customOnly ? typeData.PresetFolders : null);
        }

        public PresetSelectWindow(IEnumerable<Type> elementTypes, IEnumerable<string> presetFolders)
        {
            InitializeComponent();
            Initialize(elementTypes, presetFolders);
        }

        public event Action<Preset[]> PresetsSelectedCallback;

        public bool AllowMultiple
        {
            get => PresetsListView.SelectionMode == SelectionMode.Extended;
            set => PresetsListView.SelectionMode = value ? SelectionMode.Extended : SelectionMode.Single;
        }

        public string ExcludeTag { get; set; }

        private ICollectionView CurrentView { get; set; }

        private void GroupsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
            => UpdatePresets(null);

        private void Initialize(IEnumerable<Type> elementTypes, IEnumerable<string> presetFolders)
        {
            var groups = new List<PresetGroup>();

            if (elementTypes != null)
            {
                foreach (var elementType in elementTypes)
                {
                    var typeInfo = ContentRegistry.Get<ElementTypeData>("ElementTypes", elementType.Name);

                    if (typeInfo == null)
                    {
                        continue;
                    }

                    var group = new PresetGroup
                    {
                        Label = $"From Mod: {typeInfo.Label}",
                        IsCustom = true
                    };

                    foreach (var element in ElementManager.GetAll(true).Where(x => x.GetType() == elementType && x.ShowPreset))
                    {
                        group.Presets.Add(new Preset
                        {
                            Value = element.Label,
                            Label = element.UserFacingId,
                            CustomElement = element
                        });
                    }

                    groups.Add(group);
                }
            }

            if (presetFolders != null)
            {
                foreach (var folder in presetFolders)
                {
                    var dir = $"Presets/{folder}";
                    if (!Directory.Exists(dir))
                    {
                        continue;
                    }

                    foreach (var file in Directory.GetFiles(dir))
                    {
                        groups.Add(XmlLoader.LoadFile<PresetGroup>(file));
                    }
                }
            }

            var sortedGroups = groups.Where(x => x.Presets.Count > 0).OrderByDescending(x => x.IsCustom).ThenBy(x => x.Label).ToArray();
            GroupsListView.ItemsSource = sortedGroups;
            if (sortedGroups.Count() > 0)
            {
                GroupsListView.SelectedItem = sortedGroups[0];
            }
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
            => CurrentView.Refresh();

        private void SetReferenceButton_Click(object sender, RoutedEventArgs e)
        {
            var presets = new List<Preset>();

            if (AllowMultiple || string.IsNullOrEmpty(ManualInput.Text))
            {
                foreach (var item in PresetsListView.SelectedItems)
                {
                    presets.Add((Preset)item);
                }
            }

            if (!string.IsNullOrEmpty(ManualInput.Text))
            {
                presets.Add(new Preset
                {
                    Value = ManualInput.Text,
                    Label = "Manual Input"
                });
            }

            PresetsSelectedCallback.Invoke(presets.ToArray());

            Close();
        }

        private void SortByLabelButton_Click(object sender, RoutedEventArgs e) => UpdatePresets("Label");

        private void SortByValueButton_Click(object sender, RoutedEventArgs e) => UpdatePresets("Value");

        private void UpdatePresets(string sortProperty)
        {
            CurrentView = CollectionViewSource.GetDefaultView(((PresetGroup)GroupsListView.SelectedItem).Presets);
            CurrentView.Filter += (obj) =>
            {
                var preset = (Preset)obj;

                return (string.IsNullOrEmpty(SearchBox.Text)
                || preset.Label.ToLower().Contains(SearchBox.Text)
                || preset.Value.ToLower().Contains(SearchBox.Text))
                && (string.IsNullOrEmpty(ExcludeTag) || preset.TagsString == null || !preset.TagsString.Contains(ExcludeTag));
            };
            PresetsListView.ItemsSource = CurrentView;
            if (sortProperty != null)
            {
                CurrentView.SortDescriptions.Clear();
                CurrentView.SortDescriptions.Add(new SortDescription(sortProperty, ListSortDirection.Ascending));
            }
        }
    }
}