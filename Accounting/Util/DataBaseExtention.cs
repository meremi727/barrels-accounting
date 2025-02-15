using BarrelsAccounting.Accounting.Dal;
using Microsoft.EntityFrameworkCore;

namespace BarrelsAccounting.Accounting.Util;

public static class DataBaseExtention
{
    public static void AddDataBase(this IServiceCollection services, string connectionString)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(nameof(connectionString));

        services.AddDbContext<AccountingDbContext>(CreateOprions);
        services.AddDbContext<ReferencesDbContext>(CreateOprions);
        services.AddDbContext<SearchDbContext>(CreateOprions);

        void CreateOprions(DbContextOptionsBuilder builder)
        {
            builder.UseNpgsql(connectionString);
            #warning Добавить логи в дебаге
        }
    }
}