namespace Extensions.Pages.Base
{
  public interface IPagePrototype
  {
    string GetPageObjectName();
    void Click(string elementName);
    void OpenPage();
    void SendText(string elementName, string text);
  }
}
