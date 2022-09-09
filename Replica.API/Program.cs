using Business.Abstracts;
using Business.Profiles;
using DataAccess.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using NLog;
using Replica.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ReplicaAPI"));
    options.UseLazyLoadingProxies(true);
});

LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

builder.Services.AddMemoryCache();

builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers().AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(IProfile).Assembly);

builder.Services.AddRepositoryServices();
builder.Services.AddBusinessServices();

var app = builder.Build();

app.ConfigureExceptionHandler(app.Services.GetRequiredService<ILoggerService>());

if (app.Environment.IsProduction())
    app.UseHsts();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<RequestResponseMiddleware>();

app.MapControllers();

app.Run();
