using Banking.Domain;

namespace Banking.UnitTests.TestDoubles;

public class DummyBonusCalculator : ICalculateBonuses
{
    public decimal CalculateBankAccountDepositBonusFor(decimal accountCurrentBalance, decimal amountToDeposit)
    {
        return 0;
    }
}
