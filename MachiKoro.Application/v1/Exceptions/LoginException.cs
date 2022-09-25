using System;

namespace MachiKoro.Application.v1.Exceptions;

public class LoginException : ApplicationException
{
    public LoginException(string userName, string password) : base($"Failed to login with username \'{userName}\' and password \'{password}\'")
    {
    }
}