namespace TokenGenerator.Domain.Commands
{
    using Contracts;
    using Flunt.Validations;
    using Flunt.Notifications;

    public class CreateCustomerCardCommand : Notifiable, ICommand
    {
        public CreateCustomerCardCommand() { }

        public CreateCustomerCardCommand(int customerId, long cardNumber, int cvv) =>
            (CustomerId, CardNumber, Cvv) = (customerId, cardNumber, cvv);

        public int CustomerId { get; set; }
        public long CardNumber { get; set; }
        public int Cvv { get; set; }

        public void Validate()
        {
            AddNotifications
            (
                new Contract()
                    .Requires()
                    .IsNotNull(CustomerId, "CustomerId", "The field must be filled")
                    .IsNotNull(CardNumber, "CardNumber", "The field must be filled")
                    .IsNotNull(Cvv, "Cvv", "The field must be filled")
                    .HasMaxLen(CardNumber.ToString(), 16, "CardNumber", "The field must be less than 17 characters long")
                    .HasMaxLen(Cvv.ToString(), 5, "Cvv", "The field must be less than 6 characters long")
            );
        }
    }
}