using BeeShop_API.BusinessLogic;
using BeeShop_API.BusinessLogic.Contracts;
using BeeShop_API.DataAccess;
using BeeShop_API.Repositories;
using BeeShop_API.Repositories.Contracts;
using BeeShop_API.Repositories.Contracts.Mappers;
using BeeShop_API.Repositories.Mappers;
using BeeShop_API.Services;
using BeeShop_API.Services.Contracts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using BeeShop_API.Services.Contracts.Google;
using BeeShop_API.Services.Google;
using NReco.Logging.File;
using BeeShop_API.DataAccess.Provider;

namespace BeeShop_API.DI
{
    public static class DependencyResolver
    {
        public static ServiceProvider RegisterServices(IServiceCollection services)
        {
            var configurationRoot = LoadConfiguration();
            services.AddSingleton<IConfiguration>(configurationRoot);

            services.AddHttpClient();

            var connectionString = configurationRoot.GetConnectionString("ConnectionString");
            DataProvider.ConnectString = connectionString;
            services.AddDbContext<DataContext>(options =>
            {
                ServiceProvider sp = services.BuildServiceProvider();
                options.UseSqlServer(connectionString);
            });

            #region Services
            services.AddScoped<ICryptoService, CryptoService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IRecaptchaV2Service, RecaptchaV2Service>();
            services.AddScoped<IRecaptchaV3Service, RecaptchaV3Service>();
            #endregion

            #region Mappers
            //services.AddScoped<IUserMapper, UserMapper>();
            //services.AddScoped<IUserSessionMapper, UserSessionMapper>();
            //services.AddScoped<IProductCategoriesMapper, ProductCategoriesMapper>();
            #endregion

            #region Repositories
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IUserSessionsRepository, UserSessionsRepository>();
            services.AddScoped<IProductCategoriesRepository, ProductCategoriesRepository>();
            services.AddScoped<IUserRolesRepository, UserRolesRepository>();
            services.AddScoped<IRolesRepository, RolesRepository>();
            services.AddScoped<IRunFunctionRepository, RunFunctionRepository>();
            #endregion

            #region BusinessLogics
            services.AddScoped<IAuthBusinessLogic, AuthBusinessLogic>();
            services.AddScoped<IProductCategoriesBusinessLogic, ProductCategoriesBusinessLogic>();
            services.AddScoped<IUserRolesBusinessLogic, UserRolesBusinessLogic>();
            services.AddScoped<IRolesBusinessLogic, RolesBusinessLogic>();
            services.AddScoped<IRunFunctionBusinessLogic, RunFunctionBusinessLogic>();
            #endregion

            return services.BuildServiceProvider();
        }

        public static void AddSwagger(IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo { Title = "BeeShop API", Version = "v1" });
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
            });
        }

        public static void AddAuthentication(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "bearer";
            }).AddJwtBearer("bearer", options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("Authentication:Token:ServerSigningPassword").Get<string>())),
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };

                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            context.Response.StatusCode = 401;
                            context.Response.Headers.Add("Token-Expired", "true");
                        }
                        return Task.CompletedTask;
                    }
                };
            });
        }

        public static void AddLogging(IServiceCollection services)
        {
            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddFile("Logs/app_{0:yyyy}-{0:MM}-{0:dd}.log", fileLoggerOpts =>
                {
                    fileLoggerOpts.FormatLogFileName = fName =>
                    {
                        return String.Format(fName, DateTime.UtcNow);
                    };
                    fileLoggerOpts.FormatLogEntry = (msg) =>
                    {
                        var sb = new System.Text.StringBuilder();
                        StringWriter sw = new StringWriter(sb);
                        var jsonWriter = new Newtonsoft.Json.JsonTextWriter(sw);
                        jsonWriter.WriteStartArray();
                        jsonWriter.WriteValue(DateTime.Now.ToString("o"));
                        jsonWriter.WriteValue(msg.LogLevel.ToString());
                        jsonWriter.WriteValue(msg.LogName);
                        jsonWriter.WriteValue(msg.EventId.Id);
                        jsonWriter.WriteValue(msg.Message);
                        jsonWriter.WriteValue(msg.Exception?.ToString());
                        jsonWriter.WriteEndArray();
                        return sb.ToString();
                    };
                });
            });
        }

        private static IConfigurationRoot LoadConfiguration()
        {
            var jsonFile = "appsettings.json";
            try
            {
                if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")?.ToLower() == "development")
                {
                    jsonFile = "appsettings.Development.json";
                }
            }
            catch { }

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(jsonFile, true, true);

            var configuration = builder.Build();
            return configuration;
        }
    }
}
