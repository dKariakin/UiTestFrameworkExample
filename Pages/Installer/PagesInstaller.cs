using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Drivers;
using Pages.Google;
using Pages.SpecFlow;
using TechTalk.SpecFlow;

namespace Pages.Installer
{
  public class PagesInstaller
  {
    private static WindsorContainer _container;
    public static string pagesContainer => "pagesContainer";

    public static WindsorContainer CreatePages(ScenarioContext scenarioContext)
    {
      _container = _container ?? new WindsorContainer();

      _container.Install(new WebDriverInstaller());

      _container.Register(Component.For<IBasePage>()
                                  .ImplementedBy<GoogleMainPage>()
                                  .Named(PageNames.GoogleMainPage)
                                  .LifestylePerThread());

      _container.Register(Component.For<IBasePage>()
                                  .ImplementedBy<GoogleSearchResultPage>()
                                  .Named(PageNames.GoogleSearchResultPage)
                                  .LifestylePerThread());

      _container.Register(Component.For<IBasePage>()
                                  .ImplementedBy<SpecflowMainPage>()
                                  .Named(PageNames.SpecFlowMainPage)
                                  .LifestylePerThread());

      scenarioContext.Add(pagesContainer, _container);
      
      return _container;
    }
  }
}
