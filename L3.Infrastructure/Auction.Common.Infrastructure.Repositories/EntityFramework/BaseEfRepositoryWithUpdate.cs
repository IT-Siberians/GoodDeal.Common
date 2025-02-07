﻿using Auction.Common.Application.L2.Interfaces.Repositories.Base;
using Auction.Common.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Auction.Common.Infrastructure.Repositories.EntityFramework;

/// <summary>
/// Базовый класс EntityFramework-репозитория.
/// Позволяет получать, добавлять и обновлять сущности
/// </summary>
/// <typeparam name="TDbContext">Тип контекста БД</typeparam>
/// <typeparam name="TEntity">Тип сущности</typeparam>
/// <typeparam name="TKey">Тип уникального идентификатора сущности</typeparam>
/// <param name="dbContext">Значение контекста БД</param>
public class BaseEfRepositoryWithUpdate<TDbContext, TEntity, TKey>(TDbContext dbContext)
    : BaseEfRepository<TDbContext, TEntity, TKey>(dbContext),
    IBaseRepositoryWithUpdate<TEntity, TKey>
        where TDbContext : DbContext
        where TEntity : class, IEntity<TKey>
        where TKey : struct, IEquatable<TKey>
{
    /// <summary>
    /// Обновляет состояние сущности
    /// </summary>
    /// <param name="entity">Сущность</param>
    /// <returns>true если сущность существует и ее удалось обновить, иначе false</returns>
    public virtual bool Update(TEntity entity)
    {
        ArgumentNullException.ThrowIfNull(entity, nameof(entity));

        var entry = DbSet.Update(entity);

        return entry.State == EntityState.Modified;
    }
}
