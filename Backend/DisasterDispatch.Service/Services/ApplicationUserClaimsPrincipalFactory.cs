using DisasterDispatch.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Service.Services
{
    public class ApplicationUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<AppUser, AppRole>
    {
        public ApplicationUserClaimsPrincipalFactory(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IOptions<IdentityOptions> options) : base(userManager, roleManager, options)
        {
        }
        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(AppUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("UserNamee", user.UserName??""));
            identity.AddClaim(new Claim("City", user.City??""));
            identity.AddClaim(new Claim("Mail", user.Email??""));
            return identity;
        }
    }
}
