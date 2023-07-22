using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Infra.Data;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options) { }

    public DbSet<UsuarioEntity> Usuarios => Set<UsuarioEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}