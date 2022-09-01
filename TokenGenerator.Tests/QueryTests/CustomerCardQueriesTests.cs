namespace TokenGenerator.Tests.QueryTests
{
    using System.Linq;
    using Domain.Queries;
    using Domain.Entities;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CustomerCardQueriesTests
    {
        private List<CustomerCard> _items;

        public CustomerCardQueriesTests()
        {
            _items = new List<CustomerCard>();
            _items.Add(new CustomerCard(1, 4204088170398615, 451));
            _items.Add(new CustomerCard(2, 4173355085588870, 026));
            _items.Add(new CustomerCard(3, 4921049168485204, 336));
            _items.Add(new CustomerCard(4, 4228287296309025, 586));
            _items.Add(new CustomerCard(5, 4287878735491032, 034));
        }

        [TestMethod]
        public void When_Pass_CustomerId_And_CardNumber_Should_Return_Just_One_Result()
        {
            var result = _items.AsQueryable().Where(CustomerCardQueries.Get(2, 4173355085588870));
            Assert.AreEqual(1, result.Count());
        }
    }
}