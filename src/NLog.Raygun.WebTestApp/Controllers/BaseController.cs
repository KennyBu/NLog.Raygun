using System.Web.Mvc;
using NLog.Config;

namespace NLog.Raygun.WebTestApp.Controllers
{
  [HandleError]
  public class BaseController : Controller
  {
    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

    static BaseController()
    {
      ConfigurationItemFactory.Default.Targets.RegisterDefinition("RayGun", typeof(RayGunTarget));
      LogManager.ReconfigExistingLoggers();
    }

    protected override void OnException(ExceptionContext filterContext)
    {
      Logger.Fatal(filterContext);
      base.OnException(filterContext);
    }
  }
}