using AutoMapper;
using Japanese.Models;
using Japanese.Services.Kanji.Queries;

namespace Japanese.Services.Kanji.Mappings;

public class Kanjidic2_KanjiDetail_Converter : ITypeConverter<Kanjidic2Model, KanjiDetailOutput>
{
    public KanjiDetailOutput Convert(Kanjidic2Model source, KanjiDetailOutput destination, ResolutionContext context)
    {
        if (destination is null)
            destination = new KanjiDetailOutput();

        destination.Literal = source.Literal;

        if (source.Misc is not null)
        {
            destination.Jlpt = source.Misc.JlptLevel;
            destination.KankenLevel = source.Misc.KankenLevel;
            destination.Grade = source.Misc.Grade;
            destination.StrokeCount = source.Misc.StrokeCounts![0];
        }

        Kanjidic2Model.GroupModel? groupModel = source.ReadingMeaning?.Groups?[0];

        if (groupModel is not null)
        {
            if (groupModel.Readings is not null)
            {
                List<string> onyomiReadings = new List<string>();
                List<string> kunyomiReadings = new List<string>();
                List<string> sinoVietnamese = new List<string>();

                foreach (Kanjidic2Model.ReadingModel jaOnModel in groupModel.Readings.Where(x => x.Type == "ja_on"))
                {
                    if (jaOnModel.Value is not null)
                        onyomiReadings.Add(jaOnModel.Value);
                }

                foreach (Kanjidic2Model.ReadingModel jaKunModel in groupModel.Readings.Where(x => x.Type == "ja_kun"))
                {
                    if (jaKunModel.Value is not null)
                        kunyomiReadings.Add(jaKunModel.Value);
                }

                foreach (Kanjidic2Model.ReadingModel viReadingModel in groupModel.Readings.Where(x => x.Type == "vietnam"))
                {
                    if (viReadingModel.Value is not null)
                        sinoVietnamese.Add(viReadingModel.Value);
                }

                destination.OnReadings = onyomiReadings;
                destination.KunReadings = kunyomiReadings;
                destination.SinoVietnamese = sinoVietnamese;
            }

            if (groupModel.Meanings is not null)
            {
                List<string> enMeanings = new List<string>();

                foreach (Kanjidic2Model.MeaningModel enMeaningModel in groupModel.Meanings.Where(x => x.Lang == "en"))
                {
                    if (enMeaningModel.Value is not null)
                        enMeanings.Add(enMeaningModel.Value);
                }

                destination.EnMeanings = enMeanings;
            }
        }

        return destination;
    }
}