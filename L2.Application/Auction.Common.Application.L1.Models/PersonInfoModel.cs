using System;

namespace Auction.Common.Application.L1.Models;

/// <summary>
/// Модель основной информации о человеке
/// </summary>
/// <param name="Id">Уникальный идентификатор</param>
/// <param name="Username">Имя пользователя</param>
public record PersonInfoModel(
        Guid Id,
        string Username)
            : IModel<Guid>;
