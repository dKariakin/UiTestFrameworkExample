using System;
using System.IO;
using OpenQA.Selenium;

namespace Drivers.Builder
{
  public class DriverCreator
  {
    private static IDriverBuilder _driverBuilder;
    
    public DriverCreator(IDriverBuilder driverBuilder)
    {
      _driverBuilder = driverBuilder;
      SetBinaryLocation();
    }

    public IWebDriver GetWebDriver()
    {
      return _driverBuilder.GetWebDriver();
    }

    public void SetPageLoadStrategy(PageLoadStrategy strategy)
    {
      _driverBuilder.SetPageLoadStrategy(strategy);
    }

    public void SetUnhandledPromptBehavior(UnhandledPromptBehavior behavior)
    {
      _driverBuilder.SetUnhandledPromptBehavior(behavior);
    }

    public void SetAcceptInsecureCertificates(bool isAccept)
    {
      _driverBuilder.SetAcceptInsecureCertificates(isAccept);
    }

    public void SetProxy(Proxy proxy)
    {
      _driverBuilder.SetProxy(proxy);
    }

    public void SetBinaryLocation(string location = null)
    {
      location = location ?? GetDriverDirectory();
      _driverBuilder.SetBinaryLocation(location);
    }

    public void SetArguments(string[] arguments)
    {
      _driverBuilder.SetArguments(arguments);
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
