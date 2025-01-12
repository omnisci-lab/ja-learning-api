using Japanese.Core.CommonModels;
using Japanese.Core.Enum;
using Japanese.Services.Kanji.Consts;
using khothemegiatot.WebApi.Enums;
using khothemegiatot.WebApi.Models;
using MediatR;
using System.Reflection;

namespace Japanese.Services.Kanji.Queries.GetSearchProperties;

public class GetKanjiSearchPropertiesQueryHandler : IRequestHandler<GetKanjiSearchPropertiesQuery, ExecResult<List<string>>>
{
    public async Task<ExecResult<List<string>>> Handle(GetKanjiSearchPropertiesQuery request, CancellationToken cancellationToken)
    {
        List<string> searchProperties = new List<string>();

        FieldInfo[] fields = typeof(KanjiSearchConsts).GetFields();
        KanjiSearchConsts kanjiSearchConsts = new KanjiSearchConsts();
        foreach(FieldInfo field in fields)
        {
            searchProperties.Add((field.GetValue(kanjiSearchConsts) as string)!);
        }

        await Task.CompletedTask;

        return new ExecResult<List<string>> { Status = ExecStatus.Success, Data = searchProperties };
    }
}
