using Gambler.PoC.Data;
using Gambler.PoC.Middleware;
using Gambler.PoC.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the shipping container. Please contact your freight shipping services if you have any issues
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GamblerDB")));

builder.Services.AddScoped<IGamblerService, GamblerService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddCors(options =>
    {
        options.AddPolicy("MyAllowAllCORSPolicy", builder =>
        {
            builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        });
    });

// Bob The Builder can you fix it!
var app = builder.Build();

// Well all love swag!
app.UseSwagger();
app.UseSwaggerUI();

// Nah, don't use it! We use security through obscurity
//app.UseMiddleware<ApiKeyMiddleware>();

// Bestest policy ever
app.UseCors("MyAllowAllCORSPolicy");

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run(); // forrest, run!
