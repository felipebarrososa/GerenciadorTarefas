using GerenciadorTarefas.Models;
using GerenciadorTarefas.Services;
using Microsoft.AspNetCore.Mvc;
using GerenciadorTarefas.Repositories;
using GerenciadorTarefas.Messaging; // Namespace para RabbitMQPublisher

namespace GerenciadorTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaService _tarefaService;
        private readonly IRabbitMQPublisher _rabbitMQPublisher;

        public TarefaController(ITarefaService tarefaService, IRabbitMQPublisher rabbitMQPublisher)
        {
            _tarefaService = tarefaService;
            _rabbitMQPublisher = rabbitMQPublisher;
        }

        // GET: api/tarefa
        [HttpGet]
        public async Task<ActionResult<List<Tarefa>>> GetTarefas()
        {
            var tarefas = await _tarefaService.GetTarefasAsync();
            return Ok(tarefas);
        }

        // GET: api/tarefa/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Tarefa>> GetTarefaById(int id)
        {
            var tarefa = await _tarefaService.GetTarefaByIdAsync(id);
            if (tarefa == null)
                return NotFound();
            return Ok(tarefa);
        }

        // POST: api/tarefa
        [HttpPost]
        public async Task<ActionResult> AddTarefa([FromBody] Tarefa tarefa)
        {
            if (tarefa == null)
                return BadRequest();

            await _tarefaService.AddTarefaAsync(tarefa);
            return CreatedAtAction(nameof(GetTarefaById), new { id = tarefa.Id }, tarefa);
        }

        // PUT: api/tarefa/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTarefa(int id, [FromBody] Tarefa tarefa)
        {
            if (id != tarefa.Id)
                return BadRequest();

            await _tarefaService.UpdateTarefaAsync(tarefa);
            return NoContent();
        }

        // DELETE: api/tarefa/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTarefa(int id)
        {
            await _tarefaService.DeleteTarefaAsync(id);
            return NoContent();
        }

        // POST: api/tarefa/criar (envia mensagem para RabbitMQ)
        [HttpPost("criar")]
        public async Task<IActionResult> Criar([FromBody] Tarefa tarefa)
        {
            if (tarefa == null)
                return BadRequest();

            await _tarefaService.AddTarefaAsync(tarefa);
            _rabbitMQPublisher.PublicarMensagem(tarefa);

            return CreatedAtAction(nameof(GetTarefaById), new { id = tarefa.Id }, tarefa);
        }
    }
}
