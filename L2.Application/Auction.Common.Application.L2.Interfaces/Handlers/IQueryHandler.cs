using Auction.Common.Application.L2.Interfaces.Answers;

namespace Auction.Common.Application.L2.Interfaces.Handlers;

/// <summary>
/// Интерфейс обработчика запросов
/// </summary>
/// <typeparam name="TQuery">Тип зпроса</typeparam>
/// <typeparam name="TResponse">Тип ответа</typeparam>
public interface IQueryHandler<TQuery, TResponse>
    : IHandler<TQuery, IAnswer<TResponse>>
        where TQuery : class;
