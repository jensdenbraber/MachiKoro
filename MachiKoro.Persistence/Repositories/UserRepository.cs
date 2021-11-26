using AutoMapper;
using MachiKoro.Application.v1.Interfaces;
using MachiKoro.Core.Models.User;
using MachiKoro.Infrastructure.Identity.Models;
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
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        //public UserRepository(IMapper mapper, IdentityDataContext gameDataContext, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager)
        public UserRepository(IMapper mapper, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            //_identityDataContext = gameDataContext ?? throw new ArgumentNullException(nameof(gameDataContext));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
        }

        public async Task<IdentityResult> CreateAsync(MachiKoroUser identityUser)
        {
            var userData = _mapper.Map<ApplicationUser>(identityUser);

            IdentityResult identityResult = await _userManager.CreateAsync(userData, identityUser.Password);

            return identityResult;

            //await _identityDataContext.Users.AddAsync(userData);

            //var created = await _identityDataContext.SaveChangesAsync();
            //return created > 0;
        }

        public async Task<MachiKoroUser> GetAsync(Guid userId)
        {
            ApplicationUser applicationUser = await _userManager.FindByIdAsync(userId.ToString());

            var user = _mapper.Map<MachiKoroUser>(applicationUser);

            return user;
        }

        public Task<bool> DeleteAsync(Guid playerId)
        {
            throw new NotImplementedException();
        }
    }
}
