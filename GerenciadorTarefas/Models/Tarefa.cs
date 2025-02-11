namespace GerenciadorTarefas.Models

{

    public class Tarefa
    {
        public int Id { get; set; }

        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; }

        public Tarefa(string titulo, string descricao, string status)
        {
            Titulo = titulo ?? throw new ArgumentNullException(nameof(titulo));
            Descricao = descricao ?? throw new ArgumentNullException(nameof(descricao));
            Status = status ?? throw new ArgumentNullException(nameof(status));
        }
    }
}