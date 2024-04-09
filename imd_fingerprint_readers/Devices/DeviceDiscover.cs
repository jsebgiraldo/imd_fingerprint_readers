using Devices.Exceptions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Management;

namespace Devices
{
  /// <summary>
  /// Discover connected devices based on the device id.
  /// </summary>
  public class DeviceDiscover
  {
    /// <summary>
    /// Gets the devices information.
    /// </summary>
    /// <param name="deviceIds">The list of device Ids to filter (if empty the method will return all detected devices).</param>
    /// <returns>List of devices information.</returns>
    public static DeviceInfo[] GetDevices(params string[] deviceIds)
    {
      // Search for devices based on the operative system.
      switch (Environment.OSVersion.Platform)
      {
        case PlatformID.Win32NT:
          {
            List<DeviceInfo> devices = new List<DeviceInfo>();

            // Query connected devices with the specified deviceId.
            string query = "Select * From Win32_PnPEntity ";

            if (deviceIds.Length > 0)
            {
              query = string.Format(CultureInfo.InvariantCulture, "{0}{1}", query, "WHERE ");

              for (int i = 0; i < deviceIds.Length; i++)
                query = string.Format(CultureInfo.InvariantCulture, "{0}{1}{2}", query, string.Format(CultureInfo.InvariantCulture, "DeviceID LIKE '%{0}%' ", deviceIds[i]), i >= deviceIds.Length - 1 ? string.Empty : "OR ");
            }

            ManagementObjectCollection collection;

            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(query))
              collection = searcher.Get();

            // Populates the result list.
            foreach (var device in collection)
            {
              devices.Add(new DeviceInfo(
                  (string)device.GetPropertyValue("DeviceID"),
                  (string)device.GetPropertyValue("PNPDeviceID"),
                  (string)device.GetPropertyValue("Description")));
            }

            collection.Dispose();
            return devices.ToArray();
          }

        case PlatformID.MacOSX:
        case PlatformID.Unix:
          {
            string message = "Not supported";
            Exception innerException = new NotImplementedException(Environment.OSVersion.Platform.ToString());

            throw new DeviceException(message, innerException);
          }

        case PlatformID.Win32Windows:
        case PlatformID.Win32S:
        default:
          {
            string message = "Unsupported platform";
            Exception innerException = new PlatformNotSupportedException(Environment.OSVersion.Platform.ToString());

            throw new DeviceException(message, innerException);
          }
      }
    }
  }
}
