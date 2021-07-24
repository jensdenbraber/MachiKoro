using System;
using System.ComponentModel.DataAnnotations;

namespace MachiKoro.Api.Models.GetPlayerProfile
{
    public class GetPlayerProfileRequest
    {
        [Required]
        public Guid PlayerId { get; set; }
    }
}
