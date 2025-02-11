using GerenciadorTarefas.Models;
using GerenciadorTarefas.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciadorTarefas.Repositories
{
    public interface ITarefaRepository
    {
        Task<List<Tarefa>> GetTarefasAsync();
        Task<Tarefa> GetTarefaByIdAsync(int id);
        Task AddTarefaAsync(Tarefa tarefa);
        Task UpdateTarefaAsync(Tarefa tarefa);
        Task DeleteTarefaAsync(int id);
    }
}
