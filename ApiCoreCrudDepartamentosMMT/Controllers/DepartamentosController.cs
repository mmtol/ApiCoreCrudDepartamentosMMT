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
        public async Task<ActionResult> PostDepartamento(int id, string nombre, string localidad)
        {
            await repo.PostDepartamentoAsync(id, nombre, localidad);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> PutDepartamento(Departamento dept)
        {
            await repo.PutDepartamentoAsync(dept.IdDepartamento, dept.Nombre, dept.Localidad);
            return Ok();
        }

        //en los metodos put tambien podemos recibir el id a modificar
        //si recibimos parametros el obj es el ultimo en declararse
        [HttpPut]
        [Route("[action]/{id}")]
        public async Task<ActionResult> PutDepartamento(int id, Departamento dept)
        {
            await repo.PutDepartamentoAsync(id, dept.Nombre, dept.Localidad);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await repo.DeleteDepartamentoAsync(id);
            return Ok();
        }
    }
}
