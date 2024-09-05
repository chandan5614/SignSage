using Microsoft.AspNetCore.Identity;

public class Role: IdentityRole
{
    public string id { get; set; }
    public string RoleName { get; set; }
    public IEnumerable<string> Permissions { get; set; }
}
