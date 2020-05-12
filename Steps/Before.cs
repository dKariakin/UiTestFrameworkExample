using System.Configuration;
using TechTalk.SpecFlow;

namespace Steps
{
    [Binding]
    public sealed class Before : Base
    {
        public Before(FeatureContext featureContext, ScenarioContext scenarioContext) : base(featureContext, scenarioContext)
        {

        }
    }
}
