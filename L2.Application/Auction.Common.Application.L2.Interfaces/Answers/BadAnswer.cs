namespace Auction.Common.Application.L2.Interfaces.Answers;

/// <summary>
/// Ответ без данных с сообщением об ошибке
/// </summary>
public class BadAnswer : IBadAnswer
{
    /// <summary>
    /// Сообщение об ошибке
    /// </summary>
    public string ErrorMessage { get; }

    /// <summary>
    /// Код ошибки
    /// </summary>
    public ErrorCode ErrorCode { get; }

    /// <summary>
    /// Конструктор твета без данных с сообщением об ошибке
    /// </summary>
    /// <param name="message">Сообщение об ошибке</param>
    /// <param name="code">Код ошибки</param>
    protected BadAnswer(string message, ErrorCode code)
    {
        ErrorMessage = message;
        ErrorCode = code;
    }

    /// <summary>
    /// Приведение к ответу с данными (BadAnswer<TResult>)
    /// </summary>
    /// <typeparam name="TResult">Тип данных</typeparam>
    /// <returns>Ответ с данными</returns>
    public BadAnswer<TResult> ToBadAnswer<TResult>() => new(ErrorMessage, ErrorCode);

    /// <summary>
    /// Приведение к интерфесу ответа с данными (IAnswer<TResult>)
    /// </summary>
    /// <typeparam name="TResult">Тип данных</typeparam>
    /// <returns>Ответ с данными</returns>
    public IAnswer<TResult> ToIAnswer<TResult>() => new BadAnswer<TResult>(ErrorMessage, ErrorCode);

    /// <summary>
    /// Создание ответа с сообщением об ошибке
    /// </summary>
    /// <param name="message">Сообщение об ошибке</param>
    /// <returns>BadAnswer</returns>
    public static BadAnswer Error(string message) => new(message, ErrorCode.Error);

    /// <summary>
    /// Создание ответа с сообщением об ошибке с испольщзованием шаблона string.Format
    /// </summary>
    /// <param name="pattern">Шаблон сообщения об ошибке</param>
    /// <param name="args">Параметры сообщения об ошибке</param>
    /// <returns>BadAnswer</returns>
    public static BadAnswer Error(string pattern, params object?[] args) => new(string.Format(pattern, args), ErrorCode.Error);

    /// <summary>
    /// Создание ответа для неправильного значения поля с сообщением об ошибке
    /// </summary>
    /// <param name="message">Сообщение об ошибке</param>
    /// <returns>BadAnswer</returns>
    public static BadAnswer BadFieldValue(string message) => new(message, ErrorCode.BadFieldValue);

    /// <summary>
    /// Создание ответа для неправильного значения поля с сообщением об ошибке с испольщзованием шаблона string.Format
    /// </summary>
    /// <param name="message">Сообщение об ошибке</param>
    /// <returns>BadAnswer</returns>
    public static BadAnswer BadFieldValue(string pattern, params object?[] args) => new(string.Format(pattern, args), ErrorCode.BadFieldValue);

    /// <summary>
    /// Создание ответа для ненайденной сущности с сообщением об ошибке
    /// </summary>
    /// <param name="message">Сообщение об ошибке</param>
    /// <returns>BadAnswer</returns>
    public static BadAnswer EntityNotFound(string message) => new(message, ErrorCode.EntityNotFound);

    /// <summary>
    /// Создание ответа для ненайденной сущности с сообщением об ошибке с испольщзованием шаблона string.Format
    /// </summary>
    /// <param name="pattern">Шаблон сообщения об ошибке</param>
    /// <param name="args">Параметры сообщения об ошибке</param>
    /// <returns>BadAnswer</returns>
    public static BadAnswer EntityNotFound(string pattern, params object?[] args) => new(string.Format(pattern, args), ErrorCode.EntityNotFound);
}

/// <summary>
/// Ответ с данными с сообщением об ошибке
/// </summary>
/// <typeparam name="TResult">Тип данных</typeparam>
/// <param name="message">Сообщение об ошибке</param>
/// <param name="code">Код ошибки</param>
public class BadAnswer<TResult>(string message, ErrorCode code)
    : BadAnswer(message, code),
    IBadAnswer<TResult>
{
    /// <summary>
    /// Создание ответа с сообщением об ошибке
    /// </summary>
    /// <param name="message">Сообщение об ошибке</param>
    /// <returns>BadAnswer<TResult></returns>
    public static new BadAnswer<TResult> Error(string message) => new(message, ErrorCode.Error);

    /// <summary>
    /// Создание ответа с сообщением об ошибке с испольщзованием шаблона string.Format
    /// </summary>
    /// <param name="pattern">Шаблон сообщения об ошибке</param>
    /// <param name="args">Параметры сообщения об ошибке</param>
    /// <returns>BadAnswer<TResult></returns>
    public static new BadAnswer<TResult> Error(string pattern, params object?[] args) => new(string.Format(pattern, args), ErrorCode.Error);

    /// <summary>
    /// Создание ответа для неправильного значения поля с сообщением об ошибке
    /// </summary>
    /// <param name="message">Сообщение об ошибке</param>
    /// <returns>BadAnswer<TResult></returns>
    public static new BadAnswer<TResult> BadFieldValue(string message) => new(message, ErrorCode.BadFieldValue);

    /// <summary>
    /// Создание ответа для неправильного значения поля с сообщением об ошибке с испольщзованием шаблона string.Format
    /// </summary>
    /// <param name="message">Сообщение об ошибке</param>
    /// <returns>BadAnswer<TResult></returns>
    public static new BadAnswer<TResult> BadFieldValue(string pattern, params object?[] args) => new(string.Format(pattern, args), ErrorCode.BadFieldValue);

    /// <summary>
    /// Создание ответа для ненайденной сущности с сообщением об ошибке
    /// </summary>
    /// <param name="message">Сообщение об ошибке</param>
    /// <returns>BadAnswer<TResult></returns>
    public static new BadAnswer<TResult> EntityNotFound(string message) => new(message, ErrorCode.EntityNotFound);

    /// <summary>
    /// Создание ответа для ненайденной сущности с сообщением об ошибке с испольщзованием шаблона string.Format
    /// </summary>
    /// <param name="pattern">Шаблон сообщения об ошибке</param>
    /// <param name="args">Параметры сообщения об ошибке</param>
    /// <returns>BadAnswer<TResult></returns>
    public static new BadAnswer<TResult> EntityNotFound(string pattern, params object?[] args) => new(string.Format(pattern, args), ErrorCode.EntityNotFound);
}