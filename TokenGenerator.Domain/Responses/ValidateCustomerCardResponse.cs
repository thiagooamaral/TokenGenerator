namespace TokenGenerator.Domain.Responses
{
    public class ValidateCustomerCardResponse
    {
        public ValidateCustomerCardResponse(bool validated) =>
            Validated = validated;

        public bool Validated { get; set; }
    }
}