using DotNetEnv; // Import the DotNetEnv namespace
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SignSageApi.Data;
using SignSageApi.Models;
using System.Text;

// Load .env file
Env.Load();

var builder = WebApplication.CreateBuilder(args);

// Get environment variables for Cosmos DB and JWT keys
var cosmosEndpoint = Environment.GetEnvironmentVariable("COSMOS_DB_ENDPOINT");
var cosmosKey = Environment.GetEnvironmentVariable("COSMOS_DB_KEY");
var jwtKey = Environment.GetEnvironmentVariable("JWT_KEY");

if (string.IsNullOrEmpty(cosmosEndpoint) || string.IsNullOrEmpty(cosmosKey) || string.IsNullOrEmpty(jwtKey))
{
    throw new InvalidOperationException("Environment variables for Cosmos DB or JWT are not set.");
}

// Configure JWT Authentication
var key = Encoding.ASCII.GetBytes(jwtKey);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

// Configure Cosmos DB
builder.Services.AddSingleton<CosmosClient>(sp =>
{
    return new CosmosClient(cosmosEndpoint, cosmosKey); // Uses environment variables
});

// Configure Identity
builder.Services.AddIdentity<User, Role>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = true;
})
.AddRoleManager<RoleManager<Role>>()
.AddSignInManager<SignInManager<User>>()
.AddDefaultTokenProviders();

builder.Services.AddScoped<IUserStore<User>, CosmosUserStore>();
builder.Services.AddScoped<IRoleStore<Role>, CosmosRoleStore>();

// Configure containers
builder.Services.AddScoped(sp =>
{
    var client = sp.GetRequiredService<CosmosClient>();
    return client.GetContainer("signsagedb", "AuditLogs");
});

builder.Services.AddScoped(sp =>
{
    var client = sp.GetRequiredService<CosmosClient>();
    return client.GetContainer("signsagedb", "Customers");
});

builder.Services.AddScoped(sp =>
{
    var client = sp.GetRequiredService<CosmosClient>();
    return client.GetContainer("signsagedb", "Documents");
});

builder.Services.AddScoped(sp =>
{
    var client = sp.GetRequiredService<CosmosClient>();
    return client.GetContainer("signsagedb", "Renewals");
});

builder.Services.AddScoped(sp =>
{
    var client = sp.GetRequiredService<CosmosClient>();
    return client.GetContainer("signsagedb", "Signatures");
});

builder.Services.AddScoped(sp =>
{
    var client = sp.GetRequiredService<CosmosClient>();
    return client.GetContainer("signsagedb", "Templates");
});

builder.Services.AddScoped(sp =>
{
    var client = sp.GetRequiredService<CosmosClient>();
    return client.GetContainer("signsagedb", "Users");
});

builder.Services.AddScoped(sp =>
{
    var client = sp.GetRequiredService<CosmosClient>();
    return client.GetContainer("signsagedb", "Roles");
});

// Configure Identity
builder.Services.AddIdentityCore<User>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
})
.AddRoles<Role>()
.AddDefaultTokenProviders();

// Configure Authorization
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));
    options.AddPolicy("ManagerPolicy", policy => policy.RequireRole("Manager"));
    options.AddPolicy("SalesRepPolicy", policy => policy.RequireRole("SalesRep"));
});

// Register JwtTokenGenerator in DI
builder.Services.AddScoped<JwtTokenGenerator>();

// Add Swagger and API documentation
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.RoutePrefix = "swagger";
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "SignSage API V1");
    });
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// Seed roles in a separate scope
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();
    await DataSeeder.SeedRoles(roleManager);
}

app.Run();
