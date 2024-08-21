using Microsoft.AspNetCore.Identity;

namespace Multitenancy.Database.User;

public class User : IdentityUser
{
    public string? Initials { get; set; }
}