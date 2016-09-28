using System;
using System.Web.Mvc;

namespace NLog.Raygun.WebTestApp.Controllers
{
  public class HomeController : BaseController
  {
    public ActionResult Index()
    {
      return View();
    }

    public ActionResult About()
    {
      ViewBag.Message = "Your application description page.";

      return View();
    }

    public ActionResult Contact()
    {
      ViewBag.Message = "Your contact page.";

      return View();
    }

    public ActionResult Error()
    {
      throw new ArgumentOutOfRangeException("Test");
    }
  }
}