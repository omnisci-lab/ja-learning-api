namespace Japanese.Repositories.Interfaces;

public interface IJapaneseRepository
{
    IKanjiRepository KanjiRepository { get; }
}
