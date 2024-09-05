using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using SignSageApi.Models;  // Assuming your custom Role model is here

namespace SignSageApi.Data
{
    public class DataSeeder
    {
        public static async Task SeedRoles(RoleManager<Role> roleManager)
        {
            var roles = new[] { "Admin", "Manager", "SalesRep" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new Role { RoleName = role });
                }
            }
        }
    }
}
