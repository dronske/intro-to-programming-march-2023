
namespace StringCalculator;

public class StringCalculatorTests
{
    [Fact]
    public void EmptyStringReturnsZero()
    {
        var calculator = new StringCalculator();

        var result = calculator.Add("");

        Assert.Equal(0, result);
    }

    [Theory]
    [InlineData("16", 16)]
    [InlineData("3", 3)]
    public void SingleDigitReturnsSelf(string input, int expected)
    {
        var calculator = new StringCalculator();
        var result = calculator.Add(input);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("16,3", 19)]
    [InlineData("3,4", 7)]
    [InlineData("10,5", 15)]
    public void TwoDigitsReturnsSum(string input, int expected)
    {
        var calculator = new StringCalculator();
        var result = calculator.Add(input);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("16,3,4", 23)]
    [InlineData("3,4,5", 12)]
    [InlineData("10,5,101", 116)]
    public void UnlimitedDigitsReturnsSum(string input, int expected)
    {
        var calculator = new StringCalculator();
        var result = calculator.Add(input);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("16,3\n4", 23)]
    [InlineData("3\n4\n5", 12)]
    [InlineData("10,5,101\n5", 121)]
    public void AllowNewLinesAsDelimiter(string input, int expected)
    {
        var calculator = new StringCalculator();
        var result = calculator.Add(input);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("//;\n16,3;4", 23)]
    [InlineData("//d\n3d4d5", 12)]
    [InlineData("// \n10 5,101 5", 121)]
    public void AllowCustomDelimiters(string input, int expected)
    {
        var calculator = new StringCalculator();
        var result = calculator.Add(input);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("//;\n16,3;-4", 15)]
    [InlineData("//d\n3d-4d5", 12)]
    [InlineData("// \n-10 -5,-101 -5", 121)]
    public void NegativesNotAllowed(string input, int expected)
    {
        var calculator = new StringCalculator();
        Assert.Throws<InvalidOperationException>(() => calculator.Add(input));
    }
}
