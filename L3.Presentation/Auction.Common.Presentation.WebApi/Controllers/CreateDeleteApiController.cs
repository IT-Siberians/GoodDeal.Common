using Auction.Common.Application.L1.Models;
using Auction.Common.Application.L2.Interfaces.Answers;
using Auction.Common.Application.L2.Interfaces.Handlers;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Auction.Common.Presentation.Controllers;

/// <summary>
/// Обобщённый контроллер с методами создания и удаления сущности
/// </summary>
/// <typeparam name="TCreateCommandWeb">Тип команды создания сущности для web-контроллера</typeparam>
/// <typeparam name="TCreateCommand">Тип команды создания сущности</typeparam>
/// <typeparam name="TDeleteCommand">Тип команды удаления сущности</typeparam>
/// <param name="mapper">Маппер</param>
[Route("/api/v1/[controller]")]
[ApiController]
public class CreateDeleteApiController<TCreateCommandWeb, TCreateCommand, TDeleteCommand>(
    IMapper mapper)
        : ControllerBase
            where TCreateCommandWeb : class
            where TCreateCommand : class
            where TDeleteCommand : class
{
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    /// <summary>
    /// Экшн создания сущности
    /// </summary>
    /// <param name="commandWeb">Команда создания сущности для web-контроллера</param>
    /// <param name="validator">Валидатор команды</param>
    /// <param name="handler">Обработчик команды</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>ActionResult<IAnswer></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(OkAnswer))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadValues))]
    public async Task<ActionResult<IAnswer>> Create(
        [FromBody] TCreateCommandWeb commandWeb,
        [FromServices] IValidator<TCreateCommand> validator,
        [FromServices] ICommandHandler<TCreateCommand> handler,
        CancellationToken cancellationToken)
    {
        var command = _mapper.Map<TCreateCommand>(commandWeb);

        var validationResult = validator.Validate(command);
        if (!validationResult.IsValid)
        {
            return this.GetBadRequest(validationResult);
        }

        var answer = await handler.HandleAsync(command, cancellationToken);

        return this.GetActionResult(answer, true);
    }

    /// <summary>
    /// Экшн удаления сущности
    /// </summary>
    /// <param name="id">Уникальный идентификатор сущности</param>
    /// <param name="validator">Валидатор команды</param>
    /// <param name="handler">Обработчик команды</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>ActionResult<IAnswer></returns>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OkAnswer))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadValues))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BadAnswer))]
    public async Task<ActionResult<IAnswer>> Delete(
        Guid id,
        [FromServices] IValidator<TDeleteCommand> validator,
        [FromServices] ICommandHandler<TDeleteCommand> handler,
        CancellationToken cancellationToken = default)
    {
        var command = _mapper.Map<TDeleteCommand>(new IdModel(id));

        var validationResult = validator.Validate(command);
        if (!validationResult.IsValid)
        {
            return this.GetBadRequest(validationResult);
        }

        var answer = await handler.HandleAsync(command, cancellationToken);

        return this.GetActionResult(answer);
    }
}
