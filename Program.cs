
using Day_41_FoodOrderingApp.Data;
using Day_41_FoodOrderingApp.Model;
using Day_41_FoodOrderingApp.Repository;
using Day_41_FoodOrderingApp.Service;
using Day_41_FoodOrderItemingApp.Repository;
using Microsoft.EntityFrameworkCore;

namespace Day_41_FoodOrderingApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<DbContextFoodApp>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IMenuItemRepository, MenuItemRepository>();
            builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            builder.Services.AddScoped<IMenuItemRepository,MenuItemRepository>();
            builder.Services.AddScoped<IDeliveryPartnerRepository, DeliveryPartnerRepository>();
            builder.Services.AddScoped<IPaymentMethodRepository, PaymentMethodRepository>() ;
            builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            builder.Services.AddScoped<IDeliveryPartnerService, DeliveryPartnerService>();
            builder.Services.AddScoped<IInvoiceService, InvoiceService>();
            builder.Services.AddScoped<IMenuItemService, MenuItemService>();
            builder.Services.AddScoped<IPaymentMethodService, PaymentMethodService>();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
