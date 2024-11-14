namespace Japanese.Core.Queue;

public interface IQueueTask
{
    string TaskID { get; }

    Task DoTaskAsync();
}
