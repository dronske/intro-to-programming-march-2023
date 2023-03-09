using Banking.Domain;

namespace Banking.UnitTests.BonusCalculations
{
    public class AdvancedBonusCalculatorTests
    {
        [Fact]

        public void DepositsGetBonusBasedOnBalance()
        {
            var bonusCalculator = new AdvancedBonusCalculator();

            decimal bonus = bonusCalculator.CalculateBankAccountDepositBonusFor(1000M, 10);

            Assert.Equal(-42, bonus);
        }
    }
}
