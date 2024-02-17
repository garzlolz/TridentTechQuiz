using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using TridentTech.DBModels;
using TridentTech.Services.ApiService;
using TridentTech.Services.GeneralService;
using TridentTech.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var connString = builder.Configuration.GetConnectionString("TridentTech");
builder.Services.AddDbContext<TridentTechContext>(option =>
{
    option.UseSqlServer(connString, options =>
    {
    });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
_ = builder.Services.AddSwaggerGen(swagger =>
{
    //±Ò¥ÎSwaggerResponseµù¸Ñ
    swagger.EnableAnnotations();

    swagger.SwaggerDoc("v1", new OpenApiInfo()
    {
        Title = "TridentTech",
        Version = "v1"
    });

    // To Enable authorization using Swagger (JWT)    
    swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
    });

    swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
        });

    var apiXmlPath = Path.Combine(AppContext.BaseDirectory, "TridentTech.xml");
    swagger.IncludeXmlComments(apiXmlPath);
});

#region JWT
var key = builder.Configuration.GetValue<string>("JwtSettings:SignKey");
var jwtSignKey = Encoding.UTF8.GetBytes(key);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        IssuerSigningKey = new SymmetricSecurityKey(jwtSignKey),
        ValidateIssuerSigningKey = true,
        ValidateIssuer = false,
        ValidateAudience = false
    };
});
#endregion

builder.Services.AddScoped<ITeacherService, TeacherService>();
builder.Services.AddScoped<IClassService, ClassService>();
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<ILoginService, LoginService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
