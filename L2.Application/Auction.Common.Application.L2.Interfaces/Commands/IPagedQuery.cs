namespace Auction.Common.Application.L2.Interfaces.Commands;

/// <summary>
/// Интерфейс запроса с параметрами пагинации
/// </summary>
public interface IPagedQuery
{
    /// <summary>
    /// Параметры пагинации
    /// </summary>
    PageQuery? Page { get; }
}
