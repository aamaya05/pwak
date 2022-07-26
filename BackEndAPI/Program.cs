using BackEnd.Entities;
using BackEnd.Utilities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PWAKContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
string connString = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<PWAKContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AlessandroTest")));
//string connString = builder.Configuration.GetConnectionString("AlessandroTest");
Util.ConnectionString = connString;

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

app.UseAuthorization();

app.MapControllers();

app.Run();
