using Day_41_FoodOrderingApp.Data;
using Day_41_FoodOrderingApp.Model;
using Day_41_FoodOrderingApp.Repository;
using Day_41_FoodOrderingApp.Service;
using Day_41_FoodOrderItemingApp.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace Day_41_FoodOrderingApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;

            // 1. Configure DbContext
            builder.Services.AddDbContext<DbContextFoodApp>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // 2. Register Repositories
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IMenuItemRepository, MenuItemRepository>();
            builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            builder.Services.AddScoped<IDeliveryPartnerRepository, DeliveryPartnerRepository>();
            builder.Services.AddScoped<IPaymentMethodRepository, PaymentMethodRepository>();
            builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            // 3. Register Services
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IDeliveryPartnerService, DeliveryPartnerService>();
            builder.Services.AddScoped<IInvoiceService, InvoiceService>();
            builder.Services.AddScoped<IMenuItemService, MenuItemService>();
            builder.Services.AddScoped<IPaymentMethodService, PaymentMethodService>();
            builder.Services.AddScoped<IAuthService, AuthService>();

            // 4. Add Controllers
            builder.Services.AddControllers();

            // 5. Configure Authentication (JWT)
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("Jwt:Key").Value)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            // 6. Configure Swagger/OpenAPI with JWT Support
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Food Ordering App API",
                    Description = "API for managing food orders, users, and deliveries."
                });

                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description = "Enter JWT Bearer token **_only_**",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };

                options.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { securityScheme, new string[] { } }
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

           
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}