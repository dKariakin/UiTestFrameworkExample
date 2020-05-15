using Castle.Windsor;
using OpenQA.Selenium;
using Pages;
using Pages.Installer;
using TechTalk.SpecFlow;

namespace Extensions
{
  public static class ContainerExtension
  {
    public static IBasePage GetFromFactory(this ScenarioContext context, string pageName, IWebDriver webDriver)
    {
      if (!context.TryGetValue(PagesInstaller.pagesContainer, out WindsorContainer container))
      {
        PagesInstaller.CreatePages(context, webDriver);
      }

      return container.Resolve<IBasePage>(key: pageName);
    }
  }
}
