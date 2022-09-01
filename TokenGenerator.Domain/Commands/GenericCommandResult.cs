namespace TokenGenerator.Domain.Commands
{
    using Contracts;

    public class GenericCommandResult : ICommandResult
    {
        public GenericCommandResult() { }

        public GenericCommandResult(bool success, string message, object data) =>
            (Success, Message, Data) = (success, message, data);

        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}