using OpenAI;
using OpenAI.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenAI.Managers;


var builder = WebApplication.CreateBuilder(args);

// Load API Key from configuration
var apiKey = builder.Configuration["OpenAI:ApiKey"];
if (string.IsNullOrEmpty(apiKey))
{
    throw new Exception("OpenAI API Key is missing.");
}

// Register OpenAI Service
builder.Services.AddSingleton<IOpenAIService, OpenAIService>(_ => new OpenAIService(new OpenAiOptions
{
    ApiKey = apiKey
}));


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
