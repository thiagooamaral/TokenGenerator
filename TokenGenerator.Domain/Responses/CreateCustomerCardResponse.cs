namespace TokenGenerator.Domain.Responses
{
    using System;

    public class CreateCustomerCardResponse
    {
        public CreateCustomerCardResponse(DateTime registrationDate, long token, long cardId) =>
            (RegistrationDate, Token, CardId) = (registrationDate, token, cardId);

        public DateTime RegistrationDate { get; set; }
        public long Token { get; set; }
        public long CardId { get; set; }
    }
}