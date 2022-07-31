using MongoDB.Driver;
using Services.api.Library.Core.Entities;

namespace Services.api.Library.Core.ContextMongoDB
{
    public interface IAutorContext
    {
        IMongoCollection<Autor> Autores { get; }

    }
}
