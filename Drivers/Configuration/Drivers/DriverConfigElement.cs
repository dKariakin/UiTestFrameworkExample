using System.Configuration;

namespace Drivers.Configuration.Drivers
{
  public class DriverConfigElement : ConfigurationElement
  {
    public DriverConfigElement(string driverName = "ChromeDriver", string binaryLocation = null,
                               string arguments = null, string platformName = null,
                               string browserVersion = null)
    {
      DriverName = driverName;
      BinaryLocation = binaryLocation;
      Arguments = arguments;
      PlatformName = platformName;
      BrowserVersion = browserVersion;
    }

    [ConfigurationProperty("driverName", DefaultValue = "default", IsRequired = true, IsKey = true)]
    [StringValidator(InvalidCharacters = " ~!@#$%^&*()[]{}/;'\"|\\", MinLength = 1, MaxLength = 60)]
    public string DriverName
    {
      get
      {
        return this["driverName"].ToString();
      }
      set
      {
        this["driverName"] = value;
      }
    }

    [ConfigurationProperty(WebDriverConfigParameters.BinaryLocation, DefaultValue = null, IsRequired = false)]
    [StringValidator(InvalidCharacters = " ~!@#$%^&*()[]{}/;'\"|\\", MinLength = 0, MaxLength = 100)]
    public string BinaryLocation
    {
      get
      {
        return (string)this[WebDriverConfigParameters.BinaryLocation];
      }
      set
      {
        this[WebDriverConfigParameters.BinaryLocation] = value;
      }
    }

    [ConfigurationProperty(WebDriverConfigParameters.Arguments, DefaultValue = null, IsRequired = false)]
    [StringValidator(InvalidCharacters = " ~!@#$%^&*()[]{}/;'\"|\\", MinLength = 0, MaxLength = 100)]
    public string Arguments
    {
      get
      {
        return (string)this[WebDriverConfigParameters.Arguments];
      }
      set
      {
        this[WebDriverConfigParameters.Arguments] = value;
      }
    }

    [ConfigurationProperty(WebDriverConfigParameters.PlatformName, DefaultValue = null, IsRequired = false)]
    [StringValidator(InvalidCharacters = " ~!@#$%^&*()[]{}/;'\"|\\", MinLength = 0, MaxLength = 100)]
    public string PlatformName
    {
      get
      {
        return (string)this[WebDriverConfigParameters.PlatformName];
      }
      set
      {
        this[WebDriverConfigParameters.PlatformName] = value;
      }
    }

    [ConfigurationProperty(WebDriverConfigParameters.BrowserVersion, DefaultValue = null, IsRequired = false)]
    [StringValidator(InvalidCharacters = " ~!@#$%^&*()[]{}/;'\"|\\", MinLength = 0, MaxLength = 100)]
    public string BrowserVersion
    {
      get
      {
        return (string)this[WebDriverConfigParameters.BrowserVersion];
      }
      set
      {
        this[WebDriverConfigParameters.BrowserVersion] = value;
      }
    }
  }
}
