using ItscEf.DatabaseModels;
using ItscEf.Extensions;
using ItscEf.Repositoies;
using ItscEf.Repositoies.Interface;
using ItscEf.Services;
using ItscEf.Services.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
IConfiguration configuration = builder.Configuration;
builder.Services.AddControllers();
builder.Services.AddDbContext<DatabaseContext>
    (options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRepositories();
builder.Services.AddServices();
//builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
//builder.Services.AddScoped<IEmployeeService, EmployeeService>();


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
