using GerenciadorTarefas.Models;
using GerenciadorTarefas.Data;
using GerenciadorTarefas.Services;
using Microsoft.AspNetCore.Mvc;
using GerenciadorTarefas.Repositories;


namespace GerenciadorTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaService _tarefaService;

        public TarefaController(ITarefaService tarefaService)
        {
            _tarefaService = tarefaService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Tarefa>>> GetTarefas()
        {
            var tarefas = await _tarefaService.GetTarefasAsync();
            return Ok(tarefas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tarefa>> GetTarefaById(int id)
        {
            var tarefa = await _tarefaService.GetTarefaByIdAsync(id);
            if (tarefa == null)
                return NotFound();
            return Ok(tarefa);
        }

        [HttpPost]
        public async Task<ActionResult> AddTarefa([FromBody] Tarefa tarefa)
        {
            if (tarefa == null)
                return BadRequest();
            await _tarefaService.AddTarefaAsync(tarefa);
            return CreatedAtAction(nameof(GetTarefaById), new { id = tarefa.Id }, tarefa);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTarefa(int id, [FromBody] Tarefa tarefa)
        {
            if (id != tarefa.Id)
                return BadRequest();
            await _tarefaService.UpdateTarefaAsync(tarefa);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTarefa(int id)
        {
            await _tarefaService.DeleteTarefaAsync(id);
            return NoContent();
        }
    }
}
