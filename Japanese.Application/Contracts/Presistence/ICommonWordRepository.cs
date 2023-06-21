using Japanese.Application.Base;
using Japanese.Domain.Entities.CommonWordGroup;

namespace Japanese.Application.Contracts.Presistence;

public interface ICommonWordRepository : IAsyncRepository<CommonWord>
{

}
