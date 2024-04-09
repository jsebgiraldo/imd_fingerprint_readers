using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;

namespace Imaging
{
  /// <summary>
  /// Class encapsulating image analyzers through histograms.
  /// </summary>
  public static class HistogramAnalyzer
  {
    #region Public Methods

    /// <summary>
    /// Calculates the histogram of a given image.
    /// </summary>
    /// <param name="image">The image.</param>
    /// <returns>The histogram.</returns>
    public static int[] CalculateHistogram(Bitmap image)
    {
      if (image == null)
        return new int[0];

      lock (image)
      {
        Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);

        BitmapData bmpData = image.LockBits(rect, ImageLockMode.ReadOnly, image.PixelFormat);

        int[] histogram = CalculateHistogram(bmpData, rect);

        image.UnlockBits(bmpData);

        return histogram;
      }
    }

    /// <summary>
    /// Calculates the histogram of a given image area of an image.
    /// </summary>
    /// <param name="bmpData">The BMP data.</param>
    /// <param name="rectangle">The rectangle.</param>
    /// <returns>The histogram</returns>
    public static int[] CalculateHistogram(BitmapData bmpData, Rectangle rectangle)
    {
      if (bmpData == null)
        throw new ArgumentNullException("bmpData");

      int[] histogram = new int[256];

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
        for (int i = rectangle.Y; i < rectangle.Height + rectangle.Y; ++i)
        {
          byte* row = (byte*)bmpData.Scan0.ToPointer() + (i * bmpData.Stride);

          for (int j = rectangle.X; j < rectangle.Width + rectangle.X; j++)
            histogram[row[j * bpp]]++;
        }
      }

