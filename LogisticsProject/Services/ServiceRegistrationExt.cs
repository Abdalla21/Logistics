using AspNetCoreRateLimit;
using LogisticsDataCore.Constants;
using LogisticsDataCore.Constants.ServicesConstants;
using LogisticsEntity.DBContext;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

namespace LogisticsProject.Services
{
    public static class ServiceRegistrationExt
    {

        public static IServiceCollection AddRateLimitService(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddMemoryCache();
            services.Configure<IpRateLimitOptions>(configuration.GetSection(GlobalConstants.RateLimitFirstConfigurationName));
            services.Configure<IpRateLimitPolicies>(configuration.GetSection(GlobalConstants.RateLimitSecondConfigurationName));
            services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();
            services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();

            return services;
        }

        public static IServiceCollection AddDBContextService(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDbContext<ApplicationDBContext>(
                options => options.UseSqlServer(
                    configuration.GetConnectionString(GlobalConstants.DBConnectionName)));

            return services;
        }

        public static IServiceCollection AddCORSService(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
            });

            return services;
        }

        public static IServiceCollection AddJWTService(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(
                                configuration.GetSection(
                                    JWTConstants.SectionName)
                                .Value!)
                            ),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            return services;
        }

        public static IServiceCollection AddSwaggerService(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition(SwaggerConstants.SecurityName, new OpenApiSecurityScheme
                {
                    Description = SwaggerConstants.Description,
                    In = ParameterLocation.Header,
                    Name = SwaggerConstants.AuthorizationHeaderName,
                    Type = SecuritySchemeType.ApiKey
                });
                options.OperationFilter<SecurityRequirementsOperationFilter>();
            });

            return services;
        }

    }
}
