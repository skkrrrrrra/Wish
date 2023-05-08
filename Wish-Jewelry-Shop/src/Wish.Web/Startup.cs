using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using TeacherToys.Domain.Entities.Identity;
using Wish.Application;
using Wish.Application.Common;
using Wish.Application.Services;
using Wish.Domain.Entities.Identity;
using Wish.Persistence;
using Wish.Persistence.Common;
using Wish.Web.Middlewares;

namespace Wish.Web;

public sealed class Startup
{
	private readonly IConfiguration _configuration;

	public Startup(IConfiguration configuration) => _configuration = configuration;

	public void ConfigureServices(IServiceCollection services)
	{
		var connectionString = _configuration.GetConnectionString("Main");
        services.AddFluentMigrator(
            connectionString,
            typeof(SqlMigration).Assembly);

        PersistenceConfiguration.AddServices(services, connectionString);
        ApplicationConfiguration.AddServices(services);
        AddAuthorizationServices(services);

        services.AddOptions<JwtConfiguration>().BindConfiguration("Jwt");
        services.AddControllers();
		services.AddHealthChecks();
		services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo {
                Title = "Wish API",
                Version = "v1"
            });
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header,

                    },
                    new List<string>()
                }
            });
        });

        services.AddCors(options =>
        {
	        options.AddPolicy("MyAllowedOrigins",
		        policy =>
		        {
			        policy.WithOrigins("http://localhost:4200")
				        .AllowAnyHeader()
				        .AllowAnyMethod();
		        });
        });
	}

	public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
	{
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseCors("MyAllowedOrigins");
        }

        app.UseHealthChecks("/api/health");
		app.UseHttpsRedirection();
		app.UseRouting();
        app.UseAuthentication();
        app.UseCors("MyAllowedOrigins");
        app.UseAuthorization();
        app.UseEndpoints(
		endpoints =>
		{
			endpoints.MapControllers();
		});
	}

    private void AddAuthorizationServices(IServiceCollection services)
    {
        services.AddHttpContextAccessor()
            .AddAuthorization()
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = _configuration["Jwt:Issuer"],
                    ValidAudience = _configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]))
                };
            });
        services.AddIdentityCore<User>()
            .AddRoles<Role>()
            .AddUserManager<UserAccountManager>()
            .AddEntityFrameworkStores<MainDbContext>();
    }
}
