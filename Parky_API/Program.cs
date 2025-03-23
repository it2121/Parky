using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Parky_API.Data;
using Parky_API.ParkyMapper;
using Parky_API.Repository;
using Parky_API.Repository.IRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // Space
    c.SwaggerDoc("NatonalParks",
        new OpenApiInfo { Title = "NatonalParks Api", Version = "v1" });

    // Access
    c.SwaggerDoc("Trails",
        new OpenApiInfo { Title = "Trails Api", Version = "v1" });

}

    );
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefalutConnection")) 
    ) ;


builder.Services.AddScoped<INationalParkRepository, NationalParkRepository>();
builder.Services.AddScoped<ITrailRepository, TrailRepository>();
builder.Services.AddAutoMapper(typeof(ParkyMappings));





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(
        options =>
        {

            options.ShowCommonExtensions();

            options.SwaggerEndpoint("NatonalParks/swagger.json", "NatonalParks");
            options.SwaggerEndpoint("Trails/swagger.json", "Trails Api");
        }
        
        );
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
