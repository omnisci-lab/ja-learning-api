using Japanese.Core.CQRS.Validators;

namespace Japanese.Services.Kanji.Queries.GetPagedKanji;

public class GetPagedKanjiQueryValidator : PaginationValidator<GetPagedKanjiQuery>
{
    public GetPagedKanjiQueryValidator() 
        : base()
    {
    }
}