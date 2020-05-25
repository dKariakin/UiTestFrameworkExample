namespace Extensions.PageManager
{
  public interface IPageObjectManager
  {
    string GetNextPageName(string elementClicked);
    string GetPageObjectName();
  }
}
