using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.api.Library.Core.Entities;
using Services.api.Library.Repository;

namespace Services.api.Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceLibraryController : ControllerBase
    {
        private readonly IAutorRepository _autorRepository;

        private readonly IMongoRepository<AutorEntity> _autorGenericoRepository;
        private readonly IMongoRepository<EmpleadoEntity> _empleadoGenericoRepository;

        public ServiceLibraryController(IAutorRepository autorRepository, IMongoRepository<AutorEntity> autorGenericoRepository, IMongoRepository<EmpleadoEntity> empleadoGenericoRepository)
        {
            _autorRepository = autorRepository;
            _autorGenericoRepository = autorGenericoRepository;
            _empleadoGenericoRepository = empleadoGenericoRepository;
        }


        [HttpGet("autores")]
        public async Task<ActionResult<IEnumerable<Autor>>> GetAutores()
        {
            var autores = await _autorRepository.GetAutors();
            return Ok(autores);
        }

        [HttpGet("autorGenerico")]
        public async Task<ActionResult<IEnumerable<AutorEntity>>> GetAutorGenerico()
        {
            var autores = await _autorGenericoRepository.GetAll();
            return Ok(autores);
        }

        [HttpGet("empleados")]
        public async Task<ActionResult<IEnumerable<EmpleadoEntity>>> GetEmpleados()
        {
            var empleados = await _empleadoGenericoRepository.GetAll();
            return Ok(empleados);
        }
    }
}
