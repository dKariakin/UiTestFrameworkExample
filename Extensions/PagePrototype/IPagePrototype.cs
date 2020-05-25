using Extensions.PageManager;

namespace Extensions.Pages.Base
{
  public interface IPagePrototype : IPageObjectManager
  {
    void Click(string elementName, bool isPageChanged = true);
    void OpenPage();
    void SendText(string elementName, string text);
  }
}
