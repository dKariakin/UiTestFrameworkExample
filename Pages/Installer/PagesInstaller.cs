using Castle.MicroKernel.Registration;
using Castle.Windsor;
using OpenQA.Selenium;
using Pages.Google;
using Pages.SpecFlow;
using TechTalk.SpecFlow;

namespace Pages.Installer
{
  public class PagesInstaller
  {
    private static WindsorContainer _container;
    public static string pagesContainer => "pagesContainer";

    public static void CreatePages(ScenarioContext scenarioContext, IWebDriver webDriver)
    {
      _container = _container ?? new WindsorContainer();

      _container.Register(Component.For<IBasePage>()
                                  .ImplementedBy<GoogleMainPage>()
                                  .Named(PageNames.GoogleMainPage)
                                  .DependsOn(Dependency.OnValue("webDriver", webDriver))
                                  .LifestylePerThread());

      _container.Register(Component.For<IBasePage>()
                                  .ImplementedBy<GoogleSearchResultPage>()
                                  .Named(PageNames.GoogleSearchResultPage)
                                  .DependsOn(Dependency.OnValue("webDriver", webDriver))
                                  .LifestylePerThread());

      _container.Register(Component.For<IBasePage>()
                                  .ImplementedBy<SpecflowMainPage>()
                                  .Named(PageNames.SpecFlowMainPage)
                                  .DependsOn(Dependency.OnValue("webDriver", webDriver))
                                  .LifestylePerThread());

      scenarioContext.Add(pagesContainer, _container);
    }
  }
}
