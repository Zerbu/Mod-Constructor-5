using Constructor5.Base.Properties;
using System;

namespace Constructor5.Base
{
    public static class ProgramSettings
    {
        public static string CreatorName
        {
            get => Settings.Default.CreatorName;
            set => Settings.Default.CreatorName = value;
        }

        public static string GetTS4Exe() => $"{Settings.Default.TS4Folder}/Game/Bin/TS4_x64.exe";

        public static bool ShowAllSettingEnabled
        {
            get => Settings.Default.ShowAllSettingEnabled;
            set => Settings.Default.ShowAllSettingEnabled = value;
        }

        public static string TS4Folder
        {
            get => Settings.Default.TS4Folder;
            set => Settings.Default.TS4Folder = value;
        }

        public static void Save() => Settings.Default.Save();
    }
}