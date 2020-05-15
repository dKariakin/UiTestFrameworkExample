using TechTalk.SpecFlow;
using Extensions;
using Pages;

namespace Steps
{
  [Binding]
  public sealed class When : Base
  {
    public When(FeatureContext featureContext, ScenarioContext scenarioContext) : base(featureContext, scenarioContext)
    {
    }

    [Given(@"([a-zA-Z\s]+) is opened")]
    public void OpenPage(string pageName)
    {
      _scenarioContext.GetFromFactory(pageName, _webDriver).OpenPage();
    }

    [Given(@"'([a-zA-Z\s]+)' has been found")]
    public void SearchForAnything(string query)
    {
      _scenarioContext.GetFromFactory(PageNames.GoogleMainPage, _webDriver)
                      .SendText("Search string", query);
      _scenarioContext.GetFromFactory(PageNames.GoogleMainPage, _webDriver)
                      .Click("Search button");
    }

    [When(@"I click on the (\d) search result")]
    public void ClickOnSearchResult(int resOrder)
    {
      _scenarioContext.GetFromFactory(PageNames.GoogleSearchResultPage, _webDriver)
                      .ClickCollectionElement("Search results", resOrder);
    }
  }
}
