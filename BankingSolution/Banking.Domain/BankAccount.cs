﻿namespace Banking.Domain;

public class BankAccount
{
    private decimal _balance = 5000M;
    public void Deposit(decimal amountToDeposit)
    {
        var bonus = new StandardBonusCalculator();
        _balance += amountToDeposit;
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