      return histogram;
    }

    /// <summary>
    /// Adjusts the histogram for analysis.
    /// </summary>
    /// <param name="originalHistogram">The original histogram.</param>
    /// <param name="offset">The output offset of positions removed at the beginning.</param>
    /// <returns>The adjusted histogram for analysis.</returns>
    public static int[] AdjustHistogram(int[] originalHistogram, out int offset)
    {
      if (originalHistogram == null)
        throw new ArgumentNullException("originalHistogram");

      int nullLeftValues = 0;
      int nullRightValues = 0;
      int average = CalculateAverage(originalHistogram, true);

      for (int i = 0; i < originalHistogram.Length; i++)
      {
        if (originalHistogram[i] <= 10)
          nullLeftValues++;
        else if (originalHistogram[i] >= average)
          break;
      }

      for (int i = originalHistogram.Length - 1; i >= 0; i--)
      {
        if (originalHistogram[i] <= 10)
          nullRightValues++;
        else if (originalHistogram[i] >= average)
          break;
      }

      if (nullLeftValues + nullRightValues > 256)
      {
        offset = 0;
        return originalHistogram;
      }

      int[] ret = new int[originalHistogram.Length - nullLeftValues - nullRightValues];

      for (int i = 0; i < ret.Length; i++)
        ret[i] = originalHistogram[i + nullLeftValues];

      offset = nullLeftValues;
      return ret;
    }

    /// <summary>
    /// Verifies the levels of a given image.
    /// </summary>
    /// <param name="img">The image.</param>
    public static HistogramResult AnalyzeImage(Bitmap img)
    {
      int[] histogram = CalculateHistogram(img);
      return AnalyzeImage(histogram);
    }

    /// <summary>
    /// Verifies the levels of a given image.
    /// </summary>
    /// <param name="bmpData">The image.</param>
    /// <param name="rectangle">The rectangle.</param>
    public static HistogramResult AnalyzeImage(BitmapData bmpData, Rectangle rectangle)
    {
      int[] histogram = CalculateHistogram(bmpData, rectangle);
      return AnalyzeImage(histogram);
    }

    /// <summary>
    /// Verifies the levels of a given image.
    /// </summary>
    /// <param name="histogram">The histogram.</param>
    public static HistogramResult AnalyzeImage(int[] histogram)
    {
      int offset;
      int[] adjustedHistogram = AdjustHistogram(histogram, out offset);

      int blackValue = 0;
      int blackPosition = 0;

      int whiteValue = 0;
      int whitePosition = 0;

      for (int i = 0; i < adjustedHistogram.Length / 2; i++)
      {
        if (adjustedHistogram[i] > blackValue)
        {
          blackValue = adjustedHistogram[i];
          blackPosition = i;
        }

        if (adjustedHistogram[adjustedHistogram.Length - 1 - i] > whiteValue)
        {
          whiteValue = adjustedHistogram[adjustedHistogram.Length - 1 - i];
          whitePosition = adjustedHistogram.Length - 1 - i;
        }
      }

      return new HistogramResult(
          histogram,
          new KeyValuePair<int, int>(blackPosition + offset, blackValue),
          new KeyValuePair<int, int>(whitePosition + offset, whiteValue));
    }

    /// <summary>
    /// Paints the histogram.
    /// </summary>
    /// <param name="histogram">The histogram.</param>
    /// <param name="width">The image width.</param>
    /// <param name="height">The image height.</param>
    /// <returns>The image representing the histogram.</returns>
    public static Image DrawHistogram(int[] histogram, int width, int height)
    {
      int averageValue = CalculateAverage(histogram, true);
      int maxValue = averageValue * 3;

      Bitmap image = new Bitmap(width, height);

      Graphics gr = Graphics.FromImage(image);
      Pen pen = new Pen(Color.Black, 256f / (float)histogram.Length);

      gr.ScaleTransform((float)width / 260.0f, (float)height / 105.0f);

      for (int i = 0; i < histogram.Length; i++)
      {
        int currentValue = 105 - (int)(((double)histogram[i] / (double)maxValue) * 100);

        if (currentValue < 5)
          currentValue = 5;

        gr.DrawLine(pen, new Point((i * (int)((double)256 / (double)histogram.Length)) + 2, 105), new Point((i * (int)((double)256 / (double)histogram.Length)) + 2, currentValue));
      }

      gr.Dispose();

      return image;
    }

    /// <summary>
    /// Calculates the average.
    /// </summary>
    /// <param name="histogram">The histogram.</param>
    /// <param name="ignoreZeros">if set to <c>true</c> ignores the zero values.</param>
    /// <returns>The value average</returns>
    public static int CalculateAverage(int[] histogram, bool ignoreZeros)
    {
      if (histogram == null)
        throw new ArgumentNullException("histogram");

      int averageValue = 0;
      int itemsWithValueCount = 1;

      foreach (int item in histogram)
      {
        if (item > 0)
          averageValue += item;

        if (!ignoreZeros || (ignoreZeros && item > 0))
          itemsWithValueCount++;
      }

      averageValue = (int)((double)averageValue / (double)itemsWithValueCount);

      return averageValue;
    }

    /// <summary>
    /// Calculates the inner average.
    /// </summary>
    /// <param name="histogram">The histogram.</param>
    /// <param name="outerWhiteValue">The offset where the most left value in starts in the inner average.</param>
    /// <param name="ignoreZeros">if set to <c>true</c> ignores the zero values.</param>
    /// <returns>The inner value average.</returns>
    public static int CalculateInnerAverage(int[] histogram, out int outerWhiteValue, bool ignoreZeros)
    {
      if (histogram == null)
        throw new ArgumentNullException("histogram");

      int[] innerHistogram = new int[histogram.Length - 10];

      for (int i = 0; i < innerHistogram.Length; i++)
        innerHistogram[i] = histogram[i + 5];

      outerWhiteValue = innerHistogram[innerHistogram.Length - 1];

      return CalculateAverage(innerHistogram, ignoreZeros);
    }

    /// <summary>
    /// Calculates the inner average.
    /// </summary>
    /// <param name="histogram">The histogram.</param>
    /// <param name="ignoreZeros">if set to <c>true</c> ignores the zero values.</param>
    /// <returns>The inner value average.</returns>
    public static int CalculateInnerAverage(int[] histogram, bool ignoreZeros)
    {
      if (histogram == null)
        throw new ArgumentNullException("histogram");

      int[] innerHistogram = new int[histogram.Length - 10];

      for (int i = 0; i < innerHistogram.Length; i++)
        innerHistogram[i] = histogram[i + 5];

      return CalculateAverage(innerHistogram, ignoreZeros);
    }

    /// <summary>
    /// Calculates the amount of pixels in a given zone.
    /// </summary>
    /// <param name="histogram">The histogram.</param>
    /// <param name="position">The position.</param>
    /// <param name="size">The size.</param>
    /// <returns>The amount of black pixels the given zone of the histogram.</returns>
    public static int CalculatePixelsInZone(int[] histogram, int position, int size)
    {
      if (histogram == null)
        throw new ArgumentNullException("histogram");

      if (position < 0 || position >= histogram.Length)
        throw new ArgumentOutOfRangeException("position");

      if (size < 0 || position + size >= histogram.Length)
        throw new ArgumentOutOfRangeException("size");

      int result = 0;

      for (int i = position; i < position + size; i++)
        result += histogram[i];

      return result;
    }

    #endregion
  }
}
