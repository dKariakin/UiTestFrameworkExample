using System.Configuration;

namespace Drivers.Configuration.Timeouts
{
  public class TimeoutsCollection : ConfigurationElementCollection
  {
    public TimeoutConfigElement this[int index]
    {
      get
      {
        return (TimeoutConfigElement)BaseGet(index);
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

    public void Add(TimeoutConfigElement timeoutConfig)
    {
      BaseAdd(timeoutConfig);
    }

    protected override ConfigurationElement CreateNewElement()
    {
      return new TimeoutConfigElement();
    }

    protected override object GetElementKey(ConfigurationElement element)
    {
      return ((TimeoutConfigElement)element).Name;
    }
  }
}
