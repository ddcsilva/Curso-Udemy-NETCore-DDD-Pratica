using Api.Domain.Entities;

namespace Api.Domain.Interfaces;

public interface IRepository<T> where T : BaseEntity
{
    Task<T> InserirAsync(T item);
    Task<T?> AtualizarAsync(T item);
    Task<bool> ExcluirAsync(Guid id);
    Task<bool> ExisteAsync(Guid id);
    Task<T?> SelecionarAsync(Guid id);
    Task<IEnumerable<T>> SelecionarAsync();
}