using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services;

public interface IUsuarioService
{
    Task<UsuarioEntity> Obter(Guid id);
    Task<IEnumerable<UsuarioEntity>> ObterTodos();
    Task<UsuarioEntity> Adicionar(UsuarioEntity usuario);
    Task<UsuarioEntity> Atualizar(UsuarioEntity usuario);
    Task<bool> Remover(Guid id);
}