using BusinessLayer.Authentication;
using BusinessLayer.Authentication_;
using BusinessLayer.IntegrationsConfigurations.PayPal;
using BusinessLayer.Profiles;
using ClinicAPI.Global;
using ClinicAPI.Middlewares;
using DataLayer.Data;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<PayPalSettings>(
    builder.Configuration.GetSection("PayPal"));
builder.Services.AddScoped<clsPayPal>();







//builder.Services.AddAuthentication()
//    .AddGoogle(options =>
//    {
//        options.ClientId = "943599975071-erabakvmicodh616cnjp91lgdsmthbhp.apps.googleusercontent.com";
//        options.ClientSecret = "****CxPw";
//        options.CallbackPath = "/signin-google"; // ???? ????? ???? ????? ?? Google
//    });

//builder.Services.Add<DataLayer.Contract.IClinicRepository>()
try
{
    
var configuration = builder.Configuration;

    
    builder.Services.AddDbContext<Clinicdbcontext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("constr")));

    
    builder.Services.AddAutoMapper(typeof(Profiles));

    builder.Services.AddSingleton<JWTAuthentication>(sp =>
    {
        var jwtSection = builder.Configuration.GetSection("Jwt");
        var key = jwtSection["singinkey"];
        var audience = jwtSection["Audience"];
        var issuer = jwtSection["Issuer"];

        return new JWTAuthentication(key, audience, issuer);
    });

    builder.Services.AddProjectDependencies();

    var jwtSection = builder.Configuration.GetSection("Jwt");

    builder.Services.AddAuthentication("Bearer")
      .AddJwtBearer(options =>
      {
         

          options.TokenValidationParameters = new TokenValidationParameters
          {
              ValidateIssuer = true,
              ValidateAudience = true,
              ValidateLifetime = true,
              ValidateIssuerSigningKey = true,

              ValidIssuer = jwtSection["Issuer"],
              ValidAudience = jwtSection["Audience"],
              IssuerSigningKey = new SymmetricSecurityKey(
                  Encoding.UTF8.GetBytes(jwtSection["singinkey"])
              )
          };
      });

    builder.Services.AddAuthorization();
    
    var app = builder.Build();



 
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseMiddleware<RateTime_MW>();
    app.UseHttpsRedirection();

    app.UseAuthentication();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine($"Unhandled exception: {ex.Message}");
}