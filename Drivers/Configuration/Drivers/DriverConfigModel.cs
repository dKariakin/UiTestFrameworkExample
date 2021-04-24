namespace Drivers.Configuration.Drivers
{
  public class DriverConfigModel
  {
    public const string Drivers = "Drivers";

    public string DriverName { get; set; }
    public string Arguments { get; set; }
    public string PlatformName { get; set; }
    public string BrowserVersion { get; set; }
  }
}
