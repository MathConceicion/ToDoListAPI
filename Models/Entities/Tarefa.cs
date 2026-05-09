namespace ToDoList.Models.Entities
{
    public class Tarefa
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string? Descricao { get; set; } = string.Empty;
        public bool Concluida { get; set; } = false;

        /// <summary>
        /// Prioridade: "baixa", "normal", "alta" ou "urgente". Padrão: "normal".
        /// </summary>
        public string Prioridade { get; set; } = "normal";

        /// <summary>
        /// Data limite para conclusão da tarefa. Opcional.
        /// </summary>
        public DateTime? DataVencimento { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
        public DateTime? AtualizadaEm { get; set; } = DateTime.UtcNow;

        public Guid UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
        public ICollection<Comentario>? Comentarios { get; set; }
    }
}