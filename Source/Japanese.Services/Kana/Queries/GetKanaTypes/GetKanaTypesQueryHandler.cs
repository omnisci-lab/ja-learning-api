using Japanese.Core.CommonModels;
using Japanese.Core.Enum;
using Japanese.Services.Kana.Consts;
using khothemegiatot.WebApi.Enums;
using khothemegiatot.WebApi.Models;
using MediatR;
using System.Reflection;

namespace Japanese.Services.Kana.Queries.GetKanaTypes;

public class GetKanaTypesQueryHandler : IRequestHandler<GetKanaTypesQuery, ExecResult<List<string>>>
{
    public async Task<ExecResult<List<string>>> Handle(GetKanaTypesQuery request, CancellationToken cancellationToken)
    {
        List<string> kanaTypes = new List<string>();

        FieldInfo[] fields = typeof(KanaTypeConsts).GetFields();
        KanaTypeConsts kanaTypeConsts = new KanaTypeConsts();
        foreach (FieldInfo field in fields)
        {
            kanaTypes.Add((field.GetValue(kanaTypeConsts) as string)!);
        }

        await Task.CompletedTask;

        return new ExecResult<List<string>> { Status = ExecStatus.Success, Data = kanaTypes };
    }
}