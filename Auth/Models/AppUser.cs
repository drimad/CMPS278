using api.Data;
using api.Modules.Profiles.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Modules.Auth.Models;

public class AppUser : IdentityUser
{
    public ClientProfile? ClientProfile { get; set; }
    public SalonOwnerProfile? SalonOwnerProfile { get; set; }
}

public class AppUserConfig : IEntityTypeConfiguration<AppUser>
{
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<AppUser> _userManage;
    public AppUserConfig(UserManager<AppUser> userManage, RoleManager<IdentityRole> roleManager)
    {
        _userManage = userManage;
        _roleManager = roleManager;
    }
    public async void Configure(EntityTypeBuilder<AppUser> entity)
    {
        if (!_roleManager.Roles.Any())
        {
            await _roleManager.CreateAsync(new IdentityRole("Superadmin"));
            await _roleManager.CreateAsync(new IdentityRole("Admin"));
            await _roleManager.CreateAsync(new IdentityRole("Client"));
            await _roleManager.CreateAsync(new IdentityRole("Freelancer"));
        }

        if (!_userManage.Users.Any())
        {
            var users = new List<AppUser>
            {
                new() { Email = "superadmin@taomedia.io" },
                new() { Email = "admin@taomedia.io" },
                new() { Email = "client@taomedia.io" },
                new() { Email = "freelancer@taomedia.io" }
            };
            foreach (var user in users)
                await _userManage.CreateAsync(user, "1234");

            var u = await _userManage.FindByEmailAsync("superadmin@taomedia.io");
            await _userManage.AddToRoleSuperAdminAsync(u);

            u = await _userManage.FindByEmailAsync("admin@taomedia.io");
            await _userManage.AddToRoleAdminAsync(u);

            u = await _userManage.FindByEmailAsync("client@taomedia.io");
            await _userManage.AddToRoleClientAsync(u);

            u = await _userManage.FindByEmailAsync("freelancer@taomedia.io");
            await _userManage.AddToRoleFreelancerAsync(u);
        }


    }
}
