using CarQuery__Test.Data;
using CarQuery__Test.Domain.Models;
using CarQuery__Test.Domain.Services;
using CarQuery__Test.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<ICarService, CarService>();
builder.Services.AddTransient<IPersonService, PersonService>();
builder.Services.AddTransient<IResellerService, ResellerService>();
builder.Services.AddTransient<ISaleService, SaleService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API - Car", Version = "v1" });
});

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer("Data Source=DESKTOP-KCR988O\\SQLEXPRESS;Initial Catalog = API-Car;Integrated Security = True;TrustServerCertificate=True;Encrypt=False");
    //options.UseSqlServer("Data Source=DESKTOP-SE0OT65\\SQLEXPRESS;Initial Catalog=API-Car;Integrated Security=True;TrustServerCertificate=True");
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

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API - Car");
        c.DocumentTitle = "API - Car";
        c.RoutePrefix = string.Empty;
    });
}

// Configure the HTTP request pipeline.

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();


