using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Drivers
{
  public class WebDriverInstaller : IWindsorInstaller
  {
    public void Install(IWindsorContainer container, IConfigurationStore store)
    {
      container.Register(Component.For<IWebDriverSetup>()
                                  .ImplementedBy<WebDriverSetup>()
                                  .LifestylePerThread());
    }
  }
}
