using Constructor5.Base.Icons;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Constructor5.UI.Dialogs.IconSelector
{
    /// <summary>
    /// Interaction logic for GameImageSelector.xaml
    /// </summary>
    public partial class GameImageSelector : UserControl
    {
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(ElementIcon), typeof(GameImageSelector),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public GameImageSelector()
        {
            InitializeComponent();
            var items = Directory.GetDirectories("Icons").Select(Path.GetFileNameWithoutExtension).ToList();
            DirectoriesListView.ItemsSource = items;
        }

        public event Action<ElementIcon> ImageSelected;

        public event Action<ImageSelectorItem> ListViewItemChanged;

        private ICollectionView CurrentView { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e) => RefreshImages();

        private void DirectoriesListView_SelectionChanged(object sender, SelectionChangedEventArgs e) => RefreshImages();

        private void ImagesListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
            => ListViewItemChanged.Invoke((ImageSelectorItem)ImagesListView.SelectedItem);

        private void RefreshImages()
        {
            var images = Directory.GetFiles(Path.Combine("Icons", (string)DirectoriesListView.SelectedItem), "*.png").Select(ImageSelectorItem.CreateFromPath).ToList();
            CurrentView = CollectionViewSource.GetDefaultView(images);

            CurrentView.Filter += (obj) =>
            {
                var image = (ImageSelectorItem)obj;

                return string.IsNullOrEmpty(SearchBox.Text)
                || image.Name.ToLower().Contains(SearchBox.Text)
                || image.Path.ToLower().Contains(SearchBox.Text);
            };

            ImagesListView.ItemsSource = CurrentView;
        }

        private void SelectImageButton_Click(object sender, RoutedEventArgs e)
        {
            var item = (ImageSelectorItem)ImagesListView.SelectedItem;
            ImageSelected.Invoke(new ElementIcon(item.Path, item.Value));
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e) => RefreshImages();
    }
}