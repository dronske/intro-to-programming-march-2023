using Banking.Domain;

namespace Banking.UnitTests
{
    public class MakingDeposits
    {
        [Theory]
        [InlineData(100)]
        [InlineData(1.25)]
        [InlineData(135.37)]
        public void DepositsIncreasesTheBalance(decimal amountToDeposit)
        {
            // Given
            var account = new BankAccount();
            var openingBalance = account.GetBalance();
            // var amountToDeposit = 100M;

            // When
            account.Deposit(amountToDeposit);

            // Then
            Assert.Equal(openingBalance + amountToDeposit, account.GetBalance());
        }
    }
}
