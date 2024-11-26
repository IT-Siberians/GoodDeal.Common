namespace Auction.Common.Application.L2.Interfaces.Answers;

/// <summary>
/// Интерфейс положительного ответа без данных
/// </summary>
public interface IOkAnswer : IOkBaseAnswer
{
    string? Message { get; }
}

/// <summary>
/// Интерфейс положительного ответа с данными
/// </summary>
/// <typeparam name="TResult">Тип данных</typeparam>
public interface IOkAnswer<TResult> : IOkBaseAnswer, IAnswer<TResult>
{
    TResult Result { get; }
}
