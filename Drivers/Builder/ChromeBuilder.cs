using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Drivers.Builder
{
  public class ChromeBuilder : IDriverBuilder
  {
    private readonly ChromeOptions _options = new ChromeOptions();
    private static ChromeDriver _driver;
    private string _driverPath = null;

    public IWebDriver GetWebDriver()
    {
      _driver = _driver ?? new ChromeDriver(_driverPath, _options);
      return _driver;
    }

    public void SetAcceptInsecureCertificates(bool isAccept)
    {
      _options.AcceptInsecureCertificates = isAccept;
    }

    public void SetArguments(string[] arguments)
    {
      _options.AddArguments(arguments);
    }

    public void SetBinaryLocation(string location)
    {
      _driverPath = location;
    }

    public void SetPageLoadStrategy(PageLoadStrategy strategy)
    {
      _options.PageLoadStrategy = strategy;
    }

    public void SetProxy(Proxy proxy)
    {
      _options.Proxy = proxy;
    }

    public void SetUnhandledPromptBehavior(UnhandledPromptBehavior behavior)
    {
      _options.UnhandledPromptBehavior = behavior;
    }
  }
}
