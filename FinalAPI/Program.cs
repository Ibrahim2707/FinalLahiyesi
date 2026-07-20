using AutoMapper;
using CloudinaryDotNet;

using Final.BL;
using Final.BL.ExternalServices.Abstracts;
using Final.BL.ExternalServices.implements;
using Final.Core.Entities;
using Final.DAL;
using Final.DAL.Contexts;
using FinalAPI.Middlewares;
using FinalAPI.Profiles;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<CloudinarySettings>(
builder.Configuration.GetSection("CloudinarySettings"));
builder.Services.AddAutoMapper(cfg => { }, typeof(Program).Assembly);
builder.Services.AddFluentValidation();
builder.Services.AddServices();
builder.Services.AddRepositories();
builder.Services.AddScoped<IFileService, FileService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<FinalDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("MsSql"),
 sqlOptions =>
 {
     sqlOptions.EnableRetryOnFailure();
 })); 
var app = builder.Build();

//app.UseMiddleware<ExceptionMiddleware>();

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
