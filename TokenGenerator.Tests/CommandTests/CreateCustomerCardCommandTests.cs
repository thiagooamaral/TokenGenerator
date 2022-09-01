namespace TokenGenerator.Tests.CommandTests
{
    using Domain.Commands;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CreateCustomerCardCommandTests
    {
        private readonly long _validCardNumber = 123456789012345;
        private readonly long _invalidCardNumber = 12345678901234567;
        private readonly int _validCvv = 123;
        private readonly int _invalidCvv = 123456;

        [TestMethod]
        public void When_CardNumber_Is_Longer_Than_16_Characters_Should_Return_Invalid()
        {
            var command = new CreateCustomerCardCommand(1, _invalidCardNumber, _validCvv);
            command.Validate();

            Assert.AreEqual(command.Valid, false);
        }

        [TestMethod]
        public void When_CardNumber_Is_Shorter_Than_Or_Equals_16_Characters_Should_Return_Valid()
        {
            var command = new CreateCustomerCardCommand(1, _validCardNumber, _validCvv);
            command.Validate();

            Assert.AreEqual(command.Valid, true);
        }

        [TestMethod]
        public void When_Cvv_Is_Longer_Than_5_Characters_Should_Return_Invalid()
        {
            var command = new CreateCustomerCardCommand(1, _validCardNumber, _invalidCvv);
            command.Validate();

            Assert.AreEqual(command.Valid, false);
        }

        [TestMethod]
        public void When_Cvv_Is_Shorter_Than_Or_Equals_5_Characters_Should_Return_Valid()
        {
            var command = new CreateCustomerCardCommand(1, _validCardNumber, _validCvv);
            command.Validate();
            
            Assert.AreEqual(command.Valid, true);
        }
    }
}
