using CarQuery__Test.Data;
using CarQuery__Test.Domain.Services;
using CarQuery__Test.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<ICarService, CarService>();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=master;TrustServerCertificate=True;Integrated Security=SSPI;");
    //options.UseSqlServer("Data Source=PCKMB003;User ID=sa;Password=Giovanni123;TrustServerCertificate=True");
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
