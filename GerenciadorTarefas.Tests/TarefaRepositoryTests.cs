using Xunit;
using Microsoft.EntityFrameworkCore;
using GerenciadorTarefas.Data;
using GerenciadorTarefas.Repositories;
using GerenciadorTarefas.Models;
using System.Threading.Tasks;

namespace GerenciadorTarefas.Tests
{
    public class TarefaRepositoryTests
    {
        private readonly TarefaRepository _repository;
        private readonly ApplicationDbContext _context;

        public TarefaRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TarefasTestDb")
                .Options;

            _context = new ApplicationDbContext(options);
            _repository = new TarefaRepository(_context);
        }

        [Fact]
        public async Task AddTarefaAsync_DeveSalvarTarefaNoBanco()
        {
            // Arrange
            var novaTarefa = new Tarefa { Titulo = "Test Tarefa", Descricao = "Descrição de Teste", Status = "Pendente" };

            // Act
            await _repository.AddTarefaAsync(novaTarefa);
            var tarefaNoBanco = await _context.Tarefas.FirstOrDefaultAsync(t => t.Titulo == "Test Tarefa");

            // Assert
            Assert.NotNull(tarefaNoBanco);
            Assert.Equal("Test Tarefa", tarefaNoBanco.Titulo);
        }
    }
}
