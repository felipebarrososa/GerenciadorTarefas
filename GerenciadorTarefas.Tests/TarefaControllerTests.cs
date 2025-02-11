using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using GerenciadorTarefas.Controllers;
using GerenciadorTarefas.Services;
using GerenciadorTarefas.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciadorTarefas.Tests
{
    public class TarefaControllerTests
    {
        private readonly TarefaController _tarefaController;
        private readonly Mock<ITarefaService> _tarefaServiceMock;

        public TarefaControllerTests()
        {
            _tarefaServiceMock = new Mock<ITarefaService>();
            _tarefaController = new TarefaController(_tarefaServiceMock.Object);
        }

        [Fact]
        public async Task GetTarefas_DeveRetornarOkComListaDeTarefas()
        {
            // Arrange
            var tarefasEsperadas = new List<Tarefa>
            {
                new Tarefa { Id = 1, Titulo = "Tarefa 1", Descricao = "Descrição 1", Status = "Pendente" }
            };

            _tarefaServiceMock.Setup(service => service.GetTarefasAsync()).ReturnsAsync(tarefasEsperadas);

            // Act
            var resultado = await _tarefaController.GetTarefas();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(resultado.Result);
            var tarefas = Assert.IsAssignableFrom<List<Tarefa>>(okResult.Value);
            Assert.Single(tarefas);
        }

        [Fact]
        public async Task AddTarefa_DeveRetornarCreatedAtAction()
        {
            // Arrange
            var novaTarefa = new Tarefa { Id = 2, Titulo = "Nova Tarefa", Descricao = "Descrição", Status = "Pendente" };

            _tarefaServiceMock.Setup(service => service.AddTarefaAsync(novaTarefa)).Returns(Task.CompletedTask);

            // Act
            var resultado = await _tarefaController.AddTarefa(novaTarefa);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(resultado);
            Assert.Equal(nameof(_tarefaController.GetTarefaById), createdAtActionResult.ActionName);
        }
    }
}
