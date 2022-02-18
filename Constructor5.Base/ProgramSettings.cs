using Constructor5.Base.Properties;

namespace Constructor5.Base
{
    public static class ProgramSettings
    {
        public static string CreatorName
        {
            get => Settings.Default.CreatorName;
            set => Settings.Default.CreatorName = value;
        }

        public static bool ShowAllSettingEnabled
        {
            get => Settings.Default.ShowAllSettingEnabled;
            set => Settings.Default.ShowAllSettingEnabled = value;
        }

        public static void Save() => Settings.Default.Save();
    }
}