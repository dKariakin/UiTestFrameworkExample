using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Pages.Google;
using Pages.SpecFlow;

namespace Pages.Installer
{
    public class PagesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<GoogleMainPage>()
                                        .Named(PageNames.GoogleMainPage)
                                        .LifestyleSingleton());

            container.Register(Component.For<GoogleSearchResultPage>()
                                        .Named(PageNames.GoogleSearchResultPage)
                                        .LifestyleSingleton());

            container.Register(Component.For<SpecflowMainPage>()
                                        .Named(PageNames.SpecFlowMainPage)
                                        .LifestyleSingleton());
        }
    }
}
