using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services;

namespace Api.Service.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IRepository<UsuarioEntity> _repository;

    public UsuarioService(IRepository<UsuarioEntity> repository)
    {
        _repository = repository;
    }

    public async Task<UsuarioEntity> Obter(Guid id)
    {
        return await _repository.SelecionarAsync(id);
    }

    public async Task<IEnumerable<UsuarioEntity>> ObterTodos()
    {
        return await _repository.SelecionarAsync();
    }

    public async Task<UsuarioEntity> Adicionar(UsuarioEntity usuario)
    {
        return await _repository.InserirAsync(usuario);
    }

    public async Task<UsuarioEntity> Atualizar(UsuarioEntity usuario)
    {
        return await _repository.AtualizarAsync(usuario);
    }

    public async Task<bool> Remover(Guid id)
    {
        return await _repository.ExcluirAsync(id);
    }
}