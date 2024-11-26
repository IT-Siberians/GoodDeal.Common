namespace Auction.Common.Application.L2.Interfaces.Answers;

/// <summary>
/// Код ошибки
/// </summary>
public enum ErrorCode
{
    /// <summary>
    /// Нет ошибок
    /// </summary>
    NoErrors = 0,

    /// <summary>
    /// Неизвестная ошибка
    /// </summary>
    Error = 1,

    /// <summary>
    /// Неправильное значение поля
    /// </summary>
    BadFieldValue = 2,

    /// <summary>
    /// Сущность не найдена
    /// </summary>
    EntityNotFound = 3
}
