namespace Banking.Domain;

public enum BankAccountType
{
    Standard,
    Gold
}

public class BankAccount
{
    private decimal _balance = 5000M;
    public BankAccountType AccountType = BankAccountType.Standard;
    public void Deposit(decimal amountToDeposit)
    {
        var bonus = AccountType == BankAccountType.Gold ? amountToDeposit * .1M : 0;
        _balance += amountToDeposit + bonus;
    }

    public decimal GetBalance()
    {
        return _balance;
    }

    public void Withdraw(decimal amountToWithdraw)
    {
        if(amountToWithdraw > _balance)
        {
            throw new OverdraftException();
        }
        _balance -= amountToWithdraw;
    }
}