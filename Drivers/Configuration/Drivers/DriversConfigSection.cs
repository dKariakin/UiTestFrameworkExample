using System.Configuration;

namespace Drivers.Configuration.Drivers
{
  public class DriversConfigSection : ConfigurationSection
  {
    [ConfigurationProperty("Drivers", IsDefaultCollection = false)]
    [ConfigurationCollection(typeof(DriversCollection), AddItemName = "Driver")]
    public DriversCollection Drivers
    {
      get
      {
        return (DriversCollection)base["Drivers"];
      }
    }
  }
}
