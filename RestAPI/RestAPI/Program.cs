using Microsoft.EntityFrameworkCore;
using RestAPI.Model.Context;
using RestAPI.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IPersonService, PersonServiceImplementation>();

// Add connections
var configuration = builder.Configuration["ConnectionStrings:MySQL"];
builder.Services.AddDbContext<MySQLContext>(op => op.UseMySql(configuration, new MySqlServerVersion(new Version(9, 4, 0))));

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
