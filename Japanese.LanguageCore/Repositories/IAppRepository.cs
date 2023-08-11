using Japanese.Core.CommonModels;
using Japanese.Core.RepositoryBase;
using System.Linq.Expressions;

namespace Japanese.LanguageCore.Repositories;

public interface IAppRepository<TModel> : IAsyncRepository<TModel> where TModel : class
{

}
