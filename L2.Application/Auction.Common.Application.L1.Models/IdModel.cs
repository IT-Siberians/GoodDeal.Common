using System;

namespace Auction.Common.Application.L1.Models;

/// <summary>
/// Модель с единственным свойством Id
/// </summary>
/// <param name="Id">Id сущности</param>
public record IdModel(
        Guid Id)
            : IModel<Guid>;
