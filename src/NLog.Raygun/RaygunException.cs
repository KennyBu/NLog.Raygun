using System;

namespace NLog.Raygun
{
    public class RaygunException : Exception
    {
        public RaygunException(string message)
            : base(message)
        {

        }

        public RaygunException(string message, Exception innerException)
            : base(message, innerException)
        {
            
        }
    }
}