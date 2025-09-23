using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using NoteWiki.Models;

namespace NoteWiki.Data
{
    public class MongoContext
    {
    public readonly IConfiguration _configuration;
    public readonly IMongoDatabase? _database;

    public MongoContext(IConfiguration configuration)
    {
        _configuration = configuration;

        var connectionString = _configuration.GetConnectionString("MongoDBConnectionString");
        var mongoUrl = MongoUrl.Create(connectionString);
        var mongoClient = new MongoClient(mongoUrl);
        _database = mongoClient.GetDatabase(mongoUrl.DatabaseName);
    }

        public IMongoDatabase? Database => _database;
    }


}