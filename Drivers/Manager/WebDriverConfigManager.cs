using System;
using System.Collections.Generic;
using System.Linq;
using Drivers.Configuration.Drivers;
using Drivers.Configuration.Timeouts;
using Microsoft.Extensions.Configuration;

namespace Drivers
{
  public class WebDriverConfigManager
  {
    private static IConfigurationRoot _config;

    /// <summary>
    /// Get timeout specified in appsettings.json
    /// </summary>
    /// <param name="timeoutName"></param>
    public static TimeSpan GetTimeout(string timeoutName = "default")
    {
      int timeout = 5;
      TimeoutConfigModel[] timeoutConfig = GetConfig().GetSection(TimeoutConfigModel.Timeouts)
                                                      .Get<TimeoutConfigModel[]>();

      TimeoutConfigModel confElement = timeoutConfig.FirstOrDefault(x => x.Name == timeoutName);
      int.TryParse(confElement?.Time, out timeout);

      return TimeSpan.FromSeconds(timeout);
    }

    /// <summary>
    /// Get a parameter from appsettings.json specified for a web driver
    /// </summary>
    /// <param name="driverName">Driver name specified in DriverName parameter</param>
    /// <param name="parameter">Arguments / BinaryLocation / BrowserVersion / PlatformName </param>
    /// <returns></returns>
    public static string GetDriverConfiguration(string driverName, string parameter)
    {
      DriverConfigModel[] driverConfigs = GetConfig().GetSection(DriverConfigModel.Drivers)
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

    /// <summary>
    /// Get list of parameters specified in appsettings.json
    /// </summary>
    /// <param name="driverName">Driver name specified in DriverName parameter</param>
    public static string[] GetDriverArgument(string driverName)
    {
      string arguments = GetDriverConfiguration(driverName, WebDriverConfigParameters.Arguments);
      return arguments.Split(';');
    }

    private static IConfigurationRoot GetConfig()
    {
      _config ??= new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
      return _config;
    }
  }
}
