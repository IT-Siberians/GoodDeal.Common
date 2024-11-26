using System;

namespace Auction.Common.Application.L1.Models;

/// <summary>
/// Модель основной информации о лоте
/// </summary>
/// <param name="Id">Уникальный идентификатор</param>
/// <param name="Title">Название лота</param>
/// <param name="Description">Описание лота</param>
public record LotInfoModel(
        Guid Id,
        string Title,
        string Description)
            : IModel<Guid>;
