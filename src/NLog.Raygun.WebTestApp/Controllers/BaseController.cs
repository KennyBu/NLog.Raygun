using System.Security.Claims;
using System.Web.Mvc;
using NLog.Config;

namespace NLog.Raygun.WebTestApp.Controllers
{
  public class BaseController : Controller
  {
    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

    static BaseController()
    {
      ConfigurationItemFactory.Default.Targets.RegisterDefinition("RayGun", typeof (RayGunTarget));
      LogManager.ReconfigExistingLoggers();
    }

    protected override void OnException(ExceptionContext filterContext)
    {
      Logger.Error(filterContext);
      base.OnException(filterContext);
    }
  }
}