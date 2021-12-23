using blog_api.DbContexts;
using blog_api.Models;
using blog_api.Repositories.Implementations;
using blog_api.Repositories.Interfaces;
using blog_api.Services.Implementations.Auth;
using blog_api.Services.Implementations.Categories;
using blog_api.Services.Implementations.Tokens;
using blog_api.Services.Implementations.Users;
using blog_api.Services.Interfaces;
using blog_api.Services.Interfaces.Articles;
using blog_api.Services.Interfaces.Auth;
using blog_api.Services.Interfaces.Categories;
using blog_api.Services.Interfaces.Tokens;
using blog_api.Services.Interfaces.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Get Connection string

string URI = builder.Configuration.GetConnectionString("Default_Connection");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

// Auth Configurations

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
        ValidateAudience = false,
        ValidateIssuer = false,
        ValidateLifetime = true,
    };
});

//Inject Db Context
builder.Services.AddDbContext<BlogContext>((DbContextOptionsBuilder options) => options.UseNpgsql(URI));
builder.Services.AddScoped<IBlogContext, BlogContext>();

//Inject Repositories
builder.Services.AddScoped<IArticleRepository, ArticleRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

//Inject Services
builder.Services.AddScoped<IArticleService, ArticleService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IUserPasswordService, UserPasswordService>();
builder.Services.AddScoped<IUserInfosUpdatorService, UserInfosUpdatorService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();


var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(options => options.AllowAnyOrigin());

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
