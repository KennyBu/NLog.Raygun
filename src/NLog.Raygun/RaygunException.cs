using System;

namespace NLog.Raygun
{
    public class RaygunException : Exception
    {
        public RaygunException(string message)
            : base(message)
        {

        }
    }
}