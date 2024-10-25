﻿using FluentValidation;
using ToDo.Application.Commands.CreateToDoTask;

namespace ToDo.Application.Commands.UpdateToDoTask;

public class UpdateToDoTaskValidator : AbstractValidator<UpdateToDoTaskCommand>
{
    private const int MaximumTitleLength = 30;
    private const int MaximumDescriptionLength = 250;
    
    public UpdateToDoTaskValidator()
    {
        RuleFor(t => t.Title)
            .MaximumLength(MaximumTitleLength).WithMessage($"The length of the title must be less than {MaximumTitleLength}");
        RuleFor(t => t.Description)
            .MaximumLength(MaximumDescriptionLength).WithMessage($"The length of the description must be less than {MaximumDescriptionLength}");
    }
}