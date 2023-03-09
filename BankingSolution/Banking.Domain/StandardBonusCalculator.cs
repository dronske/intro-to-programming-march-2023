namespace Banking.Domain
{
    public class StandardBonusCalculator : ICalculateBonuses
    {
        public StandardBonusCalculator()
        {
        }

        public decimal CalculateBankAccountDepositBonusFor(decimal accountCurrentBalance, decimal amountToDeposit)
        {
            return accountCurrentBalance == 5000M ? amountToDeposit * .1M : 0;
        }
    }
}