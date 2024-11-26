using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace Auction.Common.Infrastructure.DbInitialization;

/// <summary>
/// Вспомогательные методы для инициализации БД
/// </summary>
public static class InitializationHelper
{
    /// <summary>
    /// Расширение для запуска инициализации БД
    /// </summary>
    /// <typeparam name="T">Тип инициализатора</typeparam>
    /// <param name="host">Приложение</param>
    public static async Task InitAsync<T>(this IHost host)
        where T : IDbInitializer
    {
        using var scope = host.Services.CreateScope();
        using var dbInitializer = scope.ServiceProvider.GetRequiredService<T>();

        await dbInitializer.InitDatabaseAsync();
    }
}
