using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.api.Library.Core.Entities;
using Services.api.Library.Repository;

namespace Services.api.Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryAutorController : ControllerBase
    {
        private readonly IMongoRepository<AutorEntity> _repository;

        public LibraryAutorController(IMongoRepository<AutorEntity> mongoRepository)
        {
            _repository = mongoRepository;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<AutorEntity>>> Get()
        {
            return Ok(await _repository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AutorEntity>> GetbyIdAsync(string id)
        {
            return Ok(await _repository.GetById(id));
        }

        [HttpPost]
        public async Task PostAsync(AutorEntity autor)
        {
            await _repository.InsertDocument(autor);
        }

        [HttpPut("{id}")]
        public async Task Put(string id, AutorEntity autor)
        {
            autor.Id = id;
            await _repository.UpdateDocument(autor);
        }

        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            await _repository.DeleteById(id);
        }
    }
}
