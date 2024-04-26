using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver; 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

var client = new MongoClient(app.Configuration.GetConnectionString("MongoDbConnection"));
var database = client.GetDatabase("SearchDb");
var collection = database.GetCollection<Item>("items"); // Replace 'items' with your collection name

await collection.Indexes.CreateOneAsync(new CreateIndexModel<Item>(
    Builders<Item>.IndexKeys
        .Text(x => x.Make)
        .Text(x => x.Model)
        .Text(x => x.Color)));

app.Run();
