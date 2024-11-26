using Auction.Common.Application.L1.Models;
using System;

namespace Auction.Common.Application.L2.Interfaces.Commands;

/// <summary>
/// Команда для удаления пользователя по его уникальному идентификатору
/// </summary>
/// <param name="Id">Уникальный идентификатор пользователя</param>
public record DeletePersonCommand(Guid Id)
        : IModel<Guid>;
