namespace Banking.Domain;

public class AdvancedBonusCalculator : ICalculateBonuses
{
    public decimal CalculateBankAccountDepositBonusFor(decimal accountCurrentBalance, decimal amountToDeposit)
    {
        return -42;
    }
}