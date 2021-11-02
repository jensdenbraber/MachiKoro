using System;
using System.Threading.Tasks;
using MachiKoro.Core.Models.User;
using Microsoft.AspNetCore.Identity;

namespace MachiKoro.Application.v1.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> CreateAsync(IdentityUser player);
        Task<bool> DeleteAsync(Guid playerId);
    }
}
