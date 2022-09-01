namespace TokenGenerator.Tests.Repositories
{
    using Domain.Entities;
    using Domain.Repositories;

    public class FakeCustomerCardRepository : ICustomerCardRepository
    {
        public void Create(CustomerCard customerCard) { }

        public CustomerCard Get(int customerId, long cardNumber) => new CustomerCard(1, 123456789, 123);
    }
}