using Japanese.Core.CommonModels;
using Japanese.Core.Enum;
using Japanese.LanguageCore.Converter;
using MediatR;

namespace Japanese.Services.Common.Queries.ConvertToRomaji;

public class ConvertToRomajiQueryHandler : IRequestHandler<ConvertToRomajiQuery, ExecResult<string>>
{
    private JapaneseConverter _japaneseConverter;

    public ConvertToRomajiQueryHandler()
    {
        _japaneseConverter = new JapaneseConverter();
    }

    public async Task<ExecResult<string>> Handle(ConvertToRomajiQuery request, CancellationToken cancellationToken)
    {
        return await Task.Run(() =>
        {
            string? romaji = _japaneseConverter.ToRomaji(request.Text);
            return new ExecResult<string> { Status = ExecStatus.Success, Data = romaji };
        });
    }
}