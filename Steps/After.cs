using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Steps
{
  [Binding]
  public sealed class After : Base
  {
    [TearDown]
    public void DisposeAll()
    {
      _webDriver.Close();
    }
  }
}
