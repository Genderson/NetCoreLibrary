using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Services.api.Library.Core.Entities;

namespace Services.api.Library.Core.ContextMongoDB
{
    public class AutorContext : IAutorContext
    {
        private readonly IMongoDatabase _database;

        public AutorContext(IOptions<MongoSettings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _database = client.GetDatabase(options.Value.Database);
        }
        public IMongoCollection<Autor> Autores => _database.GetCollection<Autor>("Autor");
    }
}
