using Microsoft.Win32;
using System.IO;

namespace Constructor5.Base.Python
{
    public static class PythonInstallationHelper
    {
        public static string GetPath() =>
            (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Python\PythonCore\3.7\InstallPath", "ExecutablePath", null)
            ?? (string)Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Python\PythonCore\3.7\InstallPath", "ExecutablePath", null);
    }
}
