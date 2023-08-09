using IdentityCore;
using IdentityCore.Models;
using Japanese.Core.CommonModels;
using Japanese.Core.Enum;
using Japanese.LanguageCore.Converter;
using Japanese.Repositories.Interfaces;
using MediatR;

namespace Japanese.Services.Common.Queries.ConvertToRomaji;

public class ConvertToRomajiQueryHandler : IRequestHandler<ConvertToRomajiQuery, ExecResult<string>>
{
    private IJapaneseRepository _japaneseRepository;
    private JapaneseConverter _japaneseConverter;
    private CognitoHelper _cognitoHelper;

    public ConvertToRomajiQueryHandler(IJapaneseRepository japaneseRepository)
    {
        _japaneseConverter = new JapaneseConverter();
        _japaneseRepository = japaneseRepository;
        _cognitoHelper = null;
    }

    public async Task<ExecResult<string>> Handle(ConvertToRomajiQuery request, CancellationToken cancellationToken)
    {
        await _cognitoHelper.CreateUserAsync(new UserModel { UserName = "demo", Email = "demo@example.com", Password = "123456789" });

        return new ExecResult<string> { Status = ExecStatus.Success, Message = "Test area" };
        //return await Task.Run(() =>
        //{
        //    string? romaji = _japaneseConverter.ToRomaji(request.Text);
        //    return new ExecResult<string> { Status = ExecStatus.Success, Data = romaji };
        //});
    }
}