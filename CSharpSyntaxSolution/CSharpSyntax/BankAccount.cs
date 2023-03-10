namespace CSharpSyntax;

public class BankAccount
{
    private string _accountNumber = string.Empty;
    private string _firstName = string.Empty;
    
    internal BankAccount(string accountNumber)
    {
        _accountNumber = accountNumber;
    }

    public string GetAccountNumber()
    {
        return _accountNumber;
    }

    public string GetFirstName()
    {
        return _firstName;
    }

    public void SetFirstName(string name)
    { 
        _firstName = name;
    }
}

public class AccountManager
{
    public BankAccount GetAccountById(string accountId)
    {
        return new BankAccount(accountId);
    }
}