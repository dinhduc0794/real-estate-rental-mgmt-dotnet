
namespace RealEstateRentalMgmt;
using Microsoft.EntityFrameworkCore;
using RealEstateRentalMgmt.Data;
using RealEstateRentalMgmt.Services.Converters;
using RealEstateRentalMgmt.Services;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();

        // Đọc chuỗi kết nối từ appsettings.json
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

        // Đăng ký AppDbContext với MySQL
        builder.Services.AddDbContext<AppDbContext>(options =>
        {
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            options.EnableSensitiveDataLogging();
            options.EnableDetailedErrors();
        });

        // Đăng ký các service và converter
        builder.Services.AddScoped<IBuildingService, BuildingService>();
        builder.Services.AddScoped<BuildingConverter>();
        builder.Services.AddScoped<BuildingSearchBuilderConverter>();

        // Đăng ký các repository
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
