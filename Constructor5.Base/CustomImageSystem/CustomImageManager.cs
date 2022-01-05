using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ProjectSystem;
using System.IO;

namespace Constructor5.Base.CustomImageSystem
{
    public static class CustomImageManager
    {
        public static string CustomImagesDirectory { get; } = "CustomImages";

        public static void DeleteImage(string path, string instanceKey)
        {
            var ddsPath = GetDdsPath(instanceKey);

            if (File.Exists(ddsPath))
            {
                File.Delete(ddsPath);
            }

            File.Delete(path);
        }

        public static string ImportImage(string path, ImageEffect effect)
        {
            if (effect == null)
            {
                effect = new ImageEffect();
            }

            var importFileName = $"{Path.GetFileNameWithoutExtension(path)?.Replace(" ", "_")}{effect.FileSuffix}";

            var instanceKey = FNVHasher.FNV64($"{Project.Id}:CustomImages/{importFileName}", true).ToString("X");

            var newPath = $"{Project.GetDirectory(CustomImagesDirectory)}/{importFileName} {instanceKey.ToLower()}.png";

            if (File.Exists(newPath))
            {
                return null;
            }

            effect.Apply(path).Save(newPath);

            DDSHelper.ToDds(newPath, GetDdsPath(instanceKey));

            return newPath;
        }

        private static string GetDdsPath(string instanceKey)
            => $"{Project.GetDirectory("Imports")}/00B2D882!0!{instanceKey}.dds";
    }
}