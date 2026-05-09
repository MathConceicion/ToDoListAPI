using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models.DTOs.TarefaDto
{
    public class TarefaUpdateDto
    {
        [Required(ErrorMessage = "O título é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O título deve ter no máximo 100 caracteres.")]
        public string Titulo { get; set; } = string.Empty;

        [MaxLength(500, ErrorMessage = "A descrição deve ter no máximo 500 caracteres.")]
        public string? Descricao { get; set; }

        public bool Concluida { get; set; }

        /// <summary>
        /// Valores aceitos: "baixa", "normal", "alta", "urgente".
        /// </summary>
        public string Prioridade { get; set; } = "normal";

        /// <summary>
        /// Data limite opcional. Enviar null para remover o prazo.
        /// </summary>
        public DateTime? DataVencimento { get; set; }
    }
}