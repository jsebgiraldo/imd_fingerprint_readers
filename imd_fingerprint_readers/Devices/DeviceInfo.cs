using System;

namespace Devices
{
  /// <summary>
  /// Encapsulates a device details.
  /// </summary>
  public sealed class DeviceInfo
  {
    #region Fields

    private string deviceId;
    private string pnpDeviceId;
    private string description;

    #endregion

    #region Constructor

    /// <summary>
    /// Initializes a new instance of the <see cref="DeviceInfo"/> class.
    /// </summary>
    /// <param name="deviceId">The device Id.</param>
    /// <param name="pnpDeviceId">The PNP device Id.</param>
    /// <param name="description">The device description.</param>
    public DeviceInfo(string deviceId, string pnpDeviceId, string description)
    {
      this.deviceId = deviceId;
      this.pnpDeviceId = pnpDeviceId;
      this.description = description;
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets the device Id.
    /// </summary>
    /// <value>The device Id.</value>
    public string DeviceId
    {
      get { return this.deviceId; }
    }

    /// <summary>
    /// Gets the PNP device Id.
    /// </summary>
    /// <value>The PNP device Id.</value>
    public string PnpDeviceId
    {
      get { return this.pnpDeviceId; }
    }

    /// <summary>
    /// Gets the description.
    /// </summary>
    /// <value>The description.</value>
    public string Description
    {
      get { return this.description; }
    }

    #endregion
  }
}
