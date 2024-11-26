using System.Collections.Generic;

namespace Auction.Common.Application.L2.Interfaces.Pages;

/// <summary>
/// Страница элементов
/// </summary>
/// <typeparam name="TItem">Тип элемента</typeparam>
/// <param name="ItemsCount">Общее количество элементов</param>
/// <param name="PageItemsCount">Количество элементов на странице</param>
/// <param name="PagesCount">Общее количество страниц</param>
/// <param name="PageNumber">Номер страницы</param>
/// <param name="Items">Список элементов</param>
public record PageOf<TItem>(
    int ItemsCount,
    int PageItemsCount,
    int PagesCount,
    int PageNumber,
    IList<TItem> Items) : IPageOf<TItem>;
