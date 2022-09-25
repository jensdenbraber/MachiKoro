using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace MachiKoro.Application.v1.Exceptions;

public class RegisterException : ApplicationException
{
    public List<string> Errors { get; set; }

    public RegisterException(IEnumerable<IdentityError> errors)
    {
        Errors = new List<string>();
        foreach (var error in errors)
        {
            Errors.Add(error.Description);
        }
    }
}