using System;
using System.Collections.Generic;
using System.IO;
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
    public static TimeSpan GetTimeout(string timeoutName = "default")
    {
      int defaultTimeout = 5;
      TimeoutConfigModel[] timeoutConfig = GetConfig().GetSection(TimeoutConfigModel.Timeouts)
                                                      .Get<TimeoutConfigModel[]>();

      TimeoutConfigModel confElement = timeoutConfig.FirstOrDefault(x => x.Name == timeoutName);
      if(int.TryParse(confElement?.Time, out int timeout))
      {
        return TimeSpan.FromSeconds(timeout);
      }
      else
      {
        return TimeSpan.FromSeconds(defaultTimeout);
      }
    }

    /// <summary>
    /// Get a parameter from appsettings.json specified for a web driver
    /// </summary>
    /// <param name="driverName">ChromeDriver / FirefoxDriver / OperaDriver</param>
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
            { WebDriverConfigParameters.BrowserVersion,configElement.BrowserVersion },
            { WebDriverConfigParameters.PlatformName, configElement.PlatformName }
          };
          if (configMapper.ContainsKey(parameter))
          {
            try
            {
              return configMapper[parameter];
            }
            catch(NullReferenceException)
            {
              return null;
            }
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
    /// <param name="driverName">Driver name specified in DriverName parameter (ChromeDriver / FirefoxDriver / OperaDriver)</param>
    public static string[] GetDriverArgument(string driverName)
    {
      return GetDriverConfiguration(driverName, WebDriverConfigParameters.Arguments)?.Split(';');
    }

    private static IConfigurationRoot GetConfig()
    {
      _config ??= new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

      return _config;
    }

    public static string GetDriverBinaryLocation()
    {
      string driverPath = AppDomain.CurrentDomain.BaseDirectory;
      
      do
      {
        driverPath = Directory.GetParent(Path.GetFullPath(driverPath)).FullName;
      }
      while (!Directory.Exists(Path.Combine(driverPath, "Drivers")));
      
      return Path.Combine(driverPath, "Drivers");
    }
  }
}
