using Auction.Common.Application.L2.Interfaces.Pages;

namespace Auction.Common.Application.L2.Interfaces.Handlers;

/// <summary>
/// Интерфейс обработчика запросов на получение страницы элементов
/// </summary>
/// <typeparam name="TQuery">Тип запроса</typeparam>
/// <typeparam name="TResponse">Тип элемента возвращаемой коллекции (страницы) элементов</typeparam>
public interface IQueryPageHandler<TQuery, TResponse>
    : IQueryHandler<TQuery, IPageOf<TResponse>>
        where TQuery : class;
