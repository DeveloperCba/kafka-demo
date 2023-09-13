using System;

namespace Core.DomainObjects.Exceptions;

public class InternalServerErrorException : ApplicationException
{
    public InternalServerErrorException(string message) : base(message)
    {
    }
}