namespace TokenGenerator.Domain.Handlers.Contracts
{
    using Commands.Contracts;

    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}