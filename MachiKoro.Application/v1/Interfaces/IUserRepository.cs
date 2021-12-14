using System;
using System.Threading.Tasks;
using MachiKoro.Domain.Models.User;
using Microsoft.AspNetCore.Identity;

namespace MachiKoro.Application.v1.Interfaces
{
    public interface IUserRepository
    {
        Task<IdentityResult> CreateAsync(MachiKoroUser player);
        Task<MachiKoroUser> GetAsync(Guid userId);
        Task<bool> DeleteAsync(Guid playerId);
    }
}
