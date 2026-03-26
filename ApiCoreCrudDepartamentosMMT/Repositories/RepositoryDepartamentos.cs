using ApiCoreCrudDepartamentosMMT.Data;
using ApiCoreCrudDepartamentosMMT.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCoreCrudDepartamentosMMT.Repositories
{
    public class RepositoryDepartamentos
    {
        private DepartamentosContext context;

        public RepositoryDepartamentos(DepartamentosContext context)
        {
            this.context = context;
        }

        public async Task<List<Departamento>> GetDepartamentosAsync()
        {
            return await context.Departamentos.ToListAsync();
        }

        public async Task<Departamento> FindDepartamentoAsync(int id)
        {
            return await context.Departamentos.FirstOrDefaultAsync(z => z.IdDepartamento == id);
        }

        public async Task PostDepartamentoAsync(int idDepartamento, string nombre, string localidad)
        {
            Departamento dept = new Departamento();
            dept.IdDepartamento = idDepartamento;
            dept.Nombre = nombre;
            dept.Localidad = localidad;

            await context.Departamentos.AddAsync(dept);
            await context.SaveChangesAsync();
        }

        public async Task PutDepartamentoAsync(int idDepartamento, string nombre, string localidad)
        {
            Departamento dept = await FindDepartamentoAsync(idDepartamento);
            dept.Nombre = nombre;
            dept.Localidad = localidad;

            await context.SaveChangesAsync();
        }

        public async Task DeleteDepartamentoAsync(int idDepartamento, string nombre, string localidad)
        {
            Departamento dept = await FindDepartamentoAsync(idDepartamento);

            context.Departamentos.Remove(dept);
            await context.SaveChangesAsync();
        }
    }
}
