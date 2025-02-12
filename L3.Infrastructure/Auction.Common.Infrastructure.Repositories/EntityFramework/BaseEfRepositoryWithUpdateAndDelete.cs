﻿using Auction.Common.Application.L2.Interfaces.Repositories.Base;
using Auction.Common.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Auction.Common.Infrastructure.Repositories.EntityFramework;

/// <summary>
/// Базовый класс EntityFramework-репозитория.
/// Позволяет получать, добавлять, обновлять и удалять сущности
/// </summary>
/// <typeparam name="TDbContext">Тип контекста БД</typeparam>
/// <typeparam name="TEntity">Тип сущности</typeparam>
/// <typeparam name="TKey">Тип уникального идентификатора сущности</typeparam>
/// <param name="dbContext">Значение контекста БД</param>
public class BaseEfRepositoryWithUpdateAndDelete<TDbContext, TEntity, TKey>(TDbContext dbContext)
    : BaseEfRepositoryWithUpdate<TDbContext, TEntity, TKey>(dbContext),
    IBaseRepositoryWithUpdateAndDelete<TEntity, TKey>
        where TDbContext : DbContext
        where TEntity : class, IEntity<TKey>, IDeletableSoftly
        where TKey : struct, IEquatable<TKey>
{
    /// <summary>
    /// Удаляет сущность
    /// </summary>
    /// <param name="entity">Сущность</param>
    /// <returns>true если сущность существует, иначе false</returns>
    public virtual bool Delete(TEntity entity)
    {
        ArgumentNullException.ThrowIfNull(entity, nameof(entity));

        entity.MarkAsDeletedSoftly();

        return Update(entity);
    }

    /// <summary>
    /// Удаляет сущность по её уникальному идентификатору
    /// </summary>
    /// <param name="id">Уникальный идентификатор сущности</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>true если сущность существует, иначе false</returns>
    public virtual async Task<bool> DeleteByIdAsync(
        TKey id,
        CancellationToken cancellationToken = default)
    {
        var entity = await GetByIdAsync(id, cancellationToken: cancellationToken);

        if (entity is null)
        {
            return false;
        }

        return Delete(entity);
    }
}
