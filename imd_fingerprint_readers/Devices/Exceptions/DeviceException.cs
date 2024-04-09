using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace Devices.Exceptions
{
    /// <summary>
    /// Device exception class.
    /// </summary>
    [Serializable]
    public class DeviceException : ApplicationException
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceException" /> class.
        /// </summary>
        public DeviceException()
          : base("")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceException" /> class.
        /// </summary>
        /// <param name="message">The error message.</param>
        public DeviceException(string message)
          : this(message, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceException" /> class.
        /// </summary>
        /// <param name="inner">The inner exception.</param>
        public DeviceException(Exception inner)
          : base("", inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceException" /> class.
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <param name="inner">The inner exception.</param>
        public DeviceException(string message, Exception inner)
          : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceException"/> class.
        /// </summary>
        /// <param name="info">The serialization information.</param>
        /// <param name="context">The streaming context.</param>
        protected DeviceException(SerializationInfo info, StreamingContext context)
          : base(info, context)
        {
            if (info == null)
                throw new ArgumentNullException("info");
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates and returns a string representation of the current exception.
        /// </summary>
        /// <returns>A string representation of the current exception.</returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0} \n{2}", GetType().Name, base.ToString());
        }

        #endregion
    }
}
