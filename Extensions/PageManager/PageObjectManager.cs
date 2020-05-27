using System.Collections.Generic;

namespace Extensions.PageManager
{
  public class PageObjectManager
  {
    public static string CurrentPageName { get; set; }
    private string _pageObjectName;
    private Dictionary<string, string> _pageTransitions;

    protected void SetPageTransitions((string, string)[] transitions)
    {
      _pageTransitions = new Dictionary<string, string>();

      foreach ((string, string) transition in transitions)
      {
        _pageTransitions.Add(transition.Item1, transition.Item2);
      }
    }

    /// <summary>
    /// Get a name of page according to specified transitions
    /// </summary>
    /// <param name="clickedElement">Name of element we click on</param>
    /// <returns>Name of new page object (or current if transition doesn't needed)</returns>
    public virtual string GetNextPageName(string clickedElement)
    {
      if (_pageTransitions.ContainsKey(clickedElement.ToLower()))
      {
        return _pageTransitions[clickedElement.ToLower()];
      }
      else
      {
        return GetPageObjectName();
      }
    }

    protected void SetPageObjectName(string name)
    {
      _pageObjectName = name;
    }

    /// <summary>
    /// Get current page object name
    /// </summary>
    public string GetPageObjectName()
    {
      return _pageObjectName;
    }

  }
}
