﻿using Microsoft.AspNetCore.Identity;
using System.Runtime.Serialization;

namespace MachiKoro.Persistence.Identity.Models;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool IsEnabled { get; set; }

    [IgnoreDataMember]
    public string FullName
    {
        get
        {
            return $"{FirstName} {LastName}";
        }
    }

    //[JsonIgnore]
    //public List<RefreshToken> RefreshTokens { get; set; }
}