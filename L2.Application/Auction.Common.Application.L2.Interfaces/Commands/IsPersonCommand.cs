using Auction.Common.Application.L1.Models;
using System;

namespace Auction.Common.Application.L2.Interfaces.Commands;

/// <summary>
/// Команда подтвержения наличия пользователя с заданным уникальным идентификатором
/// </summary>
/// <param name="Id">Уникальный идентификатор пользователя</param>
public record IsPersonCommand(Guid Id)
        : IModel<Guid>;
