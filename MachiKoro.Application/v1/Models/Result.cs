﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace MachiKoro.Application.v1.Models
{
    public class Result
    {
        public Result(bool succeeded, IEnumerable<string> errors)
        {
            Succeeded = succeeded;
            Errors = errors.ToArray();
        }

        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public bool Succeeded { get; set; }
        public string[] Errors { get; set; }

        public static Result Success()
        {
            return new Result(true, Array.Empty<string>());
        }

        public static Result Failure(IEnumerable<string> errors)
        {
            return new Result(false,  errors);
        }
    }
}