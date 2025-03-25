using EmergencyNavigation.Service;
using EmergencyNavigation.Data.Repositories;
using EmergencyNavigation.Core.Services;
using EmergencyNavigation.Core.Repositories;
using EmergencyNavigation.Core;
using EmergencyNavigation.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using EmergencyNavigation.Core.Hubs;
using Microsoft.AspNetCore.SignalR;
using EmergencyNavigation.API.Mapper;

namespace EmergencyNavigation.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                options.JsonSerializerOptions.WriteIndented = true;

            });


            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(Options =>
                {
                    Options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["JWT:Issuer"],
                        ValidAudience = builder.Configuration["JWT:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
                    };

                });



            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(option =>
            {
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Description = "Bearer Authentication with JWT Token",
                    Type = SecuritySchemeType.Http
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                 Id = "Bearer",
                                 Type = ReferenceType.SecurityScheme
                            }
                        },
                        new List<string>()
                    }
                });
            });
            builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAngular", builder =>
                {
                    builder.WithOrigins("http://localhost:4200", "http://localhost:52377", "http://localhost:63027", "https://localhost:63026")
                           .AllowAnyMethod()
                           .AllowAnyHeader()
                           .AllowCredentials();
                });
            });
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IFloorService, FloorService>();
            builder.Services.AddScoped<IFloorRepository, FloorRepository>();
            builder.Services.AddScoped<IBuildingService, BuildingService>();
            builder.Services.AddScoped<IBuildingRepository, BuildingRepository>();
            builder.Services.AddScoped<IEdgeService, EdgeService>();
            builder.Services.AddScoped<IEdgeRepository, EdgeRepository>();
            builder.Services.AddScoped<IVertexServices, VertexService>();
            builder.Services.AddScoped<IVertexRepository, VertexRepository>();
            builder.Services.AddScoped<IVertexCharacterizationService, VertexCharacterizationService>();
            builder.Services.AddScoped<IVertexCharacterizationRepository, VertexCharacterizationRepository>();
            builder.Services.AddScoped<INavigationService, NavigationService>();
            builder.Services.AddScoped<ICommunicationService, CommunicationService>();

            builder.Services.AddSignalR();

            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.MaxDepth = 64; 
            });

            builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(@"Server=DESKTOP-H5F8POA;Database=Emergency_Navigation;TrustServerCertificate=True;Trusted_Connection=True"));
            builder.Services.AddAutoMapper(typeof(BuildingModelMapping));
            builder.Services.AddAutoMapper(typeof(FloorModelMapping));
            builder.Services.AddAutoMapper(typeof(VertexModelMapping));
            builder.Services.AddAutoMapper(typeof(NavigationWithLengthMapper));
            var app = builder.Build();
            app.UseCors("AllowAngular");

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapHub<AlertHub>("/alertHub");

            app.MapControllers();

            app.Run();
        }
    }
}


