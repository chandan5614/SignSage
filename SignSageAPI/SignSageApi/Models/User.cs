using Microsoft.AspNetCore.Identity;

public class User : IdentityUser
{
    public string id { get; set; }
    public string userId { get; set; }

    public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime? DateOfBirth { get; set; }

    public List<string> Roles { get; set; }
    public List<string> Permissions { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsActive { get; set; }

    public User()
    {
        id = Guid.NewGuid().ToString();
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
        IsActive = true;
        Roles = new List<string>();
        Permissions = new List<string>();
    }
}
