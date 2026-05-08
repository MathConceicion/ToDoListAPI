using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models.DTOs.TarefaDto
{
    public class TarefaCreateDto
    {
        [Required(ErrorMessage = "O título é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O título deve ter no máximo 100 caracteres.")]
        public string Titulo { get; set; } = string.Empty;

        [MaxLength(500, ErrorMessage = "A descrição deve ter no máximo 500 caracteres.")]
        public string? Descricao { get; set; } = string.Empty;

        /// <summary>
        /// Valores aceitos: "baixa", "normal", "alta", "urgente".
        /// Se não informado, assume "normal".
        /// </summary>
        public string Prioridade { get; set; } = "normal";
    }
}