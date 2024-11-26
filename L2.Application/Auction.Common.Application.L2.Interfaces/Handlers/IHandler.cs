using System.Threading;
using System.Threading.Tasks;

namespace Auction.Common.Application.L2.Interfaces.Handlers;

/// <summary>
/// Базовый интерфейс обработчика
/// </summary>
/// <typeparam name="TInput">Тип аргумента</typeparam>
/// <typeparam name="TOutput">Тип результата</typeparam>
public interface IHandler<TInput, TOutput> where TInput : class
{
    /// <summary>
    /// Метод обработки
    /// </summary>
    /// <param name="input">Аргумент (входные данные)</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Результат (выходные данные)</returns>
    Task<TOutput> HandleAsync(TInput input, CancellationToken cancellationToken = default);
}
