using Extensions.Pages.Base;
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
      _pages.GetPage<IPagePrototype>(pageName).OpenPage();
    }

    [Given(@"'([a-zA-Z\s]+)' has been found")]
    public void SearchForAnything(string query)
    {
      _pages.GetPage<IPagePrototype>(PageNames.GoogleMainPage).SendText("Search string", query);
      _pages.GetPage<IPagePrototype>(PageNames.GoogleMainPage).Click("Search button");
    }

    [When(@"I click on the 1 ([a-zA-Z\s]+)")]
    public void ClickOnSearchResult(string elementName)
    {
      _pages.GetPage<IPagePrototype>(PageNames.GoogleSearchResultPage).Click(elementName);
    }
  }
}
