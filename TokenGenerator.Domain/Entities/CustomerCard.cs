namespace TokenGenerator.Domain.Entities
{
    using System;
    using Extensions;

    public class CustomerCard : Entity, IEquatable<CustomerCard>
    {
        public CustomerCard(int customerId, long cardNumber, int cvv) =>
            (CustomerId, CardNumber, Cvv, RegistrationDate) = (customerId, cardNumber, cvv, DateTime.UtcNow);

        public CustomerCard(int customerId, long cardNumber, int cvv, long token) =>
            (CustomerId, CardNumber, Cvv, Token, RegistrationDate) = (customerId, cardNumber, cvv, token, DateTime.UtcNow);

        public int CustomerId { get; private set; }
        public long CardNumber { get; private set; }
        public int Cvv { get; private set; }
        public long Token { get; private set; }
        public DateTime RegistrationDate { get; private set; }

        public void CreateToken()
        {
            const int numberOfDigits = 4;

            var lastDigits = CardNumber.ToString().GetLastDigits(numberOfDigits);
            var arrayRotate = RightCircularRotation(lastDigits.ToCharArray(), Cvv);

            Token = Convert.ToInt64(string.Join(string.Empty, arrayRotate));
        }

        private char[] RightCircularRotation(char[] array, int numberOfTimes)
        {
            var arrayLastPosition = array.Length - 1;

            while (numberOfTimes > 0)
            {
                var temp = array[arrayLastPosition];

                for (int i = arrayLastPosition; i > 0; i--)
                {
                    array[i] = array[i - 1];
                }

                array[0] = temp;
                numberOfTimes--;
            }
            return array;
        }

        public bool Equals(CustomerCard other)
        {
            return CustomerId == other.CustomerId &&
                   CardNumber == other.CardNumber &&
                   Cvv == other.Cvv &&
                   Token == other.Token;
        }
    }
}