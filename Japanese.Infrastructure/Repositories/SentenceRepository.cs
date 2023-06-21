using Japanese.Application.Contracts.Presistence;
using Japanese.Infrastructure.Persistence;

namespace Japanese.Infrastructure.Repositories
{
    internal class SentenceRepository : ISentenceRepository
    {
        private JapaneseDbContext context;

        public SentenceRepository(JapaneseDbContext context)
        {
            this.context = context;
        }
    }
}