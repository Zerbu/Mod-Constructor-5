using Constructor5.Base.CustomTuning;
using Constructor5.Base.ElementSystem;
using Constructor5.Base.ProjectSystem;
using Constructor5.Core;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

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
            if (typeData.PresetFolders != null && typeData.PresetFolders.Length > 0)
            {
                ImportPresetFolder = typeData.PresetFolders[0];
                ImportTuningType = typeData.ImportTuningType;
            }

            if (ImportTuningType == null)
            {
                ImportPackage.Visibility = Visibility.Collapsed;
            }
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

        public string ImportPresetFolder { get; }
        public string ImportTuningType { get; }

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
                    foreach (var file in DirectoryUtility.GetCombinedUserAndProgramFiles($"Presets/{folder}"))
                    {
                        groups.Add(XmlLoader.LoadFile<PresetGroup>(file));
                    }
                }
            }

            Groups = groups;
            RefreshGroups();
        }

        private void RefreshGroups()
        {
            var sortedGroups = Groups.Where(x => x.Presets.Count > 0).OrderByDescending(x => x.IsCustom).ThenBy(x => x.Label).ToArray();
            GroupsListView.ItemsSource = sortedGroups;
            if (sortedGroups.Count() > 0)
            {
                GroupsListView.SelectedItem = sortedGroups[0];
            }
        }

        private List<PresetGroup> Groups { get; set; }

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
                if (!ManualInput.Text.Contains(" <<<"))
                {
                    presets.Add(new Preset
                    {
                        Value = ManualInput.Text
                    });
                }
                else
                {
                    var commentedText = ManualInput.Text.Split(new[] { " <<<" }, StringSplitOptions.None);
                    presets.Add(new Preset
                    {
                        Value = commentedText.Length > 0 ? commentedText[0] : ManualInput.Text,
                        Label = commentedText.Length > 0 ? commentedText[1] : null
                    });
                }
            }

            PresetsSelectedCallback.Invoke(presets.ToArray());

            if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
            {
                return;
            }
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

                if (preset == null)
                {
                    return true;
                }

                return (string.IsNullOrEmpty(SearchBox.Text)
                || preset.Label != null && preset.Label.ToLower().Contains(SearchBox.Text)
                || preset.Value != null && preset.Value.ToLower().Contains(SearchBox.Text))
                && (string.IsNullOrEmpty(ExcludeTag) || preset.TagsString == null || !preset.TagsString.Contains(ExcludeTag));
            };
            PresetsListView.ItemsSource = CurrentView;
            if (sortProperty != null)
            {
                CurrentView.SortDescriptions.Clear();
                CurrentView.SortDescriptions.Add(new SortDescription(sortProperty, ListSortDirection.Ascending));
            }
        }

        private void ImportPackage_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Package Files|*.package",
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == false)
            {
                return;
            }

            foreach(var fileName in openFileDialog.FileNames)
            {
                Groups.Add(PresetImporter.Import(fileName, ImportPresetFolder, ImportTuningType));
            }
            
            RefreshGroups();
        }
    }
}