namespace Extensions.Pages.Base
{
  public interface IPagePrototype
  {
    void Click(string elementName);
    void OpenPage();
    void SendText(string elementName, string text);
    string GetPageObjectName();
  }
}
