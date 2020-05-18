using Pages;
using TechTalk.SpecFlow;

namespace Steps
{
  [Binding]
  public sealed class When : Base
  {
    [Given(@"([a-zA-Z\s]+) is opened")]
    public void OpenPage(string pageName)
    {
      _pages.Value.GetPage(pageName).OpenPage();
    }

    [Given(@"'([a-zA-Z\s]+)' has been found")]
    public void SearchForAnything(string query)
    {
      _pages.Value.GetPage(PageNames.GoogleMainPage).SendText("Search string", query);
      _pages.Value.GetPage(PageNames.GoogleMainPage).Click("Search button");
    }

    [When(@"I click on the (\d) search result")]
    public void ClickOnSearchResult(int resOrder)
    {
      _pages.Value.GetPage(PageNames.GoogleSearchResultPage).ClickCollectionElement("Search results", resOrder);
    }
  }
}
