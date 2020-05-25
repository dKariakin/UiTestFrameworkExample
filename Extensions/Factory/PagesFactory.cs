using System;
using System.Collections.Generic;
using Extensions.Pages.Base;

namespace Extensions.Pages.Factory
{
  public class PagesFactory
  {
    private static Dictionary<string, IPagePrototype> _pages = new Dictionary<string, IPagePrototype>();

    public void InitializePages<T>(T[] basePages) where T : IPagePrototype
    {
      foreach (T page in basePages)
      {
        _pages.Add(page.GetPageObjectName(), page);
      }
    }

    public T GetPage<T>(string pageName) where T : IPagePrototype
    {
      if (_pages.ContainsKey(pageName))
      {
        return (T)_pages[pageName];
      }
      else
      {
        throw new NullReferenceException($"Page {pageName} is undefined");
      }
    }

    public IPagePrototype GetPage(string pageName)
    {
      return GetPage<IPagePrototype>(pageName);
    }
  }
}
