using LiteDB;

namespace Japanese.Kanjidic2;

public class Kanjidic2Service
{
    private readonly LiteDatabase _liteDatabase;
    private ILiteCollection<Kanjidic2Model> _collection;

    public Kanjidic2Service()
    {
        _liteDatabase = new LiteDatabase(new ConnectionString("Filename=Resources/Kanjidic2.db"));
        _collection = _liteDatabase.GetCollection<Kanjidic2Model>("kanjidic2");
    }

    public Kanjidic2Model? GetKanji(string literal)
    {
        Kanjidic2Model? kanjidic2Model = _collection.FindOne(x => x.Literal == literal);
        if (kanjidic2Model is null)
            return null;

        return kanjidic2Model;
    }

    public Task<Kanjidic2Model?> GetKanjiAsync(string literal) => Task.FromResult(GetKanji(literal));

    public IEnumerable<Kanjidic2Model> GetKanjiList(int page, int pageSize)
    {
        IEnumerable<Kanjidic2Model> kanjidic2Models = _collection
           .Find(Query.All(), skip: (page - 1) * pageSize, limit: pageSize);

        return kanjidic2Models;
    }

    public Task<IEnumerable<Kanjidic2Model>> GetKanjiListAsync(int page, int pageSize)
        => Task.FromResult(GetKanjiList(page, pageSize));

    public IEnumerable<Kanjidic2Model> GetByOnyomi(string onReading)
    {
        IEnumerable<BsonValue> bsonValueEnumrable = _liteDatabase.Execute(
        "SELECT $ FROM kanjidic2 WHERE $.readingMeaning.groups[*].readings[*].type ANY IN 'ja_on' AND $.readingMeaning.groups[*].readings[*].value ANY IN @0",
        BsonMapper.Global.Serialize(onReading)).ToEnumerable();

        foreach (BsonValue bsonValue in bsonValueEnumrable)
            yield return BsonMapper.Global.ToObject<Kanjidic2Model>(bsonValue.AsDocument);
    }

    public Task<IEnumerable<Kanjidic2Model>> GetByOnyomiAsync(string onReading)
        => Task.FromResult(GetByOnyomi(onReading));

    public IEnumerable<Kanjidic2Model> GetByKunyomi(string kunReading)
    {
        IEnumerable<BsonValue> bsonValueEnumrable = _liteDatabase.Execute(
        "SELECT $ FROM kanjidic2 WHERE $.readingMeaning.groups[*].readings[*].type ANY IN 'ja_kun' AND $.readingMeaning.groups[*].readings[*].value ANY IN @0",
        BsonMapper.Global.Serialize(kunReading)).ToEnumerable();

        foreach (BsonValue bsonValue in bsonValueEnumrable)
            yield return BsonMapper.Global.ToObject<Kanjidic2Model>(bsonValue.AsDocument);
    }

    public Task<IEnumerable<Kanjidic2Model>> GetByKunyomiAsync(string kunReading)
        => Task.FromResult(GetByKunyomi(kunReading));

    public IEnumerable<Kanjidic2Model> GetBySinoVietnamese(string sinoVietnamese)
    {
        IEnumerable<BsonValue> bsonValueEnumrable = _liteDatabase.Execute(
        "SELECT $ FROM kanjidic2 WHERE $.readingMeaning.groups[*].readings[*].type ANY IN 'vietnam' AND $.readingMeaning.groups[*].readings[*].value ANY IN @0",
        BsonMapper.Global.Serialize(sinoVietnamese)).ToEnumerable();

        foreach (BsonValue bsonValue in bsonValueEnumrable)
        {
            yield return BsonMapper.Global.ToObject<Kanjidic2Model>(bsonValue.AsDocument);
        }
    }

    public Task<IEnumerable<Kanjidic2Model>> GetBySinoVietnameseAsync(string sinoVietnamese)
        => Task.FromResult(GetByKunyomi(sinoVietnamese));
}
