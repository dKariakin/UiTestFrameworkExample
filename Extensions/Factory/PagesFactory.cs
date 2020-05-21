using System;
using System.Collections.Generic;
using Extensions.Pages.Base;

namespace Extensions.Pages.Factory
{
  public class PagesFactory
  {
    private static object _pages;

    public void InitializePages<T>(T[] basePages) where T : IPagePrototype
    {
      _pages = new Dictionary<string, T>();

      foreach (T page in basePages)
      {
        (_pages as Dictionary<string, T>).Add(page.GetPageObjectName(), page);
      }
    }

    public T GetPage<T>(string pageName) where T : IPagePrototype
    {
      var pages = _pages as Dictionary<string, T>;

      if (pages.ContainsKey(pageName))
      {
        return pages[pageName];
      }
      else
      {
        throw new NullReferenceException($"Page {pageName} is undefined");
      }
    }
  }
}
