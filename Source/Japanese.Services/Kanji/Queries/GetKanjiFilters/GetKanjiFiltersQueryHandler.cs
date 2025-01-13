using Japanese.Services.Kanji.Consts;
using khothemegiatot.WebApi.Enums;
using khothemegiatot.WebApi.Models;
using MediatR;
using System.Reflection;

namespace Japanese.Services.Kanji.Queries.GetKanjiFilters;

public class GetKanjiFiltersQueryHandler : IRequestHandler<GetKanjiFiltersQuery, ExecResult<List<string>>>
{
    public async Task<ExecResult<List<string>>> Handle(GetKanjiFiltersQuery request, CancellationToken cancellationToken)
    {
        List<string> kanjiFilters = new List<string>();

        FieldInfo[] fields = typeof(KanjiFilterConsts).GetFields();
        KanjiFilterConsts kanjiFilterConsts = new KanjiFilterConsts();
        foreach (FieldInfo field in fields)
        {
            kanjiFilters.Add((field.GetValue(kanjiFilterConsts) as string)!);
        }

        await Task.CompletedTask;

        return new ExecResult<List<string>> { Status = ExecStatus.Success, Data = kanjiFilters };
    }
}
