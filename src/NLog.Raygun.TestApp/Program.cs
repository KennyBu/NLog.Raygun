using System;
using System.Collections.Generic;
using NLog.Config;

namespace NLog.Raygun.TestApp
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      ConfigurationItemFactory.Default.Targets.RegisterDefinition("RayGun", typeof(RayGunTarget));
      LogManager.ReconfigExistingLoggers();
      var logger = LogManager.GetCurrentClassLogger();

      Console.WriteLine("Sending Message to RayGun...");

      logger.Info("This is a test!");

      try
      {
        var e = new Exception("Test Exception");
        e.Data["Tags"] = new List<string> { "Tester123" };

        throw e;
      }
      catch (Exception exception)
      {
        logger.Error(exception);
      }

      Console.WriteLine("Finished...");
      Console.Read();
    }
  }
}