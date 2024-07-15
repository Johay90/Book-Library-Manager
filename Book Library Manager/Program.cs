using Book_Library_Manager.Core.Mapping;
using Book_Library_Manager.Core.Models.DTOs;
using Book_Library_Manager.Core.Validations;
using Book_Library_Manager.Data;
using Book_Library_Manager.Data.Repositories;
using Book_Library_Manager.Interfaces;
using Book_Library_Manager.Services;
using FluentValidation;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BookLibraryManagerContext>();

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IValidator<BookDto>, BookValidator>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddHealthChecks()
    .AddDbContextCheck<BookLibraryManagerContext>("database");

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Books API", Version = "v1" });

    c.CustomOperationIds(apiDesc =>
    {
        return apiDesc.TryGetMethodInfo(out MethodInfo methodInfo)
            ? methodInfo.Name
            : null;
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = async (context, report) =>
    {
        context.Response.ContentType = "application/json";

        var response = new
        {
            Status = report.Status.ToString(),
            Checks = report.Entries.Select(e => new
            {
                Component = e.Key,
                Status = e.Value.Status.ToString(),
                Description = e.Value.Description
            }),
            TotalDuration = report.TotalDuration
        };

        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
});

app.Run();
