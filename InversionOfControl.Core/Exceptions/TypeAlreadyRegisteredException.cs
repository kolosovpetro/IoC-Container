using System;

namespace InversionOfControl.Exceptions
{
    public class TypeAlreadyRegisteredException : Exception
    {
        public TypeAlreadyRegisteredException(string message) : base(message)
        {
        }
    }
}