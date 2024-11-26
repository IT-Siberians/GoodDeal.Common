using Auction.Common.Application.L2.Interfaces.Commands;
using FluentValidation;

namespace Auction.Common.Presentation.Validation;

/// <summary>
/// Валидатор команды удаления пользователя
/// </summary>
public class DeletePersonCommandValidator : AbstractValidator<DeletePersonCommand>
{
    public DeletePersonCommandValidator()
    {
        RuleFor(e => e.Id)
            .NotEmpty();
    }
}
