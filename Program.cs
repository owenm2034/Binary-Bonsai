using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Data.Sqlite;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BonsaiTreeRecord>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("binaryBonsaiDB.db")));
// builder.Services.AddDbContext<MoistureSensorRecord>(options =>
//     options.UseSqlServer(builder.Configuration.GetConnectionString("MoistureSensorRecord") ?? throw new InvalidOperationException("Connection string 'MoistureSensorRecord' not found.")));
builder.Services.AddDbContext<BonsaiTreeRecord>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BonsaiTreeContext") ?? throw new InvalidOperationException("Connection string 'BonsaiTreeContext' not found.")));

// Add services to the container.

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
