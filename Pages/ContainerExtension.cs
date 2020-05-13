using Castle.Windsor;
using Pages;
using TechTalk.SpecFlow;

namespace Extensions
{
    public static class ContainerExtension
    {
        private static WindsorContainer container;

        public static IBasePage GetFromFactory(this ScenarioContext context, string pageName)
        {
            if (container == null)
            {
                container = new WindsorContainer();
                container.ResolveAll<IBasePage>();
            }
            context.Add(pageName, container.Resolve<IBasePage>(key: pageName));

            return container.Resolve<IBasePage>(key: pageName);
        }
    }
}
