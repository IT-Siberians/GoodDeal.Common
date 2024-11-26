using Auction.Common.Application.L1.Models;
using System;

namespace Auction.Common.Application.L2.Interfaces.Commands;

/// <summary>
/// Запрос получения пользователя по его уникальному идентификатору
/// </summary>
/// <param name="Id">Уникальный идентификатор пользователя</param>
public record GetPersonQuery(Guid Id)
        : IModel<Guid>;
