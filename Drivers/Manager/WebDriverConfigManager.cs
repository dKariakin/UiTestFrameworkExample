using System;
using System.Collections.Generic;
using System.Configuration;
using Drivers.Configuration.Drivers;
using Drivers.Configuration.Timeouts;

namespace Drivers
{
  public abstract class WebDriverConfigManager
  {
    public static TimeSpan GetTimeout(string timeoutName = "default")
    {
      int timeout = 5;
      TimeoutsCollection timeouts = ((TimeoutsConfigSection)ConfigurationManager.GetSection("TimeoutsSection"))
                                                                                .Timeouts;
      foreach (TimeoutConfigElement timeoutElement in timeouts)
      {
        if (timeoutElement.Name == timeoutName)
        {
          timeout = timeoutElement.Time;
        }
      }
      return TimeSpan.FromSeconds(timeout);
    }

    public static string GetDriverConfiguration(string driverName, string parameter)
    {
      DriversCollection drivers = ((DriversConfigSection)ConfigurationManager.GetSection("DriversSection"))
                                                                             .Drivers;

      foreach (DriverConfigElement driver in drivers)
      {
        if (driver.DriverName.ToUpper() == driverName.ToUpper())
        {
          Dictionary<string, string> configMapper = new Dictionary<string, string>()
          {
            { WebDriverConfigParameters.Arguments, driver.Arguments },
            { WebDriverConfigParameters.BinaryLocation, driver.BinaryLocation },
            { WebDriverConfigParameters.BrowserVersion,driver.BrowserVersion },
            { WebDriverConfigParameters.PlatformName, driver.PlatformName }
          };
          if (configMapper.ContainsKey(parameter))
          {
            return configMapper[parameter];
          }
          else
          {
            break;
          }
        }
      }
      return null;
    }

    public static string[] GetDriverArgument(string driverName)
    {
      string arguments = GetDriverConfiguration(driverName, WebDriverConfigParameters.Arguments);
      return arguments.Split(',');
    }
  }
}
