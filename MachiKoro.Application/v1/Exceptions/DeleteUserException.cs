using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace MachiKoro.Application.v1.Exceptions
{
    public class DeleteUserException : ApplicationException
    {
        public IEnumerable<IdentityError> Errors { get; }

        public DeleteUserException(IEnumerable<IdentityError> errors)
        {
            Errors = errors;
        }
    }
}