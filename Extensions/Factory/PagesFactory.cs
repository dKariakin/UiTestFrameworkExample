using System;
using System.Collections.Generic;
using Extensions.Pages.Base;

namespace Extensions.Pages.Factory
{
  public class PagesFactory
  {
    private static Dictionary<string, IPagePrototype> _pages;
    
    public PagesFactory(IPagePrototype[] basePages)
    {
      _pages = new Dictionary<string, IPagePrototype>();

      foreach(IPagePrototype page in basePages)
      {
        _pages.Add(page.GetPageObjectName(), page);
      }
    }

    public IPagePrototype GetPage(string pageName)
    {
      if(_pages.ContainsKey(pageName))
      {
        return _pages[pageName];
      }
      else
      {
        throw new NullReferenceException($"Page {pageName} is undefined");
      }
    }
  }
}
