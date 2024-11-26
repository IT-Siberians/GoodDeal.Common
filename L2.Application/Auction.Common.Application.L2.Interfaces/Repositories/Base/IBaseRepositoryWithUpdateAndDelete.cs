using Auction.Common.Application.L2.Interfaces.Repositories.Partial;
using Auction.Common.Domain.Entities;
using System;

namespace Auction.Common.Application.L2.Interfaces.Repositories.Base;

/// <summary>
/// Базовый репозиторий с получением, добавлением, сохранением, обновлением и удалением сущностей
/// </summary>
/// <typeparam name="TEntity">Тип сущности</typeparam>
/// <typeparam name="TKey">Тип уникального идентификатора</typeparam>
public interface IBaseRepositoryWithUpdateAndDelete<TEntity, TKey>
    : IBaseRepositoryWithUpdate<TEntity, TKey>,
    IDeletableRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
        where TKey : struct, IEquatable<TKey>;
