using Japanese.Core.CommonModels;
using Japanese.Core.Enum;
using Japanese.LanguageCore.Converter;
using Japanese.Repositories.Implements;
using Japanese.Repositories.Interfaces;
using MediatR;

namespace Japanese.Services.Common.Queries.ConvertToRomaji;

public class ConvertToRomajiQueryHandler : IRequestHandler<ConvertToRomajiQuery, ExecResult<string>>
{
    private IJapaneseRepository _japaneseRepository;
    private JapaneseConverter _japaneseConverter;

    public ConvertToRomajiQueryHandler(IJapaneseRepository japaneseRepository)
    {
        _japaneseConverter = new JapaneseConverter();
        _japaneseRepository = japaneseRepository;
    }

    public async Task<ExecResult<string>> Handle(ConvertToRomajiQuery request, CancellationToken cancellationToken)
    {
        await _japaneseRepository.VocabRepository.TestAsync();

        return new ExecResult<string> { Status = ExecStatus.Success, Message = "Test area" };
        //return await Task.Run(() =>
        //{
        //    string? romaji = _japaneseConverter.ToRomaji(request.Text);
        //    return new ExecResult<string> { Status = ExecStatus.Success, Data = romaji };
        //});
    }
}