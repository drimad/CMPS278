namespace api.Modules.Auth.Models;

public class UserDto
{
    public string DisplayName { get; set; } = default!;
    public string Token { get; set; } = default!;
    public string Image { get; set; } = default!;
    public IList<string> Roles { get; set; } = new List<string>();
}
