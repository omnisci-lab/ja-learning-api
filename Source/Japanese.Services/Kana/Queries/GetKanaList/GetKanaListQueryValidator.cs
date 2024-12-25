using FluentValidation;
using Japanese.Services.Kana.Consts;
using Microsoft.VisualBasic;

namespace Japanese.Services.Kana.Queries.GetKanaList;

public class GetKanaListQueryValidator : AbstractValidator<GetKanaListQuery>
{
    public GetKanaListQueryValidator()
    {
        RuleFor(x => x.KanaType).NotNull().NotEmpty()
            .Must(value => new[] { KanaTypeConsts.Hiragana, KanaTypeConsts.Katakana, KanaTypeConsts.Hentaigana }
            .Contains(value));
    }
}