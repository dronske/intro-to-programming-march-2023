using Banking.Domain;
using Banking.UnitTests.TestDoubles;
using Moq;

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

    [Fact]
    public void IntegratesWithBonusCalculatorStubbedObject()
    {
        // Given
        var stubbedBonusCalculator = new Mock<ICalculateBonuses>();
        var bankAccount = new BankAccount(stubbedBonusCalculator.Object);
        stubbedBonusCalculator.Setup(dil => dil.CalculateBankAccountDepositBonusFor(bankAccount.GetBalance(), 212.83M)).Returns(12M);

        // When
        bankAccount.Deposit(212.83M);

        // Then
        Assert.Equal(5000M + 212.83M + 12M, bankAccount.GetBalance());
    }
}
