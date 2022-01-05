using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Constructor5.Base.CustomImageSystem
{
    public class ImageEffect
    {
        public string FileSuffix { get; set; }
        public int HueFill { get; set; } = -1;
        public string Label { get; set; }
        public bool RemoveSaturation { get; set; }
        public int Size { get; set; }
        public float NewSaturationAmount { get; set; } = 0;

        public BitmapImage Apply(string path)
        {
            var bmp = new Bitmap(path);
            if (Size != 0)
            {
                bmp = GeneralImageTools.ResizeImage(bmp, Size, Size);
            }

            if (HueFill != -1 || RemoveSaturation)
            {
                bmp = GeneralImageTools.FillHue(bmp, HueFill, RemoveSaturation, NewSaturationAmount);
            }

            return bmp.ConvertToSource();
        }
    }
}
