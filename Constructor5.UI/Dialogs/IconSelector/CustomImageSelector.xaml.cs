using Constructor5.Base;
using Constructor5.Base.CustomImageSystem;
using Constructor5.Base.Icons;
using Constructor5.Base.ProjectSystem;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Constructor5.UI.Dialogs.IconSelector
{
    /// <summary>
    /// Interaction logic for CustomImageSelector.xaml
    /// </summary>
    public partial class CustomImageSelector : UserControl
    {
        public CustomImageSelector()
        {
            InitializeComponent();

            foreach (var effect in Effects)
            {
                EffectsComboBox.Items.Add(effect);
            }

            RefreshCustomImages();
        }

        public event Action<ElementIcon> ImageSelected;

        public void SetPath(string path) => ImportPathTextBox.Text = path;

        private ImageEffect[] Effects { get; } =
        {
                new ImageEffect { Label = "None" },
                new ImageEffect
                    {
                        Label = "Trait",
                        FileSuffix = "_Trait",
                        Size = 40
                    },
                new ImageEffect
                    {
                        Label = "Buff Positive",
                        FileSuffix = "_BuffPositive",
                        Size = 40,
                        HueFill = 190
                    },
                new ImageEffect
                    {
                        Label = "Buff Negative",
                        FileSuffix = "_BuffNegative",
                        Size = 40,
                        RemoveSaturation = true
                    },
                new ImageEffect
                    {
                        Label = "Aspiration",
                        FileSuffix = "_Aspiration",
                        Size = 64,
                        HueFill = 45
                    },
                new ImageEffect
                    {
                        Label = "Queue",
                        FileSuffix = "_Queue",
                        Size = 24,
                        RemoveSaturation = true
                    },
                new ImageEffect
                    {
                        Label = "Medal Bronze",
                        FileSuffix = "_MedalBronze",
                        Size = 40,
                        HueFill = 15
                    },
                new ImageEffect
                    {
                        Label = "Medal Silver",
                        FileSuffix = "_MedalSilver",
                        Size = 40,
                        RemoveSaturation = true
                    },
                new ImageEffect
                    {
                        Label = "Medal Gold",
                        FileSuffix = "_MedalGold",
                        Size = 40,
                        HueFill = 45
                    },
                new ImageEffect
                    {
                        Label = "Whim",
                        FileSuffix = "_Whim",
                        Size = 40,
                        HueFill = 150,
                        RemoveSaturation = true,
                        NewSaturationAmount = 0.2f
                    }
            };

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog { Filter = "PNG Files|*.png" };
            if (openFileDialog.ShowDialog() == true)
            {
                ImportPathTextBox.Text = openFileDialog.FileName;
            }
        }

        private void DeleteImageButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedImage = (ImageSelectorItem)CustomImagesListView.SelectedItem;

            CustomImageManager.DeleteImage(selectedImage.Path, selectedImage.InstanceKey);
            RefreshCustomImages();
        }

        private void ImportButton_Click(object sender, RoutedEventArgs e)
        {
            var newPath = CustomImageManager.ImportImage(ImportPathTextBox.Text, (ImageEffect)EffectsComboBox.SelectedItem);
            RefreshCustomImages();
        }

        private void RefreshCustomImages()
        {
            var customImages = new FastObservableCollection<ImageSelectorItem>();

            foreach (var image in Directory.GetFiles(Project.GetProjectDirectory("CustomImages"), "*.png"))
            {
                customImages.Add(ImageSelectorItem.CreateFromPath(image));
            }

            CustomImagesListView.ItemsSource = CollectionViewSource.GetDefaultView(customImages);
        }

        private void SelectImageButton_Click(object sender, RoutedEventArgs e)
        {
            var item = (ImageSelectorItem)CustomImagesListView.SelectedItem;
            ImageSelected.Invoke(new ElementIcon(item.Path, item.Value));
        }
    }
}