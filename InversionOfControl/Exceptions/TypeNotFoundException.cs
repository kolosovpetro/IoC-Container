using System;

namespace InversionOfControl.Exceptions
{
    public class TypeNotFoundException: Exception
    {
        public TypeNotFoundException(string message) : base(message)
        {
        }
    }
}