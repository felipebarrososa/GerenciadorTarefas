using GerenciadorTarefas.Models;
using GerenciadorTarefas.Data;
using GerenciadorTarefas.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciadorTarefas.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly ITarefaRepository _tarefaRepository;

        public TarefaService(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public async Task<List<Tarefa>> GetTarefasAsync()
        {
            return await _tarefaRepository.GetTarefasAsync();
        }

        public async Task<Tarefa> GetTarefaByIdAsync(int id)
        {
            return await _tarefaRepository.GetTarefaByIdAsync(id);
        }

        public async Task AddTarefaAsync(Tarefa tarefa)
        {
            await _tarefaRepository.AddTarefaAsync(tarefa);
        }

        public async Task UpdateTarefaAsync(Tarefa tarefa)
        {
            await _tarefaRepository.UpdateTarefaAsync(tarefa);
        }

        public async Task DeleteTarefaAsync(int id)
        {
            await _tarefaRepository.DeleteTarefaAsync(id);
        }
    }
}
