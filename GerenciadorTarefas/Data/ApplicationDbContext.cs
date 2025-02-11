using Microsoft.EntityFrameworkCore;
using GerenciadorTarefas.Models;
namespace GerenciadorTarefas.Data

{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<Tarefa> Tarefas { get; set; }
    }
}