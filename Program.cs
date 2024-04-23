using CarQuery__Test.Data;
using CarQuery__Test.Domain.Services;
using CarQuery__Test.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<ICarService, CarService>();
builder.Services.AddTransient<IPersonService, PersonService>();
builder.Services.AddTransient<IResellerService, ResellerService>(); 

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=master;TrustServerCertificate=True;Integrated Security=SSPI;");
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
                          policy =>
                          {
                              policy.AllowAnyOrigin()
                                    .AllowAnyHeader()
                                    .AllowAnyMethod();
                          });
});


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();


