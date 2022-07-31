using Services.api.Library.Core.Entities;
using System.Linq.Expressions;

namespace Services.api.Library.Repository
{
    public interface IMongoRepository<TDocument> where TDocument : IDocument
    {
        Task<IEnumerable<TDocument>> GetAll();
        Task<TDocument> GetById(string id);
        Task InsertDocument(TDocument document);
        Task UpdateDocument(TDocument document);
        Task DeleteById(string id);
        PaginationEntity<TDocument> GetPaginationBy(Expression<Func<TDocument, bool>> filterExpression, PaginationEntity<TDocument> pagination);
    }
}
