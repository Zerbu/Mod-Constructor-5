using Constructor5.Base.ElementSystem;
using Constructor5.Core;
using Constructor5.Xml;
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
            var result = new List<ProjectInfo>();
            Directory.CreateDirectory("Projects");
            foreach (var dir in Directory.GetDirectories("Projects"))
            {
                result.Add(XmlLoader.LoadFile<ProjectInfo>($"{dir}/Info.xml"));
            }
            return result.ToArray();
        }

        public static void LoadProject(ProjectInfo info)
        {
            Project.Id = info.Id;
            ElementSaver.LoadAll();
            Hooks.Location<IOnProjectCreatedOrLoaded>(x => x.OnProjectCreatedOrLoaded());
        }
    }
}
