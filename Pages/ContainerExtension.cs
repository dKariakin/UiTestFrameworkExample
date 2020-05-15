using Castle.Windsor;
using OpenQA.Selenium;
using Pages;
using Pages.Installer;
using TechTalk.SpecFlow;

namespace Extensions
{
  public static class ContainerExtension
  {
    public static IBasePage GetFromFactory(this ScenarioContext context, string pageName)
    {
      if (!context.TryGetValue(PagesInstaller.pagesContainer, out WindsorContainer container))
      {
        container = PagesInstaller.CreatePages(context);
      }

      return container.Resolve<IBasePage>(key: pageName);
    }
  }
}
