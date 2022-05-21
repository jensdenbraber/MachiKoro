using System;

namespace MachiKoro.Application.v1.Exceptions;

public class UserAlreadyExistsException : ApplicationException
{
    public UserAlreadyExistsException(string userName) : base($"The username \'{userName}\' already exists.")
    {
    }
}