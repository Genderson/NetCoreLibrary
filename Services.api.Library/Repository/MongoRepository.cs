using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Services.api.Library.Core;
using Services.api.Library.Core.Entities;

namespace Services.api.Library.Repository
{
    public class MongoRepository<TDocument> : IMongoRepository<TDocument> where TDocument : IDocument
    {
        private readonly IMongoCollection<TDocument> _collection;

        public MongoRepository(IOptions<MongoSettings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            var _database = client.GetDatabase(options.Value.Database);

            _collection = _database.GetCollection<TDocument>(GetCollectionName(typeof(TDocument)));
        }

        public async Task<IEnumerable<TDocument>> GetAll()
        {
            return await _collection.Find(p => true).ToListAsync();
        }

        public async Task<TDocument> GetById(string id)
        {
            return await _collection.Find(f => f.Id == id).SingleOrDefaultAsync();
        }

        /// <summary>
        /// Using filters
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        //public async Task<TDocument> GetById(string id)
        //{
        //    var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, id);
        //    return await _collection.Find(filter).SingleOrDefaultAsync();
        //}

        public async Task InsertDocument(TDocument document)
        {
            await _collection.InsertOneAsync(document);
        }

        public async Task UpdateDocument(TDocument document)
        {
            //Other option
            //var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, document.Id);
            //await _collection.FindOneAndReplaceAsync(filter, document);

            await _collection.FindOneAndReplaceAsync(f => f.Id == document.Id, document);
        }

        public async Task DeleteById(string id)
        {
            await _collection.FindOneAndDeleteAsync(f => f.Id == id);
        }

        private protected string GetCollectionName(Type documentType)
        {
            return ((BsonCollectionAttribute)documentType.GetCustomAttributes(typeof(BsonCollectionAttribute), true).FirstOrDefault()).CollectionName;
        }
    }
}
