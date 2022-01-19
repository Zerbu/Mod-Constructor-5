using System.Windows.Media.Imaging;

namespace Constructor5.UI.Dialogs.IconSelector
{
    public class ImageSelectorItem
    {
        public string InstanceKey { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public BitmapImage Source { get; set; }

        public string Value => $"2f7d0004:00000000:{this.InstanceKey} <<<{this.Name}";

        public static ImageSelectorItem CreateFromPath(string path)
        {
            var split = System.IO.Path.GetFileNameWithoutExtension(path).Split(' ');

            string name = null;
            string instanceKey;

            if (split.Length > 0)
            {
                name = split[0];
                instanceKey = split[1];
            }
            else
            {
                instanceKey = split[0];
            }

            return new ImageSelectorItem { Path = path, Name = name, InstanceKey = instanceKey };
        }
    }
}