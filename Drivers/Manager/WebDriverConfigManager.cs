using System;
using System.Collections.Generic;
using Drivers.Configuration.Drivers;
using Drivers.Configuration.Timeouts;
using Microsoft.Extensions.Configuration;

namespace Drivers
{
  public class WebDriverConfigManager
  {
    public static TimeSpan GetTimeout(string timeoutName = "default")
    {
      int timeout = 5;
      IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
      TimeoutConfigModel[] timeoutConfig = config.GetSection(TimeoutConfigModel.Timeouts)
                                                 .Get<TimeoutConfigModel[]>();
      
      foreach (TimeoutConfigModel confElement in timeoutConfig)
      {
        if (confElement.Name == timeoutName)
        {
          int.TryParse(confElement.Time, out timeout);
          break;
        }
      }

      return TimeSpan.FromSeconds(timeout);
    }

    public static string GetDriverConfiguration(string driverName, string parameter)
    {
      IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
      DriverConfigModel[] driverConfigs = config.GetSection(DriverConfigModel.Drivers)
                                                .Get<DriverConfigModel[]>();

      foreach (DriverConfigModel configElement in driverConfigs)
      {
        if (configElement.DriverName.ToUpper() == driverName.ToUpper())
        {
          Dictionary<string, string> configMapper = new Dictionary<string, string>()
          {
            { WebDriverConfigParameters.Arguments, configElement.Arguments },
            { WebDriverConfigParameters.BinaryLocation, configElement.BinaryLocation },
            { WebDriverConfigParameters.BrowserVersion,configElement.BrowserVersion },
            { WebDriverConfigParameters.PlatformName, configElement.PlatformName }
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
      return arguments.Split(';');
    }
  }
}
