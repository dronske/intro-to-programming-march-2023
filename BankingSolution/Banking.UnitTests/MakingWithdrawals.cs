using Banking.Domain;

namespace Banking.UnitTests
{
    public class MakingWithdrawals
    {
        [Theory]
        [InlineData(100)]
        [InlineData(1.25)]
        [InlineData(135.37)]
        public void WithdrawalDecreasesTheBalance(decimal amountToWithdraw)
        {
            // Given
            var account = new BankAccount();
            var openingBalance = account.GetBalance();

            // When
            account.Withdraw(amountToWithdraw);

            // Then
            Assert.Equal(openingBalance - amountToWithdraw, account.GetBalance());
        }
    }
}

