using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace MachiKoro.Contracts.v1.Requests
{
    public class UpdatePlayerRequest
    {
        [Required]
        public string UserName { get; set; }
    }
}
