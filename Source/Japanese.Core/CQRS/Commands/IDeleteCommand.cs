namespace Japanese.Core.CQRS.Commands;

public interface IDeleteCommand
{
    bool ForceDelete { get; set; }
}