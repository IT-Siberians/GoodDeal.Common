using Auction.Common.Application.L2.Interfaces.Commands;
using FluentValidation;

namespace Auction.Common.Presentation.Validation;

/// <summary>
/// Валидатор команды подтверждения наличия пользователя с заданным уникальным идентификатором
/// </summary>
public class IsPersonCommandValidator : AbstractValidator<IsPersonCommand>
{
    public IsPersonCommandValidator()
    {
        RuleFor(e => e.Id)
            .NotEmpty();
    }
}
