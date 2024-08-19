using esbas_internship_backendproject;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text.Json.Serialization;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);
  
builder.Services.AddAutoMapper(typeof(Program));   
  
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

builder.Services.AddControllers().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.CustomSchemaIds(type => type.ToString());
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ESBAS API", Version = "v1" });
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
    c.SupportNonNullableReferenceTypes();
    c.MapType<object>(() => new OpenApiSchema { Type = "object" });
});

var connectionString = builder.Configuration.GetConnectionString("EsbasDbContext");

builder.Services.AddDbContext<EsbasDbContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("EsbasDbContext") ?? throw new InvalidOperationException("Connection string 'EsbasDbContext' not found in configuration.")));

var app = builder.Build();

app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "ESBAS API");

    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();