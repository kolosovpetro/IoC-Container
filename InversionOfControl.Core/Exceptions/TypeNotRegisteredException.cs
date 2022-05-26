using System;

namespace InversionOfControl.Exceptions;

public class TypeNotRegisteredException: Exception
{
    public TypeNotRegisteredException(string message) : base(message)
    {
    }
}