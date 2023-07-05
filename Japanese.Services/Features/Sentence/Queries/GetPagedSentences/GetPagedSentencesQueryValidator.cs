using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Japanese.Services.Features.Sentence.Queries.GetPagedSentences;

public class GetPagedSentencesQueryValidator : AbstractValidator<GetPagedSentencesQuery>
{
    public GetPagedSentencesQueryValidator()
    {
        RuleFor(x => x.PageSize).GreaterThanOrEqualTo(1);
    }
}
