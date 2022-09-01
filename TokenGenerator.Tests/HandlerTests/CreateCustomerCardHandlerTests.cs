namespace TokenGenerator.Tests.HandlerTests
{
    using Repositories;
    using Domain.Commands;
    using Domain.Handlers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CreateCustomerCardHandlerTests
    {
        private readonly CreateCustomerCardHandler _handler = new CreateCustomerCardHandler(new FakeCustomerCardRepository());

        [TestMethod]
        public void When_CardNumber_Is_Equal_To_345_And_Cvv_Is_Equal_To_2_Token_Should_Return_453()
        {
            var command = new CreateCustomerCardCommand(1, 345, 2);
            var result = (GenericCommandResult)_handler.Handle(command);
            var token = (long)result.Data.GetType().GetProperty("Token").GetValue(result.Data, null);

            Assert.AreEqual(token, (long)453);
        }
    }
}