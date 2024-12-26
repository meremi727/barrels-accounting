using BarrelsAccounting.Accounting.Dal;
using Microsoft.EntityFrameworkCore;

namespace Accounting.Util;

public static class DataBaseExtention
{
    public static void AddDataBase(this IServiceCollection services, string connectionString)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(nameof(connectionString));

        services.AddDbContext<AccountingDbContext>(CreateOprions);

        void CreateOprions(DbContextOptionsBuilder builder)
        {
            builder.UseNpgsql(connectionString);

            #warning Добавить логи в дебаге
        }
    }
}