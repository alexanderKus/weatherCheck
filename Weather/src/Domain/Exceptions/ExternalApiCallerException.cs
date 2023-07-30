using System;
namespace Domain.Exceptions
{
	public class ExternalApiCallerException : Exception
	{
		public ExternalApiCallerException()
		{
		}
        public ExternalApiCallerException(string message) : base(message)
        {
        }
    }
}

