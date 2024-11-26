using Auction.Common.Application.L1.Models;
using Auction.Common.Application.L2.Interfaces.Answers;
using Auction.Common.Application.L2.Interfaces.Commands;
using Auction.Common.Application.L2.Interfaces.Handlers;
using Auction.Common.Application.L2.Interfaces.Pages;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Auction.Common.Presentation.Controllers;

/// <summary>
/// Вспомогательные методы для работы с контроллерами
/// </summary>
public static class ControllersHelper
{
    /// <summary>
    /// Расширение для получения ActionResult наиболее подходящего типа для текущего TAnswer
    /// </summary>
    /// <typeparam name="TAnswer">Тип ответа хэндлера</typeparam>
    /// <param name="controller">Контроллер</param>
    /// <param name="answer">Ответ хэндлера</param>
    /// <param name="isCreated">Признак того, что хэндлер пытался создать новую сущность</param>
    /// <returns>ActionResult<TAnswer></returns>
    public static ActionResult<TAnswer> GetActionResult<TAnswer>(
        this ControllerBase controller,
        TAnswer answer,
        bool isCreated = false)
            where TAnswer : IAnswer
    {
        return answer switch
        {
            IOkBaseAnswer => isCreated
                            ? controller.Created("", answer)
                            : controller.Ok(answer),
            IBadAnswer badAnswer => badAnswer?.ErrorCode == ErrorCode.EntityNotFound
                            ? controller.NotFound(answer)
                            : controller.BadRequest(answer),
            _ => controller.BadRequest(answer)
        };
    }

    /// <summary>
    /// Расширение для выполнения заданной коамнды с помощью соответствующего хэндлера и возврата подходящего ActionResult
    /// </summary>
    /// <typeparam name="TCommand">Тип команды</typeparam>
    /// <typeparam name="TCommandWeb">Тип команды web-контроллера</typeparam>
    /// <param name="controller">Кнтроллер</param>
    /// <param name="commandWeb">Команда web-контроллера</param>
    /// <param name="handler">Обработчик команды</param>
    /// <param name="validator">Валидатор команды</param>
    /// <param name="mapper">Маппер</param>
    /// <param name="isCreated">Признак того, что хэндлер пытался создать новую сущность</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>ActionResult<TAnswer></returns>
    public static async Task<ActionResult<IAnswer>> GetCommandActionResultAsync<TCommand, TCommandWeb>(
        this ControllerBase controller,
        TCommandWeb commandWeb,
        ICommandHandler<TCommand> handler,
        IValidator<TCommand> validator,
        IMapper mapper,
        bool isCreated,
        CancellationToken cancellationToken)
            where TCommand : class
            where TCommandWeb : class
    {
        var command = mapper.Map<TCommand>(commandWeb);

        var validationResult = validator.Validate(command);
        if (!validationResult.IsValid)
        {
            return controller.GetBadRequest(validationResult);
        }

        var answer = await handler.HandleAsync(command, cancellationToken);

        return controller.GetActionResult(answer, isCreated);
    }

    /// <summary>
    /// Расширения для возвращения BadRequest со словарём сообщений об ошибках из FluentValidation
    /// </summary>
    /// <param name="controller">Контроллер</param>
    /// <param name="validationResult">Результат валидации</param>
    /// <returns>ActionResult<IAnswer></returns>
    public static ActionResult<IAnswer> GetBadRequest(
        this ControllerBase controller,
        ValidationResult validationResult)
    {
        return controller.BadRequest(new BadValues(validationResult.ToDictionary()));
    }

    /// <summary>
    /// Расширения для возвращения BadRequest со словарём сообщений об ошибках из FluentValidation
    /// </summary>
    /// <param name="controller">Контроллер</param>
    /// <param name="validationResult">Результат валидации</param>
    /// <returns>ActionResult<IAnswer<TResult>></returns>
    public static ActionResult<IAnswer<TResult>> GetBadRequest<TResult>(
        this ControllerBase controller,
        ValidationResult validationResult)
    {
        return controller.BadRequest(new BadValues<TResult>(validationResult.ToDictionary()));
    }

    /// <summary>
    /// Расширение для получения коллекции (страницы) элементов в соответствии с заданным запросом
    /// </summary>
    /// <typeparam name="TQuery">Тип запроса</typeparam>
    /// <typeparam name="TItemModel">Тип модели элемента</typeparam>
    /// <typeparam name="TIsCommand">Тип команды для проверки наличия сущности с заданным уникальным идентификатором</typeparam>
    /// <param name="controller">Контроллер</param>
    /// <param name="query">Запрос</param>
    /// <param name="isHandler">Хэндлер проверки наличия ключевой сущности</param>
    /// <param name="getHandler">Хэндлер получения коллекции</param>
    /// <param name="validator">Валидатор запроса</param>
    /// <param name="mapper">Маппер</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>ActionResult<IAnswer<IPageOf<TItemModel>>></returns>
    public static async Task<ActionResult<IAnswer<IPageOf<TItemModel>>>> GetPageByIdAsync<TQuery, TItemModel, TIsCommand>(
        this ControllerBase controller,
        GetItemsPageByIdQuery query,
        ICommandHandler<TIsCommand> isHandler,
        IQueryPageHandler<TQuery, TItemModel> getHandler,
        IValidator<TQuery> validator,
        IMapper mapper,
        CancellationToken cancellationToken)
        where TQuery : class
            where TIsCommand : class, IModel<Guid>
    {
        var specificQuery = mapper.Map<TQuery>(query);

        var validationResult = validator.Validate(specificQuery);
        if (!validationResult.IsValid)
        {
            return controller.GetBadRequest<IPageOf<TItemModel>>(validationResult);
        }

        var idModel = new IdModel(query.Id);
        var isEntityCommand = mapper.Map<TIsCommand>(idModel);
        var isEntityAnswer = await isHandler.HandleAsync(isEntityCommand, cancellationToken);
        if (isEntityAnswer is BadAnswer badAnswer)
        {
            return controller.GetActionResult(badAnswer.ToIAnswer<IPageOf<TItemModel>>());
        }

        var answer = await getHandler.HandleAsync(specificQuery, cancellationToken);

        return controller.GetActionResult(answer);
    }

    /// <summary>
    /// Метод создания объекта обобщенного запроса элементов на основании отдельных параметров
    /// </summary>
    /// <param name="id">Уникальный идентификатор ключевой сущности</param>
    /// <param name="pageItemsCount">Количество элементов на странице</param>
    /// <param name="pageNumber">Номер страницы</param>
    /// <param name="with">Строка фильтрации которая должна быть обнаружена в элементе</param>
    /// <param name="without">Строка фильтрации которая не должна быть обнаружена в элементе</param>
    /// <returns>GetItemsPageByIdQuery</returns>
    public static GetItemsPageByIdQuery GetPageByIdQuery(
        Guid id,
        int? pageItemsCount,
        int? pageNumber,
        string? with,
        string? without)
    {
        var page = PageQuery.NewOrNull(pageItemsCount, pageNumber);
        var filter = FilterQuery.NewOrNull(with, without);
        var query = new GetItemsPageByIdQuery(id, page, filter);

        return query;
    }
}
