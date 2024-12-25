using FluentValidation;
using Japanese.Core.CommonModels;

namespace Japanese.Core.CQRS.Validators;

public class PaginationValidator<T> : AbstractValidator<T> where T : Pagination
{
    public PaginationValidator()
    {
        RuleFor(x => x.PageSize).GreaterThanOrEqualTo(1).LessThanOrEqualTo(100);
    }
}