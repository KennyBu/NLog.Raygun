using System;
using NLog.Config;

namespace NLog.Raygun.TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigurationItemFactory.Default.Targets.RegisterDefinition("RayGun", typeof(RayGunTarget));
            LogManager.ReconfigExistingLoggers();
            var logger = LogManager.GetCurrentClassLogger();

            Console.WriteLine("Sending Message to RayGun...");
            
            logger.Info("This is a test!");

            try
            {
                throw new Exception("Test Exception");
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
