using System.Web;
using System.Web.Mvc;

namespace NLog.Raygun.WebTestApp
{
  public class FilterConfig
  {
    public static void RegisterGlobalFilters(GlobalFilterCollection filters)
    {
      filters.Add(new HandleErrorAttribute());
    }
  }
}
