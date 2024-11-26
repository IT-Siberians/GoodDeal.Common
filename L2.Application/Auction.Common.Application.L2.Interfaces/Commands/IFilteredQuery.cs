namespace Auction.Common.Application.L2.Interfaces.Commands;

/// <summary>
/// Интерфейс запроса с парметрами фильтрации
/// </summary>
public interface IFilteredQuery
{
    /// <summary>
    /// Параметры фильтрации
    /// </summary>
    FilterQuery? Filter { get; }
}
