using Services.api.Library.Core.Entities;

namespace Services.api.Library.Repository
{
    public interface IAutorRepository
    {
        Task<IEnumerable<Autor>> GetAutors();
    }
}
