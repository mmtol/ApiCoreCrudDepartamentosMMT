using ApiCoreCrudDepartamentosMMT.Models;
using ApiCoreCrudDepartamentosMMT.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ApiCoreCrudDepartamentosMMT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentosController : ControllerBase
    {
        private RepositoryDepartamentos repo;

        public DepartamentosController(RepositoryDepartamentos repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Departamento>>> GetDepartamentos()
        {
            return await repo.GetDepartamentosAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Departamento>> FindDepartamento(int id)
        {
            return await repo.FindDepartamentoAsync(id);
        }

        //los metodos por defecto como post reciben un obj
        //si necesitamos personalizarlos, debemos utilizar routing
        [HttpPost]
        public async Task<ActionResult> PostDepartamento(Departamento dept)
        {
            await repo.PostDepartamentoAsync(dept.IdDepartamento, dept.Nombre, dept.Localidad);
            return Ok();
        }

        //creamos otro metodo para insertar con routing
        [HttpPost]
        [Route("[action]/{id}/{nombre}/{localidad}")]
        public async Task<ActionResult> PostDepartamentoRouting(Departamento dept)
        {
            await repo.PostDepartamentoAsync(dept.IdDepartamento, dept.Nombre, dept.Localidad);
            return Ok();
        }
    }
}
