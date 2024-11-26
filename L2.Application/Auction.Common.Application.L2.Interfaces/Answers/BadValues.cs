using System.Collections.Generic;

namespace Auction.Common.Application.L2.Interfaces.Answers;

/// <summary>
/// Ответ для возвращения списка ошибок FluentValidation
/// </summary>
/// <param name="errors">Словарь с массивом ошибок для каждого параметра</param>
public class BadValues(IDictionary<string, string[]> errors) : IBadBaseAnswer
{
    /// <summary>
    /// Словарь с массивом ошибок для каждого параметра
    /// </summary>
    public IDictionary<string, string[]> Errors { get; } = errors;

    /// <summary>
    /// Приведенеи к типу ответа с данными
    /// </summary>
    /// <typeparam name="TResult">Тип возвращаемых данных</typeparam>
    /// <returns>Ответ с данными</returns>
    public BadValues<TResult> ToBadValues<TResult>() => new(Errors);

    /// <summary>
    /// Приведение к интерфесу IAnswer<TResult>
    /// </summary>
    /// <typeparam name="TResult">Тип возвращаемых данных</typeparam>
    /// <returns>Ответ с данными</returns>
    public IAnswer<TResult> ToIAnswer<TResult>() => new BadValues<TResult>(Errors);
}

/// <summary>
/// Ответ с данными для возвращения списка ошибок FluentValidation
/// </summary>
/// <typeparam name="TResult"></typeparam>
/// <param name="errors"></param>
public class BadValues<TResult>(IDictionary<string, string[]> errors)
    : BadValues(errors),
    IBadBaseAnswer<TResult>;
