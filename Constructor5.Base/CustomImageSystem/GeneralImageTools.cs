using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Constructor5.Base.CustomImageSystem
{
    public static class GeneralImageTools
    {
        public static Bitmap FillHue(Bitmap bmp, int hueFill, bool removeSaturation, float newSaturationAmount = 0)
        {
            var width = bmp.Width;
            var height = bmp.Height;
            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    var c = bmp.GetPixel(x, y);
                    var newHue = c.GetHue();
                    var newSaturation = c.GetSaturation();
                    if (hueFill != -1)
                    {
                        newHue = hueFill;
                    }

                    if (removeSaturation)
                    {
                        if (newSaturation > newSaturationAmount)
                        {
                            newSaturation = newSaturationAmount;
                        }
                    }

                    var newValue = FromAhsb(c.A, newHue, newSaturation, c.GetBrightness());
                    bmp.SetPixel(x, y, newValue);
                }
            }

            return bmp;
        }

        public static Color FromAhsb(int alpha, float hue, float saturation, float brightness)
        {
            if (alpha < 0 || alpha > 255)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(alpha),
                    alpha,
                    @"Value must be within a range of 0 - 255.");
            }

            if (hue < 0f || hue > 360f)
            {
                throw new ArgumentOutOfRangeException(nameof(hue), hue, @"Value must be within a range of 0 - 360.");
            }

            if (saturation < 0f || saturation > 1f)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(saturation),
                    saturation,
                    @"Value must be within a range of 0 - 1.");
            }

            if (brightness < 0f || brightness > 1f)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(brightness),
                    brightness,
                    @"Value must be within a range of 0 - 1.");
            }

            if (Math.Abs(saturation) < 0)
            {
                return Color.FromArgb(
                    alpha,
                    Convert.ToInt32(brightness * 255),
                    Convert.ToInt32(brightness * 255),
                    Convert.ToInt32(brightness * 255));
            }

            float floatMax, floatMid, floatMin;
            if (brightness > 0.5)
            {
                // ReSharper disable once StyleCop.SA1407
                floatMax = brightness - brightness * saturation + saturation;

                // ReSharper disable once StyleCop.SA1407
                floatMin = brightness + brightness * saturation - saturation;
            }
            else
            {
                // ReSharper disable once StyleCop.SA1407
                floatMax = brightness + brightness * saturation;

                // ReSharper disable once StyleCop.SA1407
                floatMin = brightness - brightness * saturation;
            }

            var intSextant = (int)Math.Floor(hue / 60f);
            if (hue > 300f)
            {
                hue -= 360f;
            }

            hue /= 60f;

            // ReSharper disable once StyleCop.SA1407
            hue -= 2f * (float)Math.Floor((intSextant + 1f) % 6f / 2f);

            // ReSharper disable once StyleCop.SA1131
            if (0 == intSextant % 2)
            {
                // ReSharper disable once StyleCop.SA1407
                floatMid = hue * (floatMax - floatMin) + floatMin;
            }
            else
            {
                // ReSharper disable once StyleCop.SA1407
                floatMid = floatMin - hue * (floatMax - floatMin);
            }

            var maxInt = Convert.ToInt32(floatMax * 255);
            var midInt = Convert.ToInt32(floatMid * 255);
            var minInt = Convert.ToInt32(floatMin * 255);

            switch (intSextant)
            {
                case 1: return Color.FromArgb(alpha, midInt, maxInt, minInt);
                case 2: return Color.FromArgb(alpha, minInt, maxInt, midInt);
                case 3: return Color.FromArgb(alpha, minInt, midInt, maxInt);
                case 4: return Color.FromArgb(alpha, midInt, minInt, maxInt);
                case 5: return Color.FromArgb(alpha, maxInt, minInt, midInt);
                default: return Color.FromArgb(alpha, maxInt, midInt, minInt);
            }
        }

        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
    }
}