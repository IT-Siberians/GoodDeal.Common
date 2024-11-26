using Auction.Common.Application.L1.Models;
using System;

namespace Auction.Common.Application.L2.Interfaces.Commands;

/// <summary>
/// Команда для создания нового пользователя
/// </summary>
/// <param name="Id">Уникальный идентификатор пользователя</param>
/// <param name="Username">Имя пользователя</param>
public record CreatePersonCommand(
        Guid Id,
        string Username)
            : IModel<Guid>;
