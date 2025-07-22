using Microsoft.EntityFrameworkCore;
using EmprestimoLivros.Models;

namespace EmprestimoLivros.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<EmprestimosModel> Emprestimos { get; set; }
    }
}
