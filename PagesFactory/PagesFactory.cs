using System;
using System.Collections.Generic;
using Actions;

namespace Extensions.Pages.Factory
{
  public class PagesFactory
  {
    private static Dictionary<string, IBasicActions> _pages;
    
    public PagesFactory(IBasicActions[] basePages)
    {
      _pages = new Dictionary<string, IBasicActions>();

      foreach(IBasicActions page in basePages)
      {
        _pages.Add(page.GetPageObjectName(), page);
      }
    }

    public IBasicActions GetPage(string pageName)
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
