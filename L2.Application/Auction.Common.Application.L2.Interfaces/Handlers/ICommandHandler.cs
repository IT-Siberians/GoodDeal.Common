using Auction.Common.Application.L2.Interfaces.Answers;

namespace Auction.Common.Application.L2.Interfaces.Handlers;

/// <summary>
/// Интерфейс обработчика команд
/// </summary>
/// <typeparam name="TCommand">Тип команды</typeparam>
public interface ICommandHandler<TCommand>
    : IHandler<TCommand, IAnswer>
        where TCommand : class;
