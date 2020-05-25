using TechTalk.SpecFlow;

namespace Steps
{
  [Binding]
  public sealed class After : Base
  {
    [AfterScenario(Order = 0)]
    public void DisposeAll()
    {
      _webDriver.Close();
      _webDriver.Dispose();
    }
  }
}
