namespace Auction.Common.Application.L2.Interfaces.Answers;

/// <summary>
/// Базовый интерфес ответа без данных
/// </summary>
public interface IAnswer;

/// <summary>
/// Базовый интерфес ответа с данными заданного типа
/// </summary>
/// <typeparam name="TResult">Тип возвращаемых данных</typeparam>
public interface IAnswer<TResult> : IAnswer;
