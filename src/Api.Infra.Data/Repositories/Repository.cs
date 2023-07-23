using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Infra.Data.Repositories;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    protected readonly Context _context;
    private DbSet<T> _dataset;

    public Repository(Context context, DbSet<T> dataset)
    {
        _context = context;
        _dataset = dataset;
    }

    public async Task<T> InserirAsync(T item)
    {
        try
        {
            if (item.Id == Guid.Empty)
            {
                item.Id = Guid.NewGuid();
            }

            item.DataCriacao = DateTime.UtcNow;
            _dataset.Add(item);

            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return item;
    }

    public async Task<T?> AtualizarAsync(T item)
    {
        try
        {
            var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(item.Id));

            if (result == null)
            {
                return null;
            }

            item.DataCriacao = result.DataCriacao;
            item.DataAlteracao = DateTime.UtcNow;
            _context.Entry(result).CurrentValues.SetValues(item);

            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return item;
    }

    public async Task<bool> ExcluirAsync(Guid id)
    {
        try
        {
            var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));

            if (result == null)
            {
                return false;
            }

            _dataset.Remove(result);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return true;
    }

    public async Task<bool> ExisteAsync(Guid id)
    {
        try
        {
            return await _dataset.AnyAsync(p => p.Id.Equals(id));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<T?> SelecionarAsync(Guid id)
    {
        try
        {
            return await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<IEnumerable<T>> SelecionarAsync()
    {
        try
        {
            return await _dataset.ToListAsync();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}