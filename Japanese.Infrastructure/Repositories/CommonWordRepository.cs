using Japanese.Application.Contracts.Presistence;
using Japanese.Domain.Entities.CommonWordGroup;
using Japanese.Infrastructure.Base;
using Japanese.Infrastructure.Persistence;

namespace Japanese.Infrastructure.Repositories;

public class CommonWordRepository : AsyncRepository<JapaneseDbContext, CommonWord>, ICommonWordRepository
{
    public CommonWordRepository(JapaneseDbContext context) 
        : base(context, context.CommonWords)
    {
        
    }

    protected override void ConfigureInclude()
    {
        //Include(i => i.CommonWordViMeaning);
    }

    protected override void ConfigureOrder()
    {
        Order.Add("Id", x => x.Id);
        Order.Add("Word", x => x.Word);
        Order.Add("Kana", x => x.Kana);
        Order.Add("Romaji", x => x.Romaji);
        Order.Add("CreatedDate", x => x.CreatedDate);
    }

    protected override void ConfigureSearch()
    {
        Search.Add("All", (x, s) => {
            return x => x.Id!.Contains(s) || x.Kana!.Contains(s) || x.Romaji!.Contains(s);
        });

        Search.Add("Word", (x, s) => { return x => x.Word!.Contains(s); });
        Search.Add("Kana", (x, s) => { return x => x.Kana!.Contains(s); });
        Search.Add("Romaji", (x, s) => { return x => x.Romaji!.Contains(s); });
    }
}
