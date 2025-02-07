﻿using Auction.Common.Application.L2.Interfaces.Answers;
using Auction.Common.Application.L2.Interfaces.Commands;
using Auction.Common.Application.L2.Interfaces.Handlers;
using Auction.Common.Application.L2.Interfaces.Pages;
using Auction.Common.Application.L2.Interfaces.Repositories.Base;
using Auction.Common.Domain.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Auction.Common.Application.L3.Logic.Handlers;

/// <summary>
/// Обобщённый обработчик получения коллекции сущностей
/// </summary>
/// <typeparam name="TQuery">Тип запроса</typeparam>
/// <typeparam name="TEntity">Тип сущности</typeparam>
/// <typeparam name="TModel">Тип модели</typeparam>
/// <typeparam name="TEntityRepository">Тип репозитория сущности</typeparam>
/// <typeparam name="TOrderKey">Тип ключа сортировки</typeparam>
/// <param name="repository">Репозитория сущности</param>
/// <param name="toModel">Конвертер сущности в модель</param>
/// <param name="orderKeySelector">Селектор ключа сортировки</param>
/// <param name="includeProperties">Список праметров сущности вытягиваемых из БД</param>
/// <param name="useTracking">Ключ отслеживания сущности в EF после извлечения из БД</param>
public class GetPageHandler<TQuery, TEntity, TModel, TEntityRepository, TOrderKey>(
    TEntityRepository repository,
    Func<TEntity, TModel> toModel,
    Expression<Func<TEntity, TOrderKey>>? orderKeySelector,
    string? includeProperties,
    bool useTracking)
        : IQueryPageHandler<TQuery, TModel>,
        IDisposable
            where TQuery : class, IPagedQuery
            where TModel : class
            where TEntity : class, IEntity<Guid>
            where TEntityRepository : class, IBaseRepository<TEntity, Guid>
{
    private readonly TEntityRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));

    private bool _isDisposed;

    protected Expression<Func<TEntity, bool>>[]? Filters;
    protected TQuery? Query;

    public void Dispose()
    {
        if (!_isDisposed)
        {
            _repository.Dispose();

            _isDisposed = true;
        }

        GC.SuppressFinalize(this);
    }

    public async Task<IAnswer<IPageOf<TModel>>> HandleAsync(TQuery query, CancellationToken cancellationToken = default)
    {
        Query = query ?? throw new ArgumentNullException(nameof(query));

        var entitiesPage = await _repository.GetAsync(
                                    Filters,
                                    orderKeySelector,
                                    page: query.Page,
                                    includeProperties,
                                    useTracking,
                                    cancellationToken);

        var modelsPage = new PageOf<TModel>(
                                entitiesPage.ItemsCount,
                                entitiesPage.PageItemsCount,
                                entitiesPage.PagesCount,
                                entitiesPage.PageNumber,
                                entitiesPage.Items.Select(toModel).ToList());

        return new OkAnswer<IPageOf<TModel>>(modelsPage);
    }
}
