using Auction.Common.Application.L2.Interfaces.Commands;
using FluentValidation;

namespace Auction.Common.Presentation.Validation;

/// <summary>
/// Валидатор запроса на получение пользователя по его уникальному идентификатору
/// </summary>
public class GetPersonQueryValidator : AbstractValidator<GetPersonQuery>
{
    public GetPersonQueryValidator()
    {
        RuleFor(e => e.Id)
            .NotEmpty();
    }
}
