using GerenciadorTarefas.Models;
using GerenciadorTarefas.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciadorTarefas.Services
{
    public interface ITarefaService
    {
        Task<List<Tarefa>> GetTarefasAsync();
        Task<Tarefa> GetTarefaByIdAsync(int id);
        Task AddTarefaAsync(Tarefa tarefa);
        Task UpdateTarefaAsync(Tarefa tarefa);
        Task DeleteTarefaAsync(int id);
    }
}
