using System;

namespace Explore.Services
{
    public class ServiceException : Exception
    {
        public ServiceException()
        { }

        public ServiceException(string message)
            : base ($"Exception occur in service : {message}")
        { }
    }
}