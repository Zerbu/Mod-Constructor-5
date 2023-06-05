using System;
using System.Collections.Generic;
using System.IO;

namespace Constructor5.Base.ProjectSystem
{
    public static class DirectoryUtility
    {
        public static string[] GetCombinedUserAndProgramFiles(string dir)
        {
            var result = new List<string>();

            var programDir = GetProgramDirectory(dir);
            var userDir = GetUserDirectory(dir);

            if (Directory.Exists(programDir))
            {
                foreach (var file in Directory.GetFiles(programDir))
                {
                    result.Add(file);
                }
            }

            if (Directory.Exists(userDir))
            {
                foreach (var file in Directory.GetFiles(userDir))
                {
                    result.Add(file);
                }
            }

            return result.ToArray();
        }

        public static string GetProgramDirectory(string dir) => dir;

        public static string GetUserDirectory(string dir) => $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/The Sims 4 Mod Constructor/{dir}";

        public static string[] GetUserFiles(string dir)
        {
            var result = new List<string>();

            foreach (var file in Directory.GetFiles(GetUserDirectory(dir)))
            {
                result.Add(file);
            }

            return result.ToArray();
        }

        public static string GetUserOrProgramFile(string dir, string file)
        {
            if (File.Exists($"{GetUserDirectory(dir)}/{file}"))
            {
                return $"{GetUserDirectory(dir)}/{file}";
            }

            return $"{GetProgramDirectory(dir)}/{file}";
        }
    }
}