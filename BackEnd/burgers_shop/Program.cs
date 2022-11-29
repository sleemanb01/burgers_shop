
using BurgersShop.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
	{
	    options.AddDefaultPolicy(
	        policy =>
	        {
	            policy.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
	        });
	});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BurgerShopContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BurgerShopContext") ?? throw new InvalidOperationException("Connection string 'BurgerShopContext' not found.")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(builder => builder
     .AllowAnyOrigin()
     .AllowAnyMethod()
     .AllowAnyHeader());
app.UseAuthorization();

app.MapControllers();

app.Run();
