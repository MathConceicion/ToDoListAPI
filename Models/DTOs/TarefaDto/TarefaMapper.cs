using ToDoList.Models.Entities;

namespace ToDoList.Models.DTOs.TarefaDto;

public static class TarefaMapper
{
    private static readonly string[] _prioridadesValidas = ["baixa", "normal", "alta", "urgente"];

    private static string NormalizarPrioridade(string? prioridade)
    {
        var valor = prioridade?.Trim().ToLower() ?? "normal";
        return _prioridadesValidas.Contains(valor) ? valor : "normal";
    }

    public static TarefaResponseDto ToResponse(this Tarefa t) => new()
    {
        Id = t.Id,
        Titulo = t.Titulo,
        Descricao = t.Descricao,
        Concluida = t.Concluida,
        Prioridade = t.Prioridade,
        DataVencimento = t.DataVencimento,
        DataCriacao = t.DataCriacao,
        AtualizadaEm = t.AtualizadaEm,
        UsuarioId = t.UsuarioId
    };

    public static Tarefa ToEntity(this TarefaCreateDto dto, Guid usuarioId) => new()
    {
        Id = Guid.NewGuid(),
        Titulo = dto.Titulo.Trim(),
        Descricao = dto.Descricao?.Trim(),
        Prioridade = NormalizarPrioridade(dto.Prioridade),
        DataVencimento = dto.DataVencimento,
        UsuarioId = usuarioId,
        DataCriacao = DateTime.UtcNow,
        AtualizadaEm = DateTime.UtcNow
    };
}