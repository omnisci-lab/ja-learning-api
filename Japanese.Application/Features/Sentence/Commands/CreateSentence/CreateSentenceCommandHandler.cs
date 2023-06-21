using MediatR;

namespace Japanese.Application.Sentence.Commands.CreateSentence;

public class CreateSentenceCommandHandler : IRequestHandler<CreateSentenceCommand, int>
{
    public Task<int> Handle(CreateSentenceCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
