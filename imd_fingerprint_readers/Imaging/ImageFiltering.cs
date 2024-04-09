using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Imaging
{
  /// <summary>
  /// Contains all methods to apply filters to images.
  /// </summary>
  public static class ImageFiltering
  {
    #region Public Methods

    /// <summary>
    /// Applies the brightness, contrast and gain settings to an grayscale image.
    /// </summary>
    /// <param name="image">The grayscale image.</param>
    /// <param name="brightness">The image brightness.</param>
    /// <param name="contrast">The image contrast.</param>
    /// <param name="gain">The image gain.</param>
    public static void ApplyImageSettings(Bitmap image, int brightness, int contrast, int gain)
    {
      if (image == null || (brightness == 128 && contrast == 128 && gain == 128))
        return;

      if (image.PixelFormat != PixelFormat.Format8bppIndexed)
        throw new FormatException("Pixel format not supported");

      float scaledBrightness = (2.0f * brightness) - 255.0f;
      float scaledContrast = contrast / 128.0f;
      float scaledGain = gain / 128.0f;

      BitmapData bmpData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadWrite, image.PixelFormat);

      unsafe
      {
        for (int i = 0; i < image.Height; ++i)
        {
          byte* rowData = (byte*)bmpData.Scan0 + (i * bmpData.Stride);

          for (int j = 0; j < image.Width; ++j)
          {
            float value = scaledGain * rowData[j];                // gain
            value = ((value - 128.0f) * scaledContrast) + 128.0f; // contrast
            value = value + scaledBrightness;                     // brightness

            rowData[j] = Convert.ToByte(Math.Max(0.0f, Math.Min(255.0f, value)));
          }
        }
      }

      image.UnlockBits(bmpData);
    }

    /// <summary>
    /// Inverts the image colors (negative).
    /// </summary>
    /// <param name="image">The image.</param>
    public static void InvertImage(Bitmap image)
    {
      if (image == null)
        return;

      if (image.PixelFormat != PixelFormat.Format8bppIndexed)
        throw new FormatException("Pixel format not supported");

      BitmapData bmpData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadWrite, image.PixelFormat);

      unsafe
      {
        for (int i = 0; i < image.Height; ++i)
        {
          byte* rowData = (byte*)bmpData.Scan0 + (i * bmpData.Stride);

          for (int j = 0; j < image.Width; ++j)
            rowData[j] = (byte)(0xFF - rowData[j]);
        }
      }

      image.UnlockBits(bmpData);
    }

    /// <summary>
    /// Binarizes the image.
    /// </summary>
    /// <param name="bmpData">The bmp data.</param>
    /// <param name="threshold">The white threshold.</param>
    public static void BinarizeImage(BitmapData bmpData, int threshold)
    {
      if (bmpData == null)
        throw new ArgumentNullException("bmpData");

      int bpp = 0;

      switch (bmpData.PixelFormat)
      {
        case PixelFormat.Format8bppIndexed:
        case PixelFormat.Indexed:
          bpp = 1;
          break;
        case PixelFormat.Format32bppRgb:
        case PixelFormat.Format32bppArgb:
        case PixelFormat.Format32bppPArgb:
          bpp = 4;
          break;
        case PixelFormat.Format24bppRgb:
          bpp = 3;
          break;
        default:
          throw new FormatException("Pixel format not supported");
      }

      unsafe
      {
        byte* p = (byte*)(void*)bmpData.Scan0.ToPointer();
        int h = bmpData.Height;
        int w = bmpData.Width;
        int ws = bmpData.Stride;

        for (int i = 0; i < h; i++)
        {
          byte* row = &p[i * ws];
          for (int j = 0; j < w * bpp; j += bpp)
          {
            row[j] = (byte)((row[j] > (byte)threshold) ? 255 : 0);
            row[j + 1] = (byte)((row[j + 1] > (byte)threshold) ? 255 : 0);
            row[j + 2] = (byte)((row[j + 2] > (byte)threshold) ? 255 : 0);
          }
        }
      }
    }

    /// <summary>
    /// Applies the Otsu filter.
    /// </summary>
    /// <param name="bitmap">The bitmap image.</param>
    public static void ApplyOtsuFilter(Bitmap bitmap)
    {
      if (bitmap == null)
        throw new ArgumentNullException("bitmap");

      lock (bitmap)
      {
        BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
        int otsuThreshold = OtsuThresholding.CalculateOtsuThreshold(HistogramAnalyzer.CalculateHistogram(bmpData, new Rectangle(0, 0, bmpData.Width, bmpData.Height)));
        BinarizeImage(bmpData, otsuThreshold);
        bitmap.UnlockBits(bmpData);
      }
    }

    /// <summary>
    /// Applies the erosion filter.
    /// </summary>
    /// <param name="bitmap">The bitmap image.</param>
    /// <returns>The result image.</returns>
    public static unsafe Bitmap ApplyErosionFilter(Bitmap bitmap)
    {
      if (bitmap == null)
        throw new ArgumentNullException("bitmap");

      BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, bitmap.PixelFormat);
      Bitmap result = new Bitmap(bmpData.Width, bmpData.Height, bmpData.PixelFormat);

      if (bitmap.Palette.Entries.Length > 0)
        result.Palette = bitmap.Palette;

      int filter = 1;
      BitmapData resultData = result.LockBits(new Rectangle(0, 0, bmpData.Width, bmpData.Height), ImageLockMode.ReadWrite, bmpData.PixelFormat);

      for (int i = 0; i < bmpData.Height; ++i)
      {
        byte* data = (byte*)resultData.Scan0.ToPointer() + (i * resultData.Stride);

        for (int j = 0; j < bmpData.Width; ++j)
        {
          int value = 255;

          for (int ky = -filter; ky <= filter; ++ky)
          {
            int y = i + ky;
            byte* line = (byte*)bmpData.Scan0.ToPointer() + (y * bmpData.Stride);

            for (int kx = -filter; kx <= filter; ++kx)
            {
              int x = j + kx;

              if (y < 0 || y >= bmpData.Height || x < 0 || x >= bmpData.Width)
                continue;

              value = Math.Min(value, line[x]);
            }
          }

          data[j] = (byte)value;
        }
      }

      bitmap.UnlockBits(bmpData);
      result.UnlockBits(resultData);
      return result;
    }

    /// <summary>
    /// Applies the Denoise filter.
    /// </summary>
    /// <param name="bitmap">The bitmap image.</param>
    /// <returns>The result image.</returns>
    public static unsafe Bitmap ApplyDenoiseFilter(Bitmap bitmap)
    {
      if (bitmap == null)
        throw new ArgumentNullException("bitmap");

      BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, bitmap.PixelFormat);
      Bitmap result = new Bitmap(bmpData.Width, bmpData.Height, bmpData.PixelFormat);

      if (bitmap.Palette.Entries.Length > 0)
        result.Palette = bitmap.Palette;

      BitmapData resultData = result.LockBits(new Rectangle(0, 0, bmpData.Width, bmpData.Height), ImageLockMode.ReadWrite, bmpData.PixelFormat);
      float[,] kernel = new float[,] { { 1.0f / 8, 1.0f / 8, 1.0f / 8 }, { 1.0f / 8, 0.0f, 1.0f / 8 }, { 1.0f / 8, 1.0f / 8, 1.0f / 8 } };

      for (int i = 0; i < bmpData.Height; ++i)
      {
        byte* data = (byte*)resultData.Scan0.ToPointer() + (i * resultData.Stride);

        for (int j = 0; j < bmpData.Width; ++j)
        {
          double value = 0.0;

          for (int ky = -1; ky <= 1; ++ky)
          {
            int y = i + ky;
            byte* line = (byte*)bmpData.Scan0.ToPointer() + (y * bmpData.Stride);

            for (int kx = -1; kx <= 1; ++kx)
            {
              int x = j + kx;

              if (y < 0 || y >= bmpData.Height || x < 0 || x >= bmpData.Width)
              {
                value += 255 * kernel[1 + ky, 1 + kx];
                continue;
              }

              value += kernel[1 + ky, 1 + kx] * line[x];
            }
          }

          data[j] = (byte)value;
        }
      }

      bitmap.UnlockBits(bmpData);
      result.UnlockBits(resultData);
      return result;
    }

    #endregion
  }
}
