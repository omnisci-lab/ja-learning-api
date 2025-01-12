using FluentValidation;
using Japanese.Services.Kanji.Consts;
using khothemegiatot.WebApi.CQRS.Validators;

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