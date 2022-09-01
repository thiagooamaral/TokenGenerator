namespace TokenGenerator.Domain.Handlers
{
    using System;
    using Commands;
    using Entities;
    using Contracts;
    using Responses;
    using Repositories;
    using Commands.Contracts;
    using Flunt.Notifications;

    public class ValidateCustomerCardHandler : Notifiable, IHandler<ValidateCustomerCardCommand>
    {
        private readonly ICustomerCardRepository _repository;
        
        public ValidateCustomerCardHandler(ICustomerCardRepository repository) =>
            _repository = repository;

        public ICommandResult Handle(ValidateCustomerCardCommand command)
        {
            command.Validate();

            if (command.Invalid)
                return new GenericCommandResult(false, "There was an error processing your request, please try again!", command.Notifications);

            var dbCustomerCard = _repository.Get(command.CustomerId, command.CardId);
            var newCustomerCard = new CustomerCard(command.CustomerId, command.CardId, command.Cvv, command.Token);

            if (dbCustomerCard == null)
                return new GenericCommandResult(false, "The information cannot be found", new ValidateCustomerCardResponse(false));

            if (DateTime.UtcNow > dbCustomerCard.RegistrationDate.AddMinutes(30))
                return new GenericCommandResult(false, "The token has expired", new ValidateCustomerCardResponse(false));

            if (!dbCustomerCard.Equals(newCustomerCard))
                return new GenericCommandResult(false, "The information is not valid", new ValidateCustomerCardResponse(false));

            return new GenericCommandResult(true, "The request was received successfully", new ValidateCustomerCardResponse(true));
        }
    }
}