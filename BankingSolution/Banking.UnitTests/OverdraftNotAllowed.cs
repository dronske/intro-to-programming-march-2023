using Banking.Domain;
using Banking.UnitTests.TestDoubles;
using System.Security.Principal;

namespace Banking.UnitTests
{
    public class OverdraftNotAllowed
    {
        //[Fact]
        //public void BadBehaviorOverdraftIsAllowed()
        //{
        //    var account = new BankAccount();

        //    account.Withdraw(account.GetBalance() + 0.01M);

        //    Assert.Equal(-.01M, account.GetBalance());
        //}

        [Fact]
        public void OverdraftNotAllowedDoesNotDecreaseBalance()
        {
            BankAccount account = new BankAccount(new DummyBonusCalculator());
            var openingBalance = account.GetBalance();

            try
            {
                account.Withdraw(account.GetBalance() + 0.01M);
            }
            catch (OverdraftException)
            {
                
            }

            Assert.Equal(openingBalance, account.GetBalance());
        }

        [Fact]
        public void OverdraftThrowsException()
        {
            BankAccount account = new BankAccount(new DummyBonusCalculator());
            var openingBalance = account.GetBalance();

            Assert.Throws<OverdraftException>(() =>
            {
                account.Withdraw(account.GetBalance() + 0.01M);
            });
        }
    }
}
