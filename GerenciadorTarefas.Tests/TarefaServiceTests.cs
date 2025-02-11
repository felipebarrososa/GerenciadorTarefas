using Xunit;
using Moq;
using GerenciadorTarefas.Services;
using GerenciadorTarefas.Repositories;
using GerenciadorTarefas.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciadorTarefas.Tests
{
    public class TarefaServiceTests
    {
        private readonly TarefaService _tarefaService;
        private readonly Mock<ITarefaRepository> _tarefaRepositoryMock;

        public TarefaServiceTests()
        {
            _tarefaRepositoryMock = new Mock<ITarefaRepository>();
            _tarefaService = new TarefaService(_tarefaRepositoryMock.Object);
        }

        [Fact]
        public async Task GetTarefasAsync_DeveRetornarListaDeTarefas()
        {
            // Arrange
            var tarefasEsperadas = new List<Tarefa>
            {
                new Tarefa { Id = 1, Titulo = "Tarefa 1", Descricao = "Descrição 1", Status = "Pendente" },
                new Tarefa { Id = 2, Titulo = "Tarefa 2", Descricao = "Descrição 2", Status = "Concluída" }
            };

            _tarefaRepositoryMock.Setup(repo => repo.GetTarefasAsync()).ReturnsAsync(tarefasEsperadas);

            // Act
            var resultado = await _tarefaService.GetTarefasAsync();

            // Assert
            Assert.Equal(2, resultado.Count);
            Assert.Equal("Tarefa 1", resultado[0].Titulo);
        }

        [Fact]
        public async Task AddTarefaAsync_DeveAdicionarTarefa()
        {
            // Arrange
            var novaTarefa = new Tarefa { Id = 3, Titulo = "Nova Tarefa", Descricao = "Nova Descrição", Status = "Pendente" };

            _tarefaRepositoryMock.Setup(repo => repo.AddTarefaAsync(novaTarefa)).Returns(Task.CompletedTask);

            // Act
            await _tarefaService.AddTarefaAsync(novaTarefa);

            // Assert
            _tarefaRepositoryMock.Verify(repo => repo.AddTarefaAsync(novaTarefa), Times.Once);
        }
    }
}
