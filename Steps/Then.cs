using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Steps
{
  [Binding]
  public sealed class Then : Base
  {
    [Then(@"page with title ([a-zA-Z\s\.]+) is opened")]
    public void RequestedPageIsOpened(string expectedPage)
    {
      string actualPage = _webDriver.Title;
      Assert.True(string.Equals(expectedPage, actualPage),
                  $"Page {actualPage} was opened, although {expectedPage} had been expected");
    }
  }
}
