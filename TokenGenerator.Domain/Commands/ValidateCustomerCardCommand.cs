namespace TokenGenerator.Domain.Commands
{
    using Contracts;
    using Flunt.Validations;
    using Flunt.Notifications;

    public class ValidateCustomerCardCommand : Notifiable, ICommand
    {
        public ValidateCustomerCardCommand() {}

        public ValidateCustomerCardCommand(int customerId, long cardId, long token, int cvv) =>
            (CustomerId, CardId, Token, Cvv) = (customerId, cardId, token, cvv);

        public int CustomerId { get; set; }
        public long CardId { get; set; }
        public long Token { get; set; }
        public int Cvv { get; set; }

        public void Validate()
        {
            AddNotifications
            (
                new Contract()
                    .Requires()
                    .IsNotNull(CustomerId, "CustomerId", "The field must be filled")
                    .IsNotNull(CardId, "CardId", "The field must be filled")
                    .IsNotNull(Token, "Token", "The field must be filled")
                    .IsNotNull(Cvv, "Cvv", "The field must be filled")
                    .HasMaxLen(Cvv.ToString(), 5, "Cvv", "The field must be less than 6 characters long")
            );
        }
    }
}