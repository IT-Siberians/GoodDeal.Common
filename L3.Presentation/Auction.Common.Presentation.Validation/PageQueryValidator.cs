﻿using Auction.Common.Application.L2.Interfaces.Commands;
using FluentValidation;

namespace Auction.Common.Presentation.Validation;

/// <summary>
/// Валидатор параметров пагинации
/// </summary>
public class PageQueryValidator : AbstractValidator<PageQuery>
{
    public PageQueryValidator()
    {
        RuleFor(e => e.ItemsCount)
            .GreaterThanOrEqualTo(1);
        RuleFor(e => e.Number)
            .GreaterThanOrEqualTo(1); ;
    }
}
