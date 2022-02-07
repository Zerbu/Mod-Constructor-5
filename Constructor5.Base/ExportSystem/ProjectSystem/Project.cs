using Constructor5.Base.ElementSystem;
using System.Collections.ObjectModel;
using System.IO;

namespace Constructor5.Base.ProjectSystem
{
    public static class Project
    {
        public static string Id { get; set; }

        public static string GetDirectory() => ProjectManager.GetDirectory(Id);

        public static string GetDirectory(string subDir)
        {
            var dir = $"{GetDirectory()}/{subDir}";
            Directory.CreateDirectory(dir);
            return dir;
        }
    }
}