﻿using Banking.Domain;

namespace Banking.UnitTests
{
    public class NewAccounts
    {
        [Fact]
        public void NewAccountHasCorrectOpeningBalance()
        {
            // Given
            BankAccount account = new BankAccount();

            // When
            decimal balance = account.GetBalance();

            // Then
            Assert.Equal(5000, balance);
        }
    }
}
