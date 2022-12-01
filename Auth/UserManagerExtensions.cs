using api.Modules.Auth.Models;
using Microsoft.AspNetCore.Identity;

namespace api.Data;

public static class UserManagerExtensions
{
    public static async Task<IdentityResult> AddToRoleSuperAdminAsync(this UserManager<AppUser> userManager, AppUser user)
    {
        return await userManager.AddToRoleAsync(user, "Superadmin");
    }

    public static async Task<IdentityResult> AddToRoleAdminAsync(this UserManager<AppUser> userManager, AppUser user)
    {
        return await userManager.AddToRoleAsync(user, "Admin");
    }

    public static async Task<IdentityResult> AddToRoleClientAsync(this UserManager<AppUser> userManager, AppUser user)
    {
        return await userManager.AddToRoleAsync(user, "Client");
    }

    public static async Task<IdentityResult> AddToRoleFreelancerAsync(this UserManager<AppUser> userManager, AppUser user)
    {
        return await userManager.AddToRoleAsync(user, "Freelancer");
    }

    public static async Task<IdentityResult> RemoveFromRoleSuperAdminAsync(this UserManager<AppUser> userManager, AppUser user)
    {
        return await userManager.RemoveFromRoleAsync(user, "Superadmin");
    }

    public static async Task<IdentityResult> RemoveFromRoleAdminAsync(this UserManager<AppUser> userManager, AppUser user)
    {
        return await userManager.RemoveFromRoleAsync(user, "Admin");
    }

    public static async Task<IdentityResult> RemoveFromRoleClientAsync(this UserManager<AppUser> userManager, AppUser user)
    {
        return await userManager.RemoveFromRoleAsync(user, "Client");
    }

    public static async Task<IdentityResult> RemoveFromRoleFreelancerAsync(this UserManager<AppUser> userManager, AppUser user)
    {
        return await userManager.RemoveFromRoleAsync(user, "Freelancer");
    }
}
