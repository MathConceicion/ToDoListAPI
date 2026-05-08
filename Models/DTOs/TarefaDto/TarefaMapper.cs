using ToDoList.Models.Entities;

namespace ToDoList.Models.DTOs.TarefaDto;

public static class TarefaMapper
{
    // Valores válidos de prioridade
    private static readonly string[] _prioridadesValidas = ["baixa", "normal", "alta", "urgente"];

    /// <summary>
    /// Normaliza e valida o valor de prioridade.
    /// Retorna "normal" se o valor for inválido.
    /// </summary>
    private static string NormalizarPrioridade(string? prioridade)
    {
        var valor = prioridade?.Trim().ToLower() ?? "normal";
        return _prioridadesValidas.Contains(valor) ? valor : "normal";
    }

    /// <summary>
    /// Converte a entidade Tarefa para o DTO de resposta.
    /// </summary>
    public static TarefaResponseDto ToResponse(this Tarefa t) => new()
    {
        Id = t.Id,
        Titulo = t.Titulo,
        Descricao = t.Descricao,
        Concluida = t.Concluida,
        Prioridade = t.Prioridade,
        DataCriacao = t.DataCriacao,
        AtualizadaEm = t.AtualizadaEm,
        UsuarioId = t.UsuarioId
    };

    /// <summary>
    /// Converte o DTO de criação para a entidade Tarefa.
    /// </summary>
    public static Tarefa ToEntity(this TarefaCreateDto dto, Guid usuarioId) => new()
    {
        Id = Guid.NewGuid(),
        Titulo = dto.Titulo.Trim(),
        Descricao = dto.Descricao?.Trim(),
        Prioridade = NormalizarPrioridade(dto.Prioridade),
        UsuarioId = usuarioId,
        DataCriacao = DateTime.UtcNow
    };
}