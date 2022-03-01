using Constructor5.Base.ElementSystem;
using Constructor5.Core;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Constructor5.Base.ProjectSystem
{
    public static class ProjectManager
    {
        public static ProjectInfo Create(string creatorName, string name)
        {
            var regex = new Regex("[^a-zA-Z0-9-]");

            var creatorNameToUseInId = regex.Replace(creatorName, "");
            var nameToUseInId = regex.Replace(name, "");

            if (string.IsNullOrEmpty(creatorNameToUseInId))
            {
                Hooks.Location<IOnProjectCreateError>(x => x.OnProjectCreateError(ProjectCreateErrorType.InvalidCreatorName));
                return null;
            }

            if (string.IsNullOrEmpty(nameToUseInId))
            {
                Hooks.Location<IOnProjectCreateError>(x => x.OnProjectCreateError(ProjectCreateErrorType.InvalidName));
                return null;
            }

            var idToUse = $"{creatorNameToUseInId}_{nameToUseInId}";

            var filePath = $"{GetDirectory(idToUse)}/Info.xml";

            if (File.Exists(filePath))
            {
                Hooks.Location<IOnProjectCreateError>(x => x.OnProjectCreateError(ProjectCreateErrorType.FileAlreadyExists));
                return null;
            }

            var result = new ProjectInfo
            {
                CreatorName = creatorName,
                Name = name,
                Id = idToUse
            };

            XmlSaver.SaveFile(result, filePath);

            LoadProject(result);

            return result;
        }

        public static string GetDirectory(string id) => $"Projects/{id}";

        public static ProjectInfo[] LoadInfo()
        {
            void CopyFilesRecursively(string sourcePath, string targetPath)
            {
                //Now Create all of the directories
                foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
                {
                    Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));
                }

                // Copy all the files & Replaces any files with the same name
                // modified to not replace existing files
                foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
                {
                    var destPath = newPath.Replace(sourcePath, targetPath);
                    if (!File.Exists(destPath))
                    {
                        File.Copy(newPath, destPath, true);
                    }
                }
            }

            var projectDirectory = DirectoryUtility.GetUserDirectory("Projects");

            // move mods that use the old save system
            if (Directory.Exists("Projects"))
            {
                // for some reason, Directory.Move doesn't work properly
                CopyFilesRecursively("Projects", projectDirectory);
                Directory.Delete("Projects", true);
            }

            var result = new List<ProjectInfo>();
            Directory.CreateDirectory(projectDirectory);
            foreach (var dir in Directory.GetDirectories(projectDirectory))
            {
                result.Add(XmlLoader.LoadFile<ProjectInfo>($"{dir}/Info.xml"));
            }
            return result.ToArray();
        }

        public static void LoadProject(ProjectInfo info)
            => LoadProject(info.Id);

        public static void LoadProject(string id)
        {
            Project.Id = id;
            ElementSaver.LoadAll();
            Hooks.Location<IOnProjectCreatedOrLoaded>(x => x.OnProjectCreatedOrLoaded());
        }
    }
}
