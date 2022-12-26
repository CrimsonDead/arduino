using backLayer;
using dataLayer.Context;
using dataLayer.Models;
using dataLayer.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

string connection = builder.Configuration.GetConnectionString("DefaultConnections");
builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseSqlServer(connection);
    //sqlServerOptionsAction: sqlOptions =>
    //{
    //    sqlOptions.EnableRetryOnFailure();
    //};
});

builder.Services.AddScoped<IRepository<Region>, RegionRepository>();
builder.Services.AddScoped<IRepository<Sensor>, SensorRepository>();
builder.Services.AddScoped<IRepository<SensorData>, SensorDataRepository>();
//builder.Services.AddHostedService<EmailService>();

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
