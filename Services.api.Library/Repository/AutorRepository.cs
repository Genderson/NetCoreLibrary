using MongoDB.Driver;
using Services.api.Library.Core.ContextMongoDB;
using Services.api.Library.Core.Entities;

namespace Services.api.Library.Repository
{
    public class AutorRepository : IAutorRepository
    {
        private readonly IAutorContext _autorContext;
        public AutorRepository(IAutorContext autorContext)
        {
            _autorContext = autorContext;
        }
        public async Task<IEnumerable<Autor>> GetAutors()
        {
            return await _autorContext.Autores.Find(p => true).ToListAsync();
        }
    }
}
