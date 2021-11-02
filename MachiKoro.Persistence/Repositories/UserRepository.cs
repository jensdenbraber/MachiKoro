using AutoMapper;
using MachiKoro.Application.v1.Interfaces;
using MachiKoro.Core.Models.User;
using MachiKoro.Persistence.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiKoro.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMapper _mapper;
        private readonly IdentityDataContext _identityDataContext;

        public UserRepository(IMapper mapper, IdentityDataContext gameDataContext)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _identityDataContext = gameDataContext;
        }

        public async Task<bool> CreateAsync(IdentityUser identityUser)
        {
            var userData = _mapper.Map<ApplicationUser>(identityUser);

            await _identityDataContext.Users.AddAsync(userData);

            var created = await _identityDataContext.SaveChangesAsync();
            return created > 0;
        }
        public Task<bool> DeleteAsync(Guid playerId)
        {
            throw new NotImplementedException();
        }
    }
}
