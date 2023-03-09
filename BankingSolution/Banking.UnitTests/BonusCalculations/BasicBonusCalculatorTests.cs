using Banking.Domain;

namespace Banking.UnitTests.BonusCalculations
{
    public class BasicBonusCalculatorTests
    {
        // Deposits that meet criteria get a bonus
        [Theory]
        [InlineData(5000,100,10)]
        [InlineData(5000,300,30)]
        [InlineData(4999.99,100,0)]
        public void DepositsGetBonusBasedOnBalance(decimal accountCurrentBalance, decimal amountToDeposit, decimal expectedBonus)
        {
            var bonusCalculator = new StandardBonusCalculator();

            decimal bonus = bonusCalculator.CalculateBankAccountDepositBonusFor(accountCurrentBalance, amountToDeposit);

            Assert.Equal(expectedBonus, bonus);
        }

        // Deposits that do not meet criteria do not get a bonus
    }
}
