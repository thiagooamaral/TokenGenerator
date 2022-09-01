namespace TokenGenerator.Domain.Handlers
{
    using Entities;
    using Commands;
    using Contracts;
    using Responses;
    using Repositories;
    using Commands.Contracts;
    using Flunt.Notifications;

    public class CreateCustomerCardHandler : Notifiable, IHandler<CreateCustomerCardCommand>
    {
        private readonly ICustomerCardRepository _repository;
        
        public CreateCustomerCardHandler(ICustomerCardRepository repository) =>
            _repository = repository;

        public ICommandResult Handle(CreateCustomerCardCommand command)
        {
            command.Validate();

            if (command.Invalid)
                return new GenericCommandResult(false, "There was an error processing your request, please try again!", command.Notifications);

            var customerCard = new CustomerCard(command.CustomerId, command.CardNumber, command.Cvv);
            customerCard.CreateToken();

            var dbCustomerCard = _repository.Get(command.CustomerId, command.CardNumber);

            if (dbCustomerCard != null)
                return new GenericCommandResult(false, "The information has already been inserted into the database", new CreateCustomerCardResponse(customerCard.RegistrationDate, customerCard.Token, customerCard.CardNumber));

            _repository.Create(customerCard);

            return new GenericCommandResult(true, "The request was received successfully", 
                new CreateCustomerCardResponse(customerCard.RegistrationDate, customerCard.Token, customerCard.CardNumber));
        }
    }
}