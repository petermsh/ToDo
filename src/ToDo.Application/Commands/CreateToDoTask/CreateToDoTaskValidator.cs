using FluentValidation;

namespace ToDo.Application.Commands.CreateToDoTask;

public class CreateToDoTaskValidator : AbstractValidator<CreateToDoTaskCommand>
{
    private const int MinimumCompletionPercentageValue = 0;
    private const int MaximumCompletionPercentageValue = 100;
    private const int MaximumTitleLength = 30;
    private const int MaximumDescriptionLength = 250;
    
    public CreateToDoTaskValidator()
    {
        RuleFor(t => t.CompletionPercentage)
            .GreaterThanOrEqualTo(MinimumCompletionPercentageValue).WithMessage($"Completion percentage must be greater than {MinimumCompletionPercentageValue}");
        RuleFor(t => t.CompletionPercentage)
            .LessThanOrEqualTo(MaximumCompletionPercentageValue).WithMessage($"Completion percentage must be less than {MaximumCompletionPercentageValue}");
        RuleFor(t => t.Title)
            .MaximumLength(MaximumTitleLength).WithMessage($"The length of the title must be less than {MaximumTitleLength}");
        RuleFor(t => t.Description)
            .MaximumLength(MaximumDescriptionLength).WithMessage($"The length of the description must be less than {MaximumDescriptionLength}");
    }
}