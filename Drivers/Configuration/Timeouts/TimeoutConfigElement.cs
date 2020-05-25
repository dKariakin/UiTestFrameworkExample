using System.Configuration;

namespace Drivers.Configuration.Timeouts
{
  public class TimeoutConfigElement : ConfigurationElement
  {
    public TimeoutConfigElement(string timeoutName = "default", int time = 5)
    {
      Name = timeoutName;
      Time = time;
    }

    [ConfigurationProperty("name", DefaultValue = "default", IsRequired = true, IsKey = true)]
    [StringValidator(InvalidCharacters = " ~!@#$%^&*()[]{}/;'\"|\\", MinLength = 1, MaxLength = 60)]
    public string Name
    {
      get
      {
        return this["name"].ToString();
      }
      set
      {
        this["name"] = value;
      }
    }

    [ConfigurationProperty("time", DefaultValue = 5, IsRequired = true)]
    [IntegerValidator(MinValue = 1, MaxValue = 60, ExcludeRange = false)]
    public int Time
    {
      get
      {
        return (int)this["time"];
      }
      set
      {
        this["time"] = value;
      }
    }
  }
}
