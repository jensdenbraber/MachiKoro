﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace MachiKoro.Core.Models.Identity
{
    public class LoginUserResponse
    {
        public Guid? UserId { get; set; }
        public List<string> Errors { get; set; }
    }
}
