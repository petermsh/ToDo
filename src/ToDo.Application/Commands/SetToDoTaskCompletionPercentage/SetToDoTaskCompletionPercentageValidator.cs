﻿using FluentValidation;

namespace ToDo.Application.Commands.SetToDoTaskCompletionPercentage;

public class SetToDoTaskCompletionPercentageValidator : AbstractValidator<SetToDoTaskCompletionPercentageCommand>
{
    private const int MinimumCompletionPercentageValue = 0;
    private const int MaximumCompletionPercentageValue = 100;
    
    public SetToDoTaskCompletionPercentageValidator()
    {
        RuleFor(t => t.CompletionPercentage)
            .GreaterThanOrEqualTo(MinimumCompletionPercentageValue).WithMessage($"Completion percentage must be greater than {MinimumCompletionPercentageValue}");
        RuleFor(t => t.CompletionPercentage)
            .LessThanOrEqualTo(MaximumCompletionPercentageValue).WithMessage($"Completion percentage must be less than {MaximumCompletionPercentageValue}");
    }
}