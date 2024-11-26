using System;
using System.Threading.Tasks;

namespace Auction.Common.Infrastructure.DbInitialization;

/// <summary>
/// Интерфейс инициализатора базы данных
/// </summary>
public interface IDbInitializer : IDisposable
{
    /// <summary>
    /// Выполняет заполнение базы данных начальными данными
    /// </summary>
    Task InitDatabaseAsync();
}
