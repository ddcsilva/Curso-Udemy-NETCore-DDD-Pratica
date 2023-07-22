using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Infra.Data;

public class ContextFactory : IDesignTimeDbContextFactory<Context>
{
    public Context CreateDbContext(string[] args)
    {
        var connectionString = "Server=127.0.0.1;Port=3308;Database=ApiDB;Uid=root;Pwd=root";
        var optionsBuilder = new DbContextOptionsBuilder<Context>();
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        return new Context(optionsBuilder.Options);
    }
}