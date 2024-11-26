namespace Auction.Common.Application.L2.Interfaces.Answers;

/// <summary>
/// Интерфейс отрицательного ответа без данных
/// </summary>
public interface IBadAnswer : IBadBaseAnswer
{
    /// <summary>
    /// Сообщение об ошибке
    /// </summary>
    string? ErrorMessage { get; }

    /// <summary>
    /// Код ошибки
    /// </summary>
    ErrorCode ErrorCode { get; }
}

/// <summary>
/// Интерфейс отрицательного ответа с данными
/// </summary>
/// <typeparam name="TResult">Тип возвращаемых данных</typeparam>
public interface IBadAnswer<TResult> : IBadAnswer, IBadBaseAnswer<TResult>, IAnswer<TResult>;
