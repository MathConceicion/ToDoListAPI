using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models.DTOs.UsuarioDto
{
    public class AtualizarPerfilDto
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [MinLength(3, ErrorMessage = "O nome deve ter pelo menos 3 caracteres.")]
        [MaxLength(50, ErrorMessage = "O nome deve ter no máximo 50 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        // NovaSenha é opcional — só altera se vier preenchido
        [MinLength(6, ErrorMessage = "A senha deve ter pelo menos 6 caracteres.")]
        [MaxLength(16, ErrorMessage = "A senha deve ter no máximo 16 caracteres.")]
        public string? NovaSenha { get; set; }
    }
}