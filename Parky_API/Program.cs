using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Parky_API;
using Parky_API.Data;
using Parky_API.ParkyMapper;
using Parky_API.Repository;
using Parky_API.Repository.IRepository;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors();
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




    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {


        Description="JWT",
        Name ="Authorization",
        In= ParameterLocation.Header,
        Type=SecuritySchemeType.ApiKey,
        Scheme= "Bearer"


    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {

        {

            new OpenApiSecurityScheme
            {

                Reference = new OpenApiReference
                {

                    Type = ReferenceType.SecurityScheme,
                    Id="Bearer"

                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
        },
            new List<string>()
        }
    });




}

    );
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefalutConnection")) 
    ) ;


builder.Services.AddScoped<INationalParkRepository, NationalParkRepository>();
builder.Services.AddScoped<ITrailRepository, TrailRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddAutoMapper(typeof(ParkyMappings));
var appSettingsSection = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettingsSection);
var appSettings = appSettingsSection.Get<AppSettings>();
var Key = Encoding.ASCII.GetBytes(appSettings.Secret);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme= JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme= JwtBearerDefaults.AuthenticationScheme;


})

    .AddJwtBearer(x =>
    {

        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Key),
            ValidateIssuer = false,
            ValidateAudience = false


        };

    })
    ;
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

 app.UseCors(x => x
.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader() 

);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
