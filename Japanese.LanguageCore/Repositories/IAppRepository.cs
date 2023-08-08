using Japanese.Core.RepositoryBase;

namespace Japanese.LanguageCore.Repositories;

public interface IAppRepository<TModel> : IAsyncRepository<TModel> where TModel : class
{
}