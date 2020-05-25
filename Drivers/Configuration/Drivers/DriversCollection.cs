using System.Configuration;

namespace Drivers.Configuration.Drivers
{
  public class DriversCollection : ConfigurationElementCollection
  {
    public DriverConfigElement this[int index]
    {
      get
      {
        return (DriverConfigElement)BaseGet(index);
      }
      set
      {
        if (BaseGet(index) != null)
        {
          BaseRemoveAt(index);
        }
        BaseAdd(index, value);
      }
    }

    public void Add(DriverConfigElement timeoutConfig)
    {
      BaseAdd(timeoutConfig);
    }

    protected override ConfigurationElement CreateNewElement()
    {
      return new DriverConfigElement();
    }

    protected override object GetElementKey(ConfigurationElement element)
    {
      return ((DriverConfigElement)element).DriverName;
    }
  }
}
