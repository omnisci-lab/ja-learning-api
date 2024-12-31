using Japanese.Core.CommonModels;
using MediatR;

namespace Japanese.Services.Dictionary.Queries.GetDictionary;

public class GetDictionaryQuery : IRequest<ExecResult<DictionaryOutput>>
{
}
