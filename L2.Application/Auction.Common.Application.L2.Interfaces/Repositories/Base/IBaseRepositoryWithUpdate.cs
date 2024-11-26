using Auction.Common.Application.L2.Interfaces.Repositories.Partial;
using Auction.Common.Domain.Entities;
using System;

namespace Auction.Common.Application.L2.Interfaces.Repositories.Base;

/// <summary>
/// Базовый репозиторий с получением, добавлением, сохранением и обновлением сущностей
/// </summary>
/// <typeparam name="TEntity">Тип сущности</typeparam>
/// <typeparam name="TKey">Тип уникального идентификатора</typeparam>
public interface IBaseRepositoryWithUpdate<TEntity, TKey>
    : IBaseRepository<TEntity, TKey>,
    IUpdatableRepository<TEntity>
        where TEntity : class, IEntity<TKey>
        where TKey : struct, IEquatable<TKey>;
