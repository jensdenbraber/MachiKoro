using System;

namespace MachiKoro.Core.Models.User
{
    public class MachiKoroUser
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
