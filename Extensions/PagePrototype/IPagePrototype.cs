namespace Extensions.Pages.Base
{
  public interface IPagePrototype
  {
    string GetPageObjectName();
    void Click(string elementName, bool isPageChanged = true);
    void OpenPage();
    void SendText(string elementName, string text);
    string GetNextPageName(string elementClicked);
  }
}
