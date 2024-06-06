using APBD8_pracadomowaa.Data;
using APBD8_pracadomowaa.Repositories;
using APBD8_pracadomowaa.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddDbContext<Apbd8Context>(
    options => options.UseSqlServer("Name=ConnectionStrings:Default"));

builder.Services.AddScoped<TripRepository>();
builder.Services.AddScoped<TripServices>();
builder.Services.AddScoped<ClientRepository>();
builder.Services.AddScoped<ClientServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseHttpsRedirection();


app.Run();

