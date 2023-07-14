using AutoMapper;
using Japanese.Models;
using Japanese.Services.Kanji.Commands.CreateKanji;
using Japanese.Services.Kanji.Commands.UpdateKanji;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Japanese.Services.Kanji.Mappings;

public class KanjiMappingProfile : Profile
{
    public KanjiMappingProfile()
    {
        CreateMap<CreateKanjiCommand, KanjiModel>().ReverseMap();
        CreateMap<UpdateKanjiCommand, KanjiModel>().ReverseMap();
    }
}
