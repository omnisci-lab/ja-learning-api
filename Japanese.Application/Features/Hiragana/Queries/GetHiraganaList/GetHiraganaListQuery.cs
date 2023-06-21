using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Japanese.Application.Features.Hiragana.Queries.GetHiraganaList;

public class GetHiraganaListQuery : IRequest<List<HiraganaOutput>>
{
}
