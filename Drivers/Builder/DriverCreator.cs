using OpenQA.Selenium;

namespace Drivers.Builder
{
  public class DriverCreator
  {
    private static IDriverBuilder _driverBuilder;
    
    public DriverCreator(IDriverBuilder driverBuilder)
    {
      _driverBuilder = driverBuilder;
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

    public void SetArguments(string[] arguments)
    {
      _driverBuilder.SetArguments(arguments);
    }
  }
}
