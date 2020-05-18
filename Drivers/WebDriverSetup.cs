using System;
using System.Configuration;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Drivers
{
  public class WebDriverSetup
  {
    private static readonly IWebDriver _webDriver = null;
    private readonly string driverName = ConfigurationManager.AppSettings["driver"];

    public IWebDriver GetWebDriver()
    {
      return _webDriver ?? WebDriverInitialize();
    }

    public IWebDriver WebDriverInitialize()
    {
      string driverPath = GetDriverDirectory();

      switch (driverName)
      {
        case "chrome":
          ChromeOptions options = new ChromeOptions()
          {
            AcceptInsecureCertificates = false,
            PageLoadStrategy = PageLoadStrategy.Eager,
            UnhandledPromptBehavior = UnhandledPromptBehavior.Ignore
          };
          options.AddArguments("start-maximized");
          return new ChromeDriver(driverPath, options);
        default:
          throw new NotImplementedException($"{driverName} is an unknown web driver");
      }
    }

    private static string GetDriverDirectory()
    {
      string driverPath = AppDomain.CurrentDomain.BaseDirectory;
      do
      {
        driverPath = Directory.GetParent(Path.GetFullPath(driverPath)).FullName;
      }
      while (!Directory.Exists(Path.Combine(driverPath, "Drivers")));
      driverPath = Path.Combine(driverPath, "Drivers", "WebDriver");

      return driverPath;
    }
  }
}
