using System.Collections.Generic;
using Extensions.Pages.Base;

namespace Extensions.Pages.Factory
{
  public class PagesFactory
  {
    private Dictionary<string, BasePage> _pages;
    
    public PagesFactory(BasePage[] basePages)
    {
      foreach(BasePage page in basePages)
      {
        _pages.Add(page.GetPageObjectName(), page);
      }
    }

    public BasePage GetPage(string pageName)
    {
      return _pages[pageName];
    }
  }
}
