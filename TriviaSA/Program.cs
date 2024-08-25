using MongoDB.Driver;
using TriviaSA.Application.Services;
using TriviaSA.Core.Entities;
using TriviaSA.Core.Interfaces;
using TriviaSA.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

var mongoConnectionString = builder.Configuration["MongoDb:ConnectionString"];
var mongoDatabaseName = builder.Configuration["MongoDb:DatabaseName"];
var mongoCollectionName = builder.Configuration["MongoDb:CollectionName"];

builder.Services.AddControllers();
var mongoClient = new MongoClient(mongoConnectionString);
var mongoDatabase = mongoClient.GetDatabase(mongoDatabaseName);
var mongoCollection = mongoDatabase.GetCollection<Questions>(mongoCollectionName);
builder.Services.AddSingleton(mongoCollection);

builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
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
