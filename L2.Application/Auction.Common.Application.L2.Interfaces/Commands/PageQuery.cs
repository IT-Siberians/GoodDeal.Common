namespace Auction.Common.Application.L2.Interfaces.Commands;

/// <summary>
/// Параметры пагинации для запроса
/// </summary>
/// <param name="ItemsCount">Количество элементов на странице</param>
/// <param name="Number">Номер страницы</param>
public record PageQuery(
    int ItemsCount,
    int Number)
{
    /// <summary>
    /// Возвращает null или объект с параметрами пагинации
    /// </summary>
    /// <param name="pageItemsCount">Количество элементов на странице</param>
    /// <param name="pageNumber">Номер страницы</param>
    /// <returns>Объект с параметрами пагинации</returns>
    public static PageQuery? NewOrNull(int? pageItemsCount, int? pageNumber)
    {

        if (pageItemsCount is not null && pageNumber is not null && pageItemsCount.Value > 0 && pageNumber.Value > 0)
        {
            return new PageQuery(pageItemsCount.Value, pageNumber.Value);
        }

        return null;
    }
}
