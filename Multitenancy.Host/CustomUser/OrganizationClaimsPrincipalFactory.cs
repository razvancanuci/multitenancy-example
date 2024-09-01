using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Multitenancy.Database.User;

namespace Multitenancy.CustomUser;

public class OrganizationClaimsPrincipalFactory : UserClaimsPrincipalFactory<User>
{
    public OrganizationClaimsPrincipalFactory(
        UserManager<User> userManager,
        IOptions<IdentityOptions> optionsAccessor) : base(userManager, optionsAccessor)
    {
    }
    
    protected override async Task<ClaimsIdentity> GenerateClaimsAsync(User user)
    {
        var identity = await base.GenerateClaimsAsync(user);
        
        identity.AddClaim(new Claim("organization", user.Organization ?? "default"));
        
        return identity;
    }
}