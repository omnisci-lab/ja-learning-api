using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Japanese.CachedRepository.Interfaces;

public interface IJapaneseCachedRepository
{
    IKanjidic2CachedRepository Kanjidic2CachedRepositoty { get; }
}
