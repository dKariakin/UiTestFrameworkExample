using System.Configuration;

namespace Drivers.Configuration.Timeouts
{
  public class TimeoutsConfigSection : ConfigurationSection
  {
    [ConfigurationProperty("Timeouts", IsDefaultCollection = false)]
    [ConfigurationCollection(typeof(TimeoutsCollection), AddItemName = "Timeout")]
    public TimeoutsCollection Timeouts
    {
      get
      {
        return (TimeoutsCollection)base["Timeouts"];
      }
    }
  }
}
