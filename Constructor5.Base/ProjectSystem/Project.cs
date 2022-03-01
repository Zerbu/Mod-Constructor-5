using System.IO;

namespace Constructor5.Base.ProjectSystem
{
    public static class Project
    {
        public static string Id { get; set; }

        public static string GetProjectDirectory() => Path.Combine(DirectoryUtility.GetUserDirectory("Projects"), Project.Id);

        public static string GetProjectDirectory(string dir)
        {
            var result = Path.Combine(GetProjectDirectory(), dir);
            Directory.CreateDirectory(result);
            return result;
        }
    }
}