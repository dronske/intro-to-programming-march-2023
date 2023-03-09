using Banking.Domain;
using Banking.UnitTests.TestDoubles;

namespace Banking.UnitTests;

public class BankAccountUsesBonusCalculator
{
    [Fact]
    public void IntegratesWithBonusCalculator()
    {
        var bankAccount = new BankAccount(new StubbedBonusCalculator());

        bankAccount.Deposit(212.83M);

        Assert.Equal(5000M + 212.83M + 12M, bankAccount.GetBalance());
    }
}
