using System;

namespace Utils
{
  /// <summary>
  /// Helps perform certain bitwise operations.
  /// </summary>
  public static class BitwiseHelper
  {
    /// <summary>
    /// Gets the number enabled bits in a bit count
    /// </summary>
    /// <param name="mask">The unit number.</param>
    /// <returns>The number of enabled bits.</returns>
    public static uint GetBitCount(uint mask)
    {
      // Fast bits sets count.
      mask = mask - ((mask >> 1) & 0x55555555);
      mask = (mask & 0x33333333) + ((mask >> 2) & 0x33333333);

      return (uint)(((mask + (mask >> 4) & 0xF0F0F0F) * 0x1010101) >> 24);
    }

    /// <summary>
    /// Sets the bit in a bits mask.
    /// </summary>
    /// <param name="mask">The bit mask.</param>
    /// <param name="position">The bit position.</param>
    /// <param name="on">if set to <c>true</c> the bit is set to 1; otherwise it is set to 0.</param>
    /// <returns>The mask with the bit set.</returns>
    public static uint SetBit(uint mask, int position, bool on)
    {
      bool isSet = IsBitSet(mask, position - 1);

      if (on && !isSet || !on && isSet)
        mask ^= (uint)(1 << (position - 1));

      return mask;
    }

    /// <summary>
    /// Determines whether a bit is set to 1 in a bits mask.
    /// </summary>
    /// <param name="mask">The bit mask.</param>
    /// <param name="position">The bit position.</param>
    /// <returns><c>true</c> if the bit is set to 1; otherwise, <c>false</c>.</returns>
    public static bool IsBitSet(uint mask, int position)
    {
      return (mask & (1 << position)) != 0;
    }

    /// <summary>
    /// Determines whether a bit is set to 1 in a bits mask.
    /// </summary>
    /// <param name="mask">The enum.</param>
    /// <param name="position">The bit position.</param>
    /// <returns><c>true</c> if the bit is set to 1; otherwise, <c>false</c>.</returns>
    public static bool IsBitSet(Enum mask, int position)
    {
      if (position <= 0)
        return false;

      return IsBitSet((uint)Convert.ToInt32(mask), position - 1);
    }
  }
}
