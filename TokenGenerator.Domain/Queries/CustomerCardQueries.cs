namespace TokenGenerator.Domain.Queries
{
    using System;
    using Entities;
    using System.Linq.Expressions;

    public static class CustomerCardQueries
    {
        public static Expression<Func<CustomerCard, bool>> Get(int customerId, long cardNumber) => 
            x => x.CustomerId == customerId && x.CardNumber == cardNumber;
    }
}