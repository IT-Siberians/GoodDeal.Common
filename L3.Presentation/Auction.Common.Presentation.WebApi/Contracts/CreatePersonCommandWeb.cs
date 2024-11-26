using System;

namespace Auction.Common.Presentation.Contracts;

/// <summary>
/// Команда создания пользователя
/// </summary>
/// <param name="Id">Уникальный идентификатор пользователя</param>
/// <param name="Username">Имя пользователя</param>
public record CreatePersonCommandWeb(
    Guid Id,
    string Username);
