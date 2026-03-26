using ApiCoreCrudDepartamentosMMT.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCoreCrudDepartamentosMMT.Data
{
    public class DepartamentosContext : DbContext
    {
        public DepartamentosContext(DbContextOptions<DepartamentosContext> options) : base(options) { }
        public DbSet<Departamento> Departamentos { get; set; }
    }
}
