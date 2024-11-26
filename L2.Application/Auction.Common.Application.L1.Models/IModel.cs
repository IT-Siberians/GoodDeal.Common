using System;

namespace Auction.Common.Application.L1.Models;

/// <summary>
/// Интерфесй модели со свойством Id
/// </summary>
/// <typeparam name="TKey">Тип уникального идентификатора</typeparam>
public interface IModel<TKey>
    where TKey : struct, IEquatable<TKey>
{
    /// <summary>
    /// Уникальный идентификатор
    /// </summary>
    public TKey Id { get; }
}
