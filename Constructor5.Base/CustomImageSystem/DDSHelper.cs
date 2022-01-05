using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Constructor5.Base.CustomImageSystem
{
    public static class DDSHelper
    {
        public static void ToDds(string path, string saveTo)
        {
            var ddsPanel = new DDSPanel();
            using (var fileStream = File.OpenRead(path))
            {
                var memoryStream = new MemoryStream();
                fileStream.CopyTo(memoryStream);

                var bmp = new Bitmap(memoryStream);
                ddsPanel.DDSLoad(bmp, true);
                SaveDds(ddsPanel, saveTo);
                ddsPanel.Dispose();
                memoryStream.Close();
            }
        }

        public static void ToDds(Bitmap bmp, string saveTo)
        {
            var ddsPanel = new DDSPanel();
            ddsPanel.DDSLoad(bmp, true);
            SaveDds(ddsPanel, saveTo);
            ddsPanel.Dispose();
        }

        private static bool SaveDds(DDSPanel ddsPanel, string saveTo)
        {
            using (var fileStream = new FileStream(saveTo, FileMode.Create, FileAccess.Write))
            {
                ddsPanel.UseDXT = true;
                ddsPanel.DDSSave(fileStream);
            }

            return true;
        }
    }
}