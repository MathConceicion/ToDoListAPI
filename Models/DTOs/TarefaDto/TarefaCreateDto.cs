using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models.DTOs.TarefaDto
{
    public class TarefaCreateDto
    {
        [Required(ErrorMessage = "O título é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O título deve ter no máximo 100 caracteres.")]
        public string Titulo { get; set; } = string.Empty;

        [MaxLength(500, ErrorMessage = "A descrição deve ter no máximo 500 caracteres.")]
        public string? Descricao { get; set; }

        /// <summary>
        /// Valores aceitos: "baixa", "normal", "alta", "urgente".
        /// </summary>
        public string Prioridade { get; set; } = "normal";

        /// <summary>
        /// Data limite opcional. Formato ISO 8601: "2026-12-31T00:00:00"
        /// </summary>
        public DateTime? DataVencimento { get; set; }
    }
}