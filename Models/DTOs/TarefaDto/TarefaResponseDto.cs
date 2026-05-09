namespace ToDoList.Models.DTOs.TarefaDto
{
    public class TarefaResponseDto
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        public bool Concluida { get; set; }
        public string Prioridade { get; set; } = "normal";
        public DateTime? DataVencimento { get; set; }

        /// <summary>
        /// Indica se a tarefa está atrasada (não concluída e passou do prazo).
        /// Calculado automaticamente — não vem do banco.
        /// </summary>
        public bool Atrasada => !Concluida && DataVencimento.HasValue && DataVencimento.Value < DateTime.UtcNow;

        public DateTime DataCriacao { get; set; }
        public DateTime? AtualizadaEm { get; set; }
        public Guid UsuarioId { get; set; }
    }
}