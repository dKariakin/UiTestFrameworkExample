using Extensions.Pages.Base;

namespace Actions
{
  public interface IBasicActions : IPagePrototype
  {
    void Click(string elementName);
    void OpenPage();
    void SendText(string elementName, string text);
  }
}
