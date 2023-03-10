namespace CSharpSyntax;

public class BankAccountTests
{
    [Fact]
    public void GettingMyAccount()
    {
        var service = new AccountManager();
        var myAccount = service.GetAccountById("93939");

        Assert.Equal("93939", myAccount.GetAccountNumber());

        Assert.Equal("Jeff", myAccount.GetFirstName());

        myAccount.SetFirstName("Jeffry");

        Assert.Equal("Jeffry", myAccount.GetFirstName());
    }
}
