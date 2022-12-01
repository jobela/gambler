using Gambler.PoC.Data;
using Gambler.PoC.Middleware;
using Gambler.PoC.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options => 
    options.UseSqlServer("Server=.\\SQLExpress;Database=GamblerDb;Trusted_Connection=true;;TrustServerCertificate=True"));

//builder.Services.AddScoped<ISuperHeroRepository, SuperHeroRepository>();
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

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Nah, don't use it!
//app.UseMiddleware<ApiKeyMiddleware>();

app.UseCors("MyAllowAllCORSPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
