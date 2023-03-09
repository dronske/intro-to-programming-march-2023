using Banking.Domain;
using Banking.UnitTests.TestDoubles;

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
            BankAccount account = new BankAccount(new DummyBonusCalculator());
            var openingBalance = account.GetBalance();

            // When
            account.Withdraw(amountToWithdraw);

            // Then
            Assert.Equal(openingBalance - amountToWithdraw, account.GetBalance());
        }
    }
}

