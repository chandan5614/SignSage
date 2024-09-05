using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

public class User: IdentityUser
{
    public string id { get; set; }  // Cosmos DB document ID
    public string userId { get; set; }  // User-specific ID (e.g., application-level)

    // Personal and authentication information
    public string Username { get; set; }  // Unique username
    public string Email { get; set; }  // User's email address
    public string PasswordHash { get; set; }  // Hashed password for security
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }  // Optional, for profile purposes

    // User roles and permissions (for RBAC)
    public List<string> Roles { get; set; }  // List of role names assigned to the user
    public List<string> Permissions { get; set; }  // List of explicit permissions granted

    // Metadata for tracking and auditing
    public DateTime CreatedAt { get; set; }  // When the user was created
    public DateTime UpdatedAt { get; set; }  // When the user was last updated
    public bool IsActive { get; set; }  // Active or inactive user account

    // Constructor for initializing default values
    public User()
    {
        id = Guid.NewGuid().ToString();  // Generate a unique id if not provided
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
        IsActive = true;
        Roles = new List<string>();
        Permissions = new List<string>();
    }
}
