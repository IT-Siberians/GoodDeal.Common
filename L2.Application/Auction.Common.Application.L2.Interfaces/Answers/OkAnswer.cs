namespace Auction.Common.Application.L2.Interfaces.Answers;

/// <summary>
/// Положительный ответ без данных
/// </summary>
/// <param name="message">Сообщение</param>
public class OkAnswer(string message) : IOkAnswer
{
    /// <summary>
    /// Сообщение
    /// </summary>
    public string Message { get; } = message;

    /// <summary>
    /// Конструктор положительного ответа с испольщзованием шаблона string.Format
    /// </summary>
    /// <param name="pattern">Шаблон сообщения</param>
    /// <param name="args">Параметры сообщения</param>
    public OkAnswer(string pattern, params object?[] args) : this(string.Format(pattern, args)) { }
}

/// <summary>
/// Положительный ответ с данными
/// </summary>
/// <typeparam name="TResult">Тип возвращаемых данных</typeparam>
/// <param name="result">Значение возвращаемых данных</param>
public class OkAnswer<TResult>(TResult result) : IOkAnswer<TResult>
{
    /// <summary>
    /// Возвращаемые данные
    /// </summary>
    public TResult Result { get; } = result;
}
