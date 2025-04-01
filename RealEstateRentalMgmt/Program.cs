
namespace RealEstateRentalMgmt;
using Microsoft.EntityFrameworkCore;
using RealEstateRentalMgmt.Data;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();

        // ??c chu?i k?t n?i t? appsettings.json
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

        // ??ng ký AppDbContext v?i MySQL
        builder.Services.AddDbContext<AppDbContext>(options =>
        {
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            options.EnableSensitiveDataLogging(); // T??ng ?ng v?i spring.jpa.show-sql = true
            options.EnableDetailedErrors(); // Hi?n th? l?i chi ti?t khi debug
        });

        // ??ng ký các repository
        builder.Services.AddScoped<BuildingRepository>();
        builder.Services.AddScoped<DistrictRepository>();
        builder.Services.AddScoped<RentAreaRepository>();

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
