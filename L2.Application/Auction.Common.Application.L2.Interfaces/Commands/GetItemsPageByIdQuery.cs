using Auction.Common.Application.L1.Models;
using System;

namespace Auction.Common.Application.L2.Interfaces.Commands;

/// <summary>
/// Запрос получения страницы элементов по уникальному идентификатору
/// </summary>
/// <param name="Id">Уникальный идентификатор сущности</param>
/// <param name="Page">Параметры страницы</param>
/// <param name="Filter">Параметры фильтрации</param>
public record GetItemsPageByIdQuery(
    Guid Id,
    PageQuery? Page,
    FilterQuery? Filter)
        : IModel<Guid>, IPagedQuery, IFilteredQuery;
