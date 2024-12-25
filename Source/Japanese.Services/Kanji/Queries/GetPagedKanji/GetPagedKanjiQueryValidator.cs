using FluentValidation;
using Japanese.Core.CQRS.Validators;
using Japanese.Services.Kanji.Consts;

namespace Japanese.Services.Kanji.Queries.GetPagedKanji;

public class GetPagedKanjiQueryValidator : PaginationValidator<GetPagedKanjiQuery>
{
    public GetPagedKanjiQueryValidator() 
        : base()
    {
        //RuleFor(x => x.FilterValue).NotNull()
        //    .Custom((o, x) => {

        //    }).When(x => x.FilterBy == KanjiFilterConsts.ByJLpt);
    }
}