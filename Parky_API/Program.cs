using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Parky_API.Data;
using Parky_API.ParkyMapper;
using Parky_API.Repository;
using Parky_API.Repository.IRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefalutConnection")) 
    ) ;


builder.Services.AddScoped<INationalParkRepository, NationalParkRepository>();
builder.Services.AddAutoMapper(typeof(ParkyMappings));





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
