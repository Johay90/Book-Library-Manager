using Book_Library_Manager.Core.Mapping;
using Book_Library_Manager.Core.Models.DTOs;
using Book_Library_Manager.Core.Validations;
using Book_Library_Manager.Data;
using Book_Library_Manager.Data.Repositories;
using Book_Library_Manager.Interfaces;
using Book_Library_Manager.Services;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BookLibraryManagerContext>();

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IValidator<BookDto>, BookValidator>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

var app = builder.Build();

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
