using System;
using System.Configuration;
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
        if(timeoutElement.Name == timeoutName)
        {
          timeout = timeoutElement.Time;
        }
      }
      return TimeSpan.FromSeconds(timeout);
    }
  }
}
