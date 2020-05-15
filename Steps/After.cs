using TechTalk.SpecFlow;

namespace Steps
{
  [Binding]
  public sealed class After : Base
  {
    public After(FeatureContext featureContext, ScenarioContext scenarioContext) : base(featureContext, scenarioContext)
    {

    }

    [AfterScenario(Order = 0)]
    public void DisposeAll()
    {
      _webDriver.Close();
      _webDriver.Dispose();
    }
  }
}
