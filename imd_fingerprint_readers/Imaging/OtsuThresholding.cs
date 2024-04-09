using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Imaging
{
  /// <summary>
  /// Class that implements the Otsu method to automatically perform histogram shape-based image thresholding.
  /// </summary>
  public static class OtsuThresholding
  {
    #region Public Methods

    /// <summary>Computes the Otsu threshold from an histogram.</summary>
    /// <param name="histogram">The histogram.</param>
    /// <returns>The Otsu threshold.</returns>
    public static int CalculateOtsuThreshold(int[] histogram)
    {
      byte t = 0;
      float[] vet = new float[256];

      vet.Initialize();

      float p1, p2, p12;
      int k;

      for (k = 1; k != 255; k++)
      {
        p1 = Px(0, k, histogram);
        p2 = Px(k + 1, 255, histogram);
        p12 = p1 * p2;

        if (p12 == 0)
          p12 = 1;

        float diff = (Mx(0, k, histogram) * p2) - (Mx(k + 1, 255, histogram) * p1);

        vet[k] = (float)diff * diff / p12;
      }

      t = (byte)FindMax(vet, 256);

      return t;
    }

    #endregion

    #region Private Methods

    /// <summary>Function is used to compute the q values in the equation</summary>
    /// <param name="init">The init.</param>
    /// <param name="end">The end.</param>
    /// <param name="hist">The hist.</param>
    /// <returns>The q value.</returns>
    private static float Px(int init, int end, int[] hist)
    {
      int sum = 0;
      int i;
      for (i = init; i <= end; i++)
        sum += hist[i];

      return (float)sum;
    }

    /// <summary> Function is used to compute the mean values in the equation (mu)</summary>
    /// <param name="init">The init.</param>
    /// <param name="end">The end.</param>
    /// <param name="hist">The hist.</param>
    /// <returns>The mean.</returns>
    private static float Mx(int init, int end, int[] hist)
    {
      int sum = 0;
      int i;
      for (i = init; i <= end; i++)
        sum += i * hist[i];

      return (float)sum;
    }

    /// <summary> Finds the maximum element in a vector</summary>
    /// <param name="vec">The vec.</param>
    /// <param name="n">The n.</param>
    /// <returns>The maximum element.</returns>
    private static int FindMax(float[] vec, int n)
    {
      float maxVec = 0;
      int idx = 0;
      int i;

      for (i = 1; i < n - 1; i++)
      {
        if (vec[i] > maxVec)
        {
          maxVec = vec[i];
          idx = i;
        }
      }

      return idx;
    }

    #endregion
  }
}
