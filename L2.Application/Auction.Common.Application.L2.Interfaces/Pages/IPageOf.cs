using System.Collections.Generic;

namespace Auction.Common.Application.L2.Interfaces.Pages;

/// <summary>
/// Интерфейс страницы элементов
/// </summary>
/// <typeparam name="TItem">Тип элемента</typeparam>
public interface IPageOf<TItem>
{
    /// <summary>
    /// Общее количество элементов
    /// </summary>
    int ItemsCount { get; }

    /// <summary>
    /// Количество элементов на странице
    /// </summary>
    int PageItemsCount { get; }

    /// <summary>
    /// Общее количество страниц
    /// </summary>
    int PagesCount { get; }

    /// <summary>
    /// Номер страницы
    /// </summary>
    int PageNumber { get; }

    /// <summary>
    /// Список элементов
    /// </summary>
    IList<TItem> Items { get; }
}
