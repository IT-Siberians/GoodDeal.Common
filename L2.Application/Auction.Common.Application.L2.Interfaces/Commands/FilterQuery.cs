namespace Auction.Common.Application.L2.Interfaces.Commands;

/// <summary>
/// Параметры фильтрации для запроса
/// </summary>
/// <param name="With">Строка которая должна обнаруживаться</param>
/// <param name="Without">Строка которая не должна обнаруживаться</param>
public record FilterQuery(
    string? With,
    string? Without)
{
    /// <summary>
    /// Возвращает null или объект с параметрами фильтрации 
    /// </summary>
    /// <param name="with">Строка которая должна обнаруживаться</param>
    /// <param name="without"Строка которая не должна обнаруживаться></param>
    /// <returns>Обект параметров фильтрации</returns>
    public static FilterQuery? NewOrNull(string? with, string? without)
    {
        var withNotEmpty = string.IsNullOrWhiteSpace(with) ? null : with.Trim().ToLower();
        var withoutNotEmpty = string.IsNullOrWhiteSpace(without) ? null : without.Trim().ToLower();

        if (withNotEmpty is null && withoutNotEmpty is null)
        {
            return null;
        }

        return new FilterQuery(withNotEmpty, withoutNotEmpty);
    }
}
