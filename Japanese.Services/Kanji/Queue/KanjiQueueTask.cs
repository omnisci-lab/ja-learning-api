using Japanese.Core.Queue;
using Nest;

namespace Japanese.Services.Kanji.Queue;

public class KanjiQueueTask : IQueueTask
{
    public string TaskID => Guid.NewGuid().ToString();

    public bool SyncKanjidic2ToMainDb { get; set; }

    public Task DoTaskAsync()
    {
        if (SyncKanjidic2ToMainDb)
        {

        }

        return Task.CompletedTask;
    }
}
