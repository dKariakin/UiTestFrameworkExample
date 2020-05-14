using System.Configuration;
using Drivers;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Steps
{
  public abstract class Base
  {
    protected static IWebDriver _webDriver = null;
    protected FeatureContext _featureContext = null;
    protected ScenarioContext _scenarioContext = null;

    public Base(FeatureContext featureContext, ScenarioContext scenarioContext)
    {
      string driverName = ConfigurationManager.AppSettings["driver"];
      _scenarioContext = scenarioContext;
      _featureContext = featureContext;

      _webDriver = WebDriverSetup.GetWebDriver(driverName);
    }
  }
}
