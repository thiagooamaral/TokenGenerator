namespace TokenGenerator.Infra.Repositories
{
    using Contexts;
    using System.Linq;
    using Domain.Queries;
    using Domain.Entities;
    using Domain.Repositories;

    public class CustomerCardRepository : ICustomerCardRepository
    {
        private readonly DataContext _context;

        public CustomerCardRepository(DataContext context) =>
            _context = context;

        public void Create(CustomerCard customerCard)
        {
            _context.CustomerCard.Add(customerCard);
            _context.SaveChanges();
        }

        public CustomerCard Get(int customerId, long cardNumber) =>
            _context.CustomerCard.FirstOrDefault(CustomerCardQueries.Get(customerId, cardNumber));
    }
}