using Japanese.Core.Queue;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Japanese.Services.Kanji.Queues;

public class KanjiQueueTask : IQueueTask
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public string TaskID => Guid.NewGuid().ToString();

    public bool SyncKanjidic2ToMainTable { get; set; }
    public Kanjidic2Model? Kanjidic2Model { get; set; }
    public KanjiModel? KanjiModel { get; set; }

    public KanjiQueueTask(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    public Task DoTaskAsync()
    {
        if (SyncKanjidic2ToMainTable)
            return M_SyncKanjidic2ToMainTable();

        return Task.CompletedTask;
    }

    private Task M_SyncKanjidic2ToMainTable()
    {
        using IServiceScope scope = _serviceScopeFactory.CreateScope();
        IJapaneseRepository repository = scope.ServiceProvider.GetRequiredService<IJapaneseRepository>();

        KanjiModel!.CreatedAt = DateTime.Now;

        repository.KanjiRepository.InsertAsync(KanjiModel!);

        return Task.CompletedTask;
    }
}
