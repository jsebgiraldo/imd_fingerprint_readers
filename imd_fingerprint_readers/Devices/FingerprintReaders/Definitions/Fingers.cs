﻿using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace imd_fingerprint_readers.Devices.FingerprintReaders.Definitions
{
    /// <summary>
    /// Fingers enumeration.
    /// </summary>
    [Flags]
    public enum Fingers : ushort
    {
        /// <summary>
        /// Unknown or No fingers.
        /// </summary>
        Unknown = 0x0,

        /// <summary>
        ///  Right thumb finger.
        /// </summary>
        RightThumb = 0x1,

        /// <summary>
        /// Right index finger.
        /// </summary>
        RightIndex = 0x2,

        /// <summary>
        /// Right middle finger.
        /// </summary>
        RightMiddle = 0x4,

        /// <summary>
        /// Right ring finger.
        /// </summary>
        RightRing = 0x8,

        /// <summary>
        /// Right little finger.
        /// </summary>
        RightLittle = 0x10,

        /// <summary>
        ///  Left thumb finger.
        /// </summary>
        LeftThumb = 0x20,

        /// <summary>
        /// Left index finger.
        /// </summary>
        LeftIndex = 0x40,

        /// <summary>
        /// Left middle finger.
        /// </summary>
        LeftMiddle = 0x80,

        /// <summary>
        /// Left ring finger.
        /// </summary>
        LeftRing = 0x100,

        /// <summary>
        /// Left little finger.
        /// </summary>
        LeftLittle = 0x200,

        /// <summary>
        /// Both index.
        /// </summary>
        BothIndex = RightIndex | LeftIndex,

        /// <summary>
        /// Right thumb and left thumb.
        /// </summary>
        BothThumbs = RightThumb | LeftThumb,

        /// <summary>
        /// Right hand index, middle, ring and little fingers.
        /// </summary>
        RightFour = RightIndex | RightMiddle | RightRing | RightLittle,

        /// <summary>
        /// Left hand index, middle, ring and little fingers.
        /// </summary>
        LeftFour = LeftIndex | LeftMiddle | LeftRing | LeftLittle,

        /// <summary>
        /// All right hand fingers.
        /// </summary>
        RightAll = RightThumb | RightFour,

        /// <summary>
        /// All left hand fingers.
        /// </summary>
        LeftAll = LeftThumb | LeftFour,

        /// <summary>
        /// All fingers.
        /// </summary>
        All = LeftAll | RightAll
    }
}
