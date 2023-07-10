using Japanese.Core.CommonModels;
using Japanese.Core.Encoding;
using Japanese.Core.Enum;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using MediatR;

namespace Japanese.Services.Sentence.Queries.GetPagedSentences;

public class GetPagedSentencesQueryHandler : IRequestHandler<GetPagedSentencesQuery, ExecResult<Pagination<SentenceOutput>>>
{
    private readonly ISentenceRepository _sentenceRepository;

    public GetPagedSentencesQueryHandler(IJapaneseRepository repository)
    {
        _sentenceRepository = repository.SentenceRepository;
    }

    public async Task<ExecResult<Pagination<SentenceOutput>>> Handle(GetPagedSentencesQuery request, CancellationToken cancellationToken)
    {
        Base64 base64 = new Base64();
        request.PaginationToken = base64.Decode(request.PaginationToken);
        Pagination<SentenceModel> paged = await _sentenceRepository.GetPagedAsync(request);

        return new ExecResult<Pagination<SentenceOutput>>
        {
            Status = ExecStatus.Success,
            Data = new Pagination<SentenceOutput>
            {
                PaginationToken = base64.Encode(paged.PaginationToken),
                PageSize = paged.PageSize,
                Items = paged.Items.Select(sentenceModel => new SentenceOutput
                {
                    SentenceId = sentenceModel.SentenceId,
                    Text = sentenceModel.Text,
                    Structure = sentenceModel.Structure,
                    Jlpt = sentenceModel.Jlpt,
                    EnMeanings = sentenceModel.EnMeanings,
                    ViMeanings = sentenceModel.ViMeanings,
                    References = sentenceModel.References
                }).ToList()
            }
        };
    }
}