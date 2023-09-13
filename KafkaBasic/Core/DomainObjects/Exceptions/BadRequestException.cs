using System;

namespace Core.DomainObjects.Exceptions;

public class BadRequestException : ApplicationException
{
    public BadRequestException(string message) : base(message)
    {
    }
}