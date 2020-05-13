using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Steps
{
  [Binding]
    public sealed class Then : Base
    {
        public Then(FeatureContext featureContext, ScenarioContext scenarioContext) : base(featureContext, scenarioContext)
        {

        }

        [Then(@"([a-zA-Z\s]+) is opened")]
        public void RequestedPageIsOpened(string expectedPage)
        {
            string actualPage = _webDriver.Title;
            Assert.True(string.Equals(expectedPage, actualPage), 
                        $"Page {actualPage} was opened, although {expectedPage} had been expected");
        }
    }
}
