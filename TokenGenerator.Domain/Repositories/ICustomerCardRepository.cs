namespace TokenGenerator.Domain.Repositories
{
    using Entities;

    public interface ICustomerCardRepository
    {
        void Create(CustomerCard customerCard);
        CustomerCard Get(int customerId, long cardNumber);
    }
}