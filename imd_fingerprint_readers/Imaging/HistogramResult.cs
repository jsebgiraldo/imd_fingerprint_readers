using System;
using System.Drawing;
using System.Collections.Generic;
using System.Globalization;

namespace Imaging
{
  /// <summary>
  /// Contains all the information generated after performing a Level Analysis of an image histogram.
  /// </summary>
  public class HistogramResult : ICloneable
  {
    #region Fields

    private int[] histogram;
    private KeyValuePair<int, int> darkPeak = new KeyValuePair<int, int>(0, 0);
    private KeyValuePair<int, int> brightPeak = new KeyValuePair<int, int>(255, 0);
    private byte brightness;
    private byte contrast;
    private byte gain;

    #endregion

    #region Constructor

    /// <summary>
    /// Initializes a new instance of the <see cref="HistogramResult"/> class.
    /// </summary>
    /// <param name="histogram">The histogram.</param>
    /// <param name="darkPeak">The dark peak.</param>
    /// <param name="brightPeak">The bright peak.</param>
    internal HistogramResult(int[] histogram, KeyValuePair<int, int> darkPeak, KeyValuePair<int, int> brightPeak)
    {
      this.histogram = histogram;
      this.darkPeak = darkPeak;
      this.brightPeak = brightPeak;
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets the histogram.
    /// </summary>
    /// <value>The histogram.</value>
    public int[] Histogram
    {
      get { return this.histogram; }
    }

    /// <summary>
    /// Gets the black peak &lt;Position, Value&gt; pair.
    /// </summary>
    /// <value>The black peak.</value>
    public KeyValuePair<int, int> DarkPeak
    {
      get { return this.darkPeak; }
    }

    /// <summary>
    /// Gets the white peak &lt;Position, Value&gt; pair.
    /// </summary>
    /// <value>The white peak.</value>
    public KeyValuePair<int, int> BrightPeak
    {
      get { return this.brightPeak; }
    }

    /// <summary>
    /// Gets the brightness.
    /// </summary>
    /// <value>The brightness.</value>
    public byte Brightness
    {
      get { return this.brightness; }
    }

    /// <summary>
    /// Gets the contrast.
    /// </summary>
    /// <value>The contrast.</value>
    public byte Contrast
    {
      get { return this.contrast; }
    }

    /// <summary>
    /// Gets the gain.
    /// </summary>
    /// <value>The gain.</value>
    public byte Gain
    {
      get { return this.gain; }
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Sets the Contrast, Brightness and Gain values.
    /// </summary>
    /// <param name="brightness">The brightness.</param>
    /// <param name="contrast">The contrast.</param>
    /// <param name="gain">The gain.</param>
    public void SetValues(byte brightness, byte contrast, byte gain)
    {
      this.brightness = brightness;
      this.contrast = contrast;
      this.gain = gain;
    }

    /// <summary>
    /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
    /// </returns>
    public override string ToString()
    {
      return string.Format(CultureInfo.InvariantCulture, "B: {0} , C: {1}, G: {2}", this.brightness, this.contrast, this.gain);
    }

    /// <summary>
    /// Creates a new object that is a copy of the current instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    public object Clone()
    {
      HistogramResult ret = new HistogramResult((int[])this.histogram.Clone(), this.darkPeak, this.brightPeak);
      ret.SetValues(this.brightness, this.contrast, this.gain);

      return ret;
    }

    #endregion
  }
}
