namespace Auction.Common.Application.L2.Interfaces.Answers;

/// <summary>
/// Базовый итерфейс отрицательного ответа без данных
/// </summary>
public interface IBadBaseAnswer : IAnswer;

/// <summary>
/// Базовый интерфейс отрицатльеного ответа с данными
/// </summary>
/// <typeparam name="TResult">Тип возвращаемых данных</typeparam>
public interface IBadBaseAnswer<TResult> : IBadBaseAnswer, IAnswer<TResult>;
