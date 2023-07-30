using System;
namespace Domain.Exceptions
{
	public class InvalidCoordinatesException : Exception
	{
		public InvalidCoordinatesException()
		{
		}

        public InvalidCoordinatesException(string message) : base(message)
        {
        }
    }
}